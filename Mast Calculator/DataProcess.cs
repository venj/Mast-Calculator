using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;

namespace me.venj
{
    public class DataProcess
    {
        public static string DataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Process.GetCurrentProcess().ProcessName);
        public static string DBPATH = Path.Combine(DataDirectory, "data.db");

        private string DataSource
        {
            get
            {
                if (!Directory.Exists(DataDirectory))
                {
                    Directory.CreateDirectory(DataDirectory);
                }
                return "Data Source=" + DBPATH;
            }
        }

        public DataProcess()
        {
            if (!File.Exists(DBPATH))
            {
                using (var conn = new SQLiteConnection(DataSource))
                {
                    conn.Open();
                    using (SQLiteCommand command = new SQLiteCommand(conn))
                    {
                        command.CommandText = "CREATE TABLE histories (id INTEGER PRIMARY KEY AUTOINCREMENT, initialHeight INTEGER, totalHeight INTEGER, maxLoad INTEGER, pistonType INTEGER, columnCount INTEGER, minimumColumn INTEGER, columnMovableHeight INTEGER, databaseFileName INTEGER, totalHeightThreshold INTEGER, minimumColumnFromLoadOnly STRING, timestamp INTEGER)";
                        command.ExecuteNonQuery();
                    }
                }
            }

            Console.WriteLine(DBPATH);
        }
    }
}
