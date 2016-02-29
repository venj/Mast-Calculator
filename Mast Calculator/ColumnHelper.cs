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

        

    }
}
