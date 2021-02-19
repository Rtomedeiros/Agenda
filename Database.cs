using System;
using System.Collections.Generic;
using System.Data.SQLite; // dotnet add package Microsoft.Data.Sqlite
using System.Globalization;

static class Database
{
    public static string ConnectionString { get; } = "Data Source=agenda.db";
    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(ConnectionString);
    }

    public static void LoadDatabase()
    {
        using (SQLiteConnection dbConnection = Database.GetConnection())
        {
            dbConnection.Open();
            using (SQLiteCommand cmd = dbConnection.CreateCommand())
            {
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Eventos(ID INTEGER PRIMARY KEY AUTOINCREMENT, Evento VARCHAR(255), Data datetime)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"SELECT * FROM Eventos";
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string evento = reader.GetString(0);
                        Console.WriteLine($"test {evento}!");
                    }
                }
            }
        }
    }

    public static void DatabaseDelete()
    {
        using (SQLiteConnection dbConnection = Database.GetConnection())
        {
            dbConnection.Open();
            using (SQLiteCommand cmd = dbConnection.CreateCommand())
            {

            }
        }
    }

    public static void DatabaseCreate()
    {
        using (SQLiteConnection dbConnection = Database.GetConnection())
        {
            dbConnection.Open();
            using (SQLiteCommand cmd = dbConnection.CreateCommand())
            {

            }
        }
    }
}
