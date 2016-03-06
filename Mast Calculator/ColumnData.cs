using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mast_Calculator
{
    public sealed class ColumnData
    {
        public List<ColumnItem> columns;
        private const string defaultFilePath = "column_data.txt";

        private static volatile ColumnData instance;
        private static object syncRoot = new Object();
        private ColumnData() { }
        public static ColumnData Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ColumnData();
                            instance.readData();
                        }
                    }
                }
                return instance;
            }
        }

        public void resetDataFile(string filePath = defaultFilePath)
        {
            readData(filePath);
        }

        private void readData(string filePath = defaultFilePath)
        {
            if (columns != null) {
                columns.Clear();
            }
            else
            {
                columns = new List<ColumnItem>();
            }
            foreach (var line in File.ReadAllLines(filePath)) {
                var c = new List<string>();
                foreach (var s in line.Split(','))
                {
                    c.Add(s.Trim());
                }
                columns.Add(new ColumnItem(c));
            }
        }
    }
}
