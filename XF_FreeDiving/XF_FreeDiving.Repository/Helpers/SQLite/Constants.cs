using System;
using System.IO;

namespace XF_FreeDiving.Repository.Helpers.SQLite
{
    public static class Constants
    {
        public const string DatabaseFilename = "FreeDivingSQLite.db3";

        public const global::SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            global::SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            global::SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            global::SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}