using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mast_Calculator
{
    public enum PistonType
    {
        Dule = 0,
        Single = 1
    }

    public enum ColumnMovableHeightRestriction
    {
        NotSame = 0,
        Same = 1
    }

    public class ColumnHelper
    {
        public const string TotalHeightKey = "ResultTotalHeight";
        public const string InitialHeightKey = "ResultInitialHeight";
        public const string MovableHeightKey = "ResultMovableHeight";
        public const string ColumnHeightsAndMovableHeightsKey = "ResultColumnHeightsAndMovableHeights";
        public const string InnerMostColumnIndexKey = "ResultInnerMostColumnIndex";

        public const int SPACE_BETWEEN_COLUMNS = 4;
        public const int TOTAL_COLUMNS_COUNT = 13;
        public const int BUFFER_THICKNESS = 3;
        public const int COLUMN_INDEX_SHIFT = 2;
        public const int COLUMN_COUNT_MIN = 3;
        public const int COLUMN_INIT_HEIGHT_MAX = 30000;

        public int UserInitialHeight { get; set; }
        //public int UserTotalHeight { get; set; }
        //public int UserMaxLoad { get; set; }

        public PistonType PistonType { get; set; }
        public int ColumnsCount { get; set; }
        public int MinimumColumn { get; set; }
        public int TotalHeightThreshold { get; set; }
        public bool UseMinimumColumnFromLoadOnly { get; set; }
        public ColumnMovableHeightRestriction MovableHeightRestriction { get; set; }

        private static volatile ColumnHelper instance;
        private static object syncRoot = new Object();
        private ColumnHelper() { }

        public static ColumnHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ColumnHelper();
                        }
                    }
                }
                return instance;
            }
        }

        public int LoadIndexForMaxLoad(double maxLoad)
        {
            int index = -1;
            var columns = ColumnData.Instance.columns;
            for (int i = 0; i < columns.Count; ++i)
            {
                if (columns[i].TheoryLoad >= maxLoad)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public int MaxColumnCountForMaxLoad(double maxLoad)
        {
            int index = LoadIndexForMaxLoad(maxLoad);
            return TOTAL_COLUMNS_COUNT - index;
        }

        public bool IsValidForColumnCountsAndMaxLoad(double maxLoad)
        {
            return ColumnsCount <= MaxColumnCountForMaxLoad(maxLoad);
        }

        public List<Dictionary<string, object>> ResultSetForLoad(int requiredMaxLoad, int initialHeight)
        {
            var results = new List<Dictionary<string, object>>();
            int innerMostColumnIndex = 0;
            if (MinimumColumn < 0)
            {
                innerMostColumnIndex = LoadIndexForMaxLoad(requiredMaxLoad);
            }
            else
            {
                innerMostColumnIndex = MinimumColumn;
            }

            int startColumnCount = 3;
            int endColumnCount = TOTAL_COLUMNS_COUNT - innerMostColumnIndex;

            if (ColumnsCount >= 3)
            {
                startColumnCount = ColumnsCount;
                endColumnCount = startColumnCount;
            }

            for (int columnCount = startColumnCount; columnCount <= endColumnCount; columnCount++)
            {
                int endColumnIndex = (TOTAL_COLUMNS_COUNT - columnCount);
                if (UseMinimumColumnFromLoadOnly)
                {
                    endColumnIndex = innerMostColumnIndex;
                }

                for (int columnIndex = innerMostColumnIndex; columnIndex <= endColumnIndex; columnIndex++)
                {
                    var columnHeightsAndMovableHeights = ColumnHeightsWithInnerMostColumnIndex(columnIndex, columnCount: columnCount, initialHeight: initialHeight);
                    var totalHeight = TotalHeightForMovableHeights(columnHeightsAndMovableHeights[1], initialHeight: initialHeight);
                    var dict = new Dictionary<string, object> {
                        [TotalHeightKey] = totalHeight,
                        [ColumnHeightsAndMovableHeightsKey] = columnHeightsAndMovableHeights,
                        [InnerMostColumnIndexKey] = columnIndex
                    };
                    results.Add(dict);
                }
            }

            return results;
        }

        public List<Dictionary<string, object>> ResultsOfMaxHeightForLoad(int requiredMaxLoad, int initialHeight)
        {
            var results = new List<Dictionary<string, object>>();
            int innerMostColumnIndex = LoadIndexForMaxLoad(requiredMaxLoad);
            int[] initialHeights = { UserInitialHeight, initialHeight };
            int totalHeight;
            List<List<int>> columnHeightsAndMovableHeights;

            columnHeightsAndMovableHeights = ColumnHeightsWithInnerMostColumnIndex(innerMostColumnIndex, columnCount: TOTAL_COLUMNS_COUNT - innerMostColumnIndex, initialHeight: initialHeights[0]);
            totalHeight = TotalHeightForMovableHeights(columnHeightsAndMovableHeights[1], initialHeight: initialHeights[0]);
            results.Add(new Dictionary<string, object> {
                [TotalHeightKey] = totalHeight,
                [ColumnHeightsAndMovableHeightsKey] = columnHeightsAndMovableHeights,
                [InnerMostColumnIndexKey] = innerMostColumnIndex
            });

            columnHeightsAndMovableHeights = ColumnHeightsWithInnerMostColumnIndex(innerMostColumnIndex, columnCount: TOTAL_COLUMNS_COUNT - innerMostColumnIndex, initialHeight: initialHeights[1]);
            totalHeight = TotalHeightForMovableHeights(columnHeightsAndMovableHeights[1], initialHeight: initialHeights[1]);
            results.Add(new Dictionary<string, object> {
                [TotalHeightKey] = totalHeight,
                [ColumnHeightsAndMovableHeightsKey] = columnHeightsAndMovableHeights,
                [InnerMostColumnIndexKey] = innerMostColumnIndex,
                [InitialHeightKey] = initialHeights[1]
            });
            
            return results;
        }

        public bool IsValidTheoryTotalHeight(int theoryTotalHeight, int requiredTotalHeight, bool allowTotalHeightThreshold = true)
        {
            int threshold = 0;
            if (allowTotalHeightThreshold)
            {
                threshold = TotalHeightThreshold;
            }

            return theoryTotalHeight  >= requiredTotalHeight - threshold;
        }

        public bool IsPossibleForMaxColumnHeight(int totalHeight, int initialHeight, int requiredLoad, bool allowTotalHeightThreshold = true)
        {
            int theoryTotalHeight = TheoryTotalColumnHeightWithInitialHeight(initialHeight, requiredLoad: requiredLoad);
            return IsValidTheoryTotalHeight(theoryTotalHeight, requiredTotalHeight: totalHeight, allowTotalHeightThreshold: allowTotalHeightThreshold);
        }

        public int TheoryTotalColumnHeightWithInitialHeight(int initialHeight, int requiredLoad)
        {
            int innerMostColumnIndex = LoadIndexForMaxLoad(requiredLoad);
            int maxColumnCount = TOTAL_COLUMNS_COUNT - innerMostColumnIndex;
            int theoryMaxHeight = TotalHeightForInnerMostColumnIndex(innerMostColumnIndex, columnCount: maxColumnCount, initialHeight: initialHeight);
            return theoryMaxHeight;
        }

        public int TotalHeightForMovableHeights(List<int> movableHeights, int initialHeight)
        {
            var totalHeight = initialHeight + movableHeights.Sum();
            return totalHeight;
        }

        public int TotalHeightForOutterMostColumnIndex(int outterMostColumnIndex, int columnCount, int initialHeight)
        {
            var columHeightsAndMovableHeights = ColumnHeightsWithOutterMostColumnIndex(outterMostColumnIndex, columnCount: columnCount, initialHeight: initialHeight);
            return TotalHeightForMovableHeights(columHeightsAndMovableHeights[1], initialHeight: initialHeight);
        }

        public int TotalHeightForInnerMostColumnIndex(int innerMostColumnIndex, int columnCount, int initialHeight)
        {
            int outterMostColumnIndex = innerMostColumnIndex + columnCount - 1;
            return TotalHeightForOutterMostColumnIndex(outterMostColumnIndex, columnCount: columnCount, initialHeight: initialHeight);
        }

        public List<List<int>> ColumnHeightsWithInnerMostColumnIndex(int innerMostColumnIndex, int columnCount, int initialHeight)
        {
            int outterMostColumnIndex = innerMostColumnIndex + columnCount - 1;
            return ColumnHeightsWithOutterMostColumnIndex(outterMostColumnIndex, columnCount: columnCount, initialHeight: initialHeight);
        }

        public List<List<int>> ColumnHeightsWithOutterMostColumnIndex(int outterMostColumnIndex, int columnCount, int initialHeight)
        {
            var columnHeights = new List<int>();
            var columnHeightLimits = new List<int>();
            var columnMovableHeights = new List<int>();
            int innerMostColumnIndex = outterMostColumnIndex - columnCount + 1;
            int currentColumnHeight = -1;
            int currentColumnMovableHeight = -1;

            ColumnItem previousColumn = null, currentColumn = null;
            int commonMovableHeight = 0, commonJointHeight = 0;

            for (int colIndex = outterMostColumnIndex; colIndex >= innerMostColumnIndex; colIndex--)
            {
                previousColumn = currentColumn;
                currentColumn = ColumnData.Instance.columns[colIndex];

                int? previousPistonJointHeight, previousPistonHeight;
                int currentPistonHeight;
                if (PistonType == PistonType.Single)
                {
                    previousPistonJointHeight = previousColumn?.SinglePistonJointHeight;
                    previousPistonHeight = previousColumn?.SinglePistonHeight;
                    currentPistonHeight = currentColumn.SinglePistonHeight;
                }
                else
                {
                    previousPistonJointHeight = previousColumn?.DualPistonJointHeight;
                    previousPistonHeight = previousColumn?.DualPistonHeight;
                    currentPistonHeight = currentColumn.DualPistonHeight;
                }

                columnHeightLimits.Add(currentColumn.ColumnHeightLimit);

                if (colIndex == outterMostColumnIndex)
                {
                    currentColumnHeight = initialHeight - (columnCount - 1) * (currentColumn.CommonCapHeight + currentColumn.CommonCapJointHeight + BUFFER_THICKNESS) - currentColumn.TopCapHeight - currentColumn.BottomThickness + currentColumn.CommonCapJointHeight;
                    if (currentColumnHeight > currentColumn.ColumnHeightLimit)
                    {
                        currentColumnHeight = currentColumn.ColumnHeightLimit;
                    }
                }
                else if (colIndex == outterMostColumnIndex - 1)
                {
                    currentColumnHeight = currentColumnHeight - SPACE_BETWEEN_COLUMNS - previousColumn.BottomJointHeight - currentPistonHeight + currentColumn.CommonCapHeight + currentColumn.CommonCapJointHeight + BUFFER_THICKNESS;
                    if (currentColumnHeight > currentColumn.ColumnHeightLimit)
                    {
                        currentColumnHeight = currentColumn.ColumnHeightLimit;
                    }

                    int mHeight = currentColumnHeight - currentColumn.JoinHeight - currentColumn.CommonCapJointHeight - previousColumn.CommonCapHeight - BUFFER_THICKNESS;

                    if (MovableHeightRestriction == ColumnMovableHeightRestriction.NotSame)
                    {
                        currentColumnMovableHeight = mHeight;
                    }
                    else
                    {
                        commonMovableHeight = mHeight;
                        commonJointHeight = currentColumn.JoinHeight;
                    }
                }
                else if (colIndex == innerMostColumnIndex)
                {
                    if (MovableHeightRestriction == ColumnMovableHeightRestriction.NotSame)
                    {
                        currentColumnHeight = currentColumnHeight - SPACE_BETWEEN_COLUMNS - (int)previousPistonJointHeight - currentPistonHeight + previousColumn.CommonCapHeight + currentColumn.TopCapHeight + BUFFER_THICKNESS;
                        if (currentColumnHeight > currentColumn.ColumnHeightLimit)
                        {
                            currentColumnHeight = currentColumn.ColumnHeightLimit;
                        }
                        currentColumnMovableHeight = commonMovableHeight - currentColumn.JoinHeight - currentColumn.TopCapHeight - previousColumn.CommonCapHeight - BUFFER_THICKNESS;
                    }
                    else
                    {
                        currentColumnHeight = commonMovableHeight + commonJointHeight + currentColumn.CommonCapJointHeight + previousColumn.CommonCapHeight + BUFFER_THICKNESS;
                    }
                }
                else {
                    if (MovableHeightRestriction == ColumnMovableHeightRestriction.NotSame)
                    {
                        currentColumnHeight = currentColumnHeight - SPACE_BETWEEN_COLUMNS - (int)previousPistonJointHeight - currentPistonHeight + currentColumn.CommonCapHeight + currentColumn.CommonCapJointHeight + BUFFER_THICKNESS;
                        if (currentColumnHeight > currentColumn.ColumnHeightLimit)
                        {
                            currentColumnHeight = currentColumn.ColumnHeightLimit;
                        }
                        currentColumnMovableHeight = currentColumnHeight - currentColumn.JoinHeight - currentColumn.CommonCapJointHeight - previousColumn.CommonCapHeight + BUFFER_THICKNESS;
                    }
                    else
                    {
                        currentColumnHeight = commonMovableHeight + commonJointHeight + currentColumn.CommonCapJointHeight + previousColumn.CommonCapHeight + BUFFER_THICKNESS;
                    }
                }

                columnHeights.Add(currentColumnHeight);

                int _mHeight;

                if (MovableHeightRestriction == ColumnMovableHeightRestriction.NotSame)
                {
                    _mHeight = currentColumnMovableHeight;
                }
                else
                {
                    _mHeight = commonMovableHeight;
                }
                if (colIndex != outterMostColumnIndex)
                {
                    columnMovableHeights.Add(_mHeight);
                }

            }
            
            return new List<List<int>> {
                columnHeights, columnMovableHeights, columnHeightLimits
            };
        }

        public List<int> movableHeightResultsetForInitialHeight(int initialHeight, int totalHeight, int maxLoad)
        {
            var result = new List<int>();
            int innerMostColumnIndex = 0;
            if (MinimumColumn < 0)
            {
                innerMostColumnIndex = LoadIndexForMaxLoad(maxLoad);
            }
            else
            {
                innerMostColumnIndex = MinimumColumn;
            }

            return result;
        }

        public Dictionary<string, object> ResultFromMovableHeightResult(List<int> movableHeightResult)
        {
            int outterMostColumnIndex = movableHeightResult[3];
            int columnCount = movableHeightResult[0];
            int movableHeight = movableHeightResult[1];
            int totalHeight = movableHeightResult[2];
            int initialHeight = totalHeight - movableHeight * columnCount;

            var columnAndMovableHeight = ColumnHeightsWithOutterMostColumnIndex(outterMostColumnIndex, columnCount: columnCount, initialHeight: initialHeight);
            var result = new Dictionary<string, object> {
                [TotalHeightKey] = totalHeight,
                [ColumnHeightsAndMovableHeightsKey] = columnAndMovableHeight,
                [InnerMostColumnIndexKey] = outterMostColumnIndex - columnCount,
                [InitialHeightKey] = initialHeight
            };
            return result;
        }
    }
}
