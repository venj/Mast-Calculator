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

    public enum MovableHeightRestriction
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

        public PistonType PistonType { get; set; }
        public int ColumnsCount { get; set; }
        public int MinimumColumn { get; set; }
        public int TotalHeightThreshold { get; set; }
        public bool UseMinimumColumnFromLoadOnly { get; set; }
        public MovableHeightRestriction MovableHeightRestriction { get; set; }

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
                    var totalHeight = TotalHeightForMovableHeightsWithInitialHeight(columnHeightsAndMovableHeights[1], initialHeight: initialHeight);
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
            int[] initialHeights = { 1, 2 };
            // TODO: Implementation.


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

        public int TotalHeightForMovableHeightsWithInitialHeight(List<int> movableHeights, int initialHeight)
        {
            var totalHeight = initialHeight + movableHeights.Sum();
            return totalHeight;
        }

        public int TotalHeightForOutterMostColumnIndex(int outterMostColumnIndex, int columnCount, int initialHeight)
        {
            //TODO: Implementation
            return 0;
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
            //TODO: Implementation
            movableHeightResultsetForInitialHeight(1000, totalHeight: 3000, maxLoad: 9);

            return new List<List<int>>();
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
