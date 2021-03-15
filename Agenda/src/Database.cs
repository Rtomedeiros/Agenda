using Microsoft.Data.Sqlite;
using System;

static class Database
{
    public static string ConnectionString { get; } = "Data Source=agenda.db";

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection(ConnectionString);
    }

    public static void LoadDatabase()
    {
        using (SqliteConnection dbConnection = Database.GetConnection())
        {
            dbConnection.Open();
            using (SqliteCommand cmd = dbConnection.CreateCommand())
            {
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Eventos(ID INTEGER PRIMARY KEY AUTOINCREMENT, Evento VARCHAR(255), Data datetime)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"SELECT * FROM Eventos";
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Evento e = new Evento(reader.GetInt32(0), Convert.ToDateTime(reader.GetString(2)), reader.GetString(1));
                        AgendaInterface.AdicionarEvento(e);
                    }
                }
            }
        }
        AgendaInterface.SortByDate();
    }

    public static void DatabaseDelete(Evento e)
    {
        using (SqliteConnection dbConnection = Database.GetConnection())
        {
            dbConnection.Open();
            using (SqliteCommand cmd = dbConnection.CreateCommand())
            {
                cmd.CommandText = @"DELETE FROM Eventos WHERE id = $id;";
                cmd.Parameters.AddWithValue("$id", e.id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static Evento DatabaseCreate(string descricao, DateTime data)
    {
        using (SqliteConnection dbConnection = Database.GetConnection())
        {
            dbConnection.Open();
            using (SqliteCommand cmd = dbConnection.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO Eventos(Evento, Data) VALUES ($Evento, $Data)";
                cmd.Parameters.AddWithValue("$Evento", descricao);
                cmd.Parameters.AddWithValue("$Data", data.ToLongDateString());
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"SELECT last_insert_rowid();";
                int lastId = cmd.ExecuteNonQuery();
                Evento evento = new Evento(lastId, data, descricao);
                return evento;
            }
        }
    }
}
