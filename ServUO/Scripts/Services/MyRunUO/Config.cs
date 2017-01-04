// Updated to replace ODBC with MySQL

using System;
using System.Text;
using System.Threading;

namespace Server.Engines.MyRunUO
{
    public class Config
    {
        // Is MyRunUO enabled?
        public static bool Enabled = true;
        // Details required for database connection string
        public const string DatabaseServer = "localhost";
        public const string DatabasePort = "3306";
        public const string DatabaseName = "myrunuo";
        public const string DatabaseUserID = "myrunuo";
        public const string DatabasePassword = "myPassword";
        // Should the database use transactions? This is recommended
        public static bool UseTransactions = true;
        // Use optimized table loading techniques? (LOAD DATA INFILE)
        public static bool LoadDataInFile = true;
        // This must be enabled if the database server is on a remote machine.
        public static bool DatabaseNonLocal = (DatabaseServer != "localhost");
        // Text encoding used
        public static Encoding EncodingIO = Encoding.ASCII;
        // Database communication is done in a separate thread. This value is the 'priority' of that thread, or, how much CPU it will try to use
        public static ThreadPriority DatabaseThreadPriority = ThreadPriority.BelowNormal;
        // Any character with an AccessLevel equal to or higher than this will not be displayed
        public static AccessLevel HiddenAccessLevel = AccessLevel.Counselor;
        // Export character database every 30 minutes
        public static TimeSpan CharacterUpdateInterval = TimeSpan.FromMinutes(30.0);
        // Export online list database every 5 minutes
        public static TimeSpan StatusUpdateInterval = TimeSpan.FromMinutes(5.0);
        public static string CompileConnectionString()
        {
            string connectionString = String.Format("SERVER={0};PORT={1};DATABASE={2};UID={3};PWD={4};",
                DatabaseServer, DatabasePort, DatabaseName, DatabaseUserID, DatabasePassword);
            return connectionString;
        }
    }
}
