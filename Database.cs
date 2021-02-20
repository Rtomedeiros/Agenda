using System;
using System.Data.SQLite; // dotnet add package Microsoft.Data.Sqlite

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
                        Evento e = new Evento(reader.GetInt32(0), Convert.ToDateTime(reader.GetString(2)), reader.GetString(1));
                        Agenda.AdicionarEvento(e);
                    }
                }
            }
        }
        Agenda.SortByDate();
    }

    public static void DatabaseDelete(Evento e)
    {
        using (SQLiteConnection dbConnection = Database.GetConnection())
        {
            dbConnection.Open();
            using (SQLiteCommand cmd = dbConnection.CreateCommand())
            {
                cmd.CommandText = @"DELETE FROM Eventos WHERE id = $id;";
                cmd.Parameters.AddWithValue("$id", e.id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static Evento DatabaseCreate(string descricao, DateTime data)
    {
        using (SQLiteConnection dbConnection = Database.GetConnection())
        {
            dbConnection.Open();
            using (SQLiteCommand cmd = dbConnection.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Eventos(Evento, Data) VALUES ($Evento, $Data)";
                cmd.Parameters.AddWithValue("$Evento", descricao);
                cmd.Parameters.AddWithValue("$Data", data.ToLongDateString());
                cmd.ExecuteNonQuery();
                Evento evento = new Evento((int)dbConnection.LastInsertRowId, data, descricao);
                return evento;
            }
        }
    }
}
