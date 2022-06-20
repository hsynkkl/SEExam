using System.Data.SQLite;

namespace Task1
{
    public class Program
    {

        static void Main (string[] args)
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            CreateTable(sqlite_conn);
            ReadData(sqlite_conn);
        }
        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=task1; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Database error");
            }
            return sqlite_conn;
        }

        static void CreateTable(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            string strSportsman = "CREATE TABLE if not exists  Sportsman(ID INTEGER PRIMARY KEY AUTOINCREMENT, NAME STRING NOT NULL, COUNTRY STRING NOT NULL, RECORD INT NOT NULL";
            sqlite_cmd = conn.CreateCommand();

            sqlite_cmd.CommandText = strSportsman;
            sqlite_cmd.ExecuteNonQuery();

            conn.Close();
        }

        
        static void ReadData(SQLiteConnection conn)
        {
            conn.Open();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT NAME, RECORD from Sportsman ORDER BY RECORD DESC LIMIT 1";

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                Console.WriteLine(sqlite_datareader);
            }
            conn.Close();
        }
        //change1
        
    }
}
