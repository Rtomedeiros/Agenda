using System;
using System.Collections.Generic;
using System.Data.SQLite; // dotnet add package Microsoft.Data.Sqlite

static class Agenda {

    static List<Evento> eventos = new List<Evento>();

    public static void LoadDatabase() {
        string cs = "Data Source=:memory:";
        using SQLiteConnection dbConnection = new SQLiteConnection(cs);
        dbConnection.Open();
        SQLiteCommand cmd = dbConnection.CreateCommand();
        cmd.CommandText = @"CREATE DATABASE IF NOT EXISTS Agenda";
        cmd.ExecuteNonQuery();
        cmd.CommandText = @"USE Agenda";
        cmd.ExecuteNonQuery();
        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Eventos(Evento VARCHAR(255), Data datetime)";
        cmd.ExecuteNonQuery();

        cmd.CommandText = @"SELECT * FROM Eventos";
        using (SQLiteDataReader reader = cmd.ExecuteReader()) {
            while (reader.Read()) {
                string evento = reader.GetString(0);
                Console.WriteLine($"Hello, {evento}!");
            }
        }
    }

    public static void AdicionarEvento(Evento e) {
        eventos.Add(e);
    }

    public static void ListarEventos() {
        eventos.ForEach(x => Console.WriteLine($"[{eventos.IndexOf(x)}] {x}\n"));
    }

    public static void ExcluirEvento(int excluir) {
        int index = 1;
        foreach (Evento i in eventos) {
            if (index == excluir) {
                eventos.Remove(i);
                break;
            }
            index++;
        }
    }

    public static void CriarEvento() {
        Console.WriteLine("Digite o dia do evento: ");
        int dia = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite o mês do evento: ");
        int mes = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite o ano do evento: ");
        int ano = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite a descrição do evento: ");
        string descricao = Console.ReadLine();
        try {
            DateTime dt = new DateTime(ano, mes, dia);
            Evento novo = new Evento(dt, descricao);
            Agenda.AdicionarEvento(novo);
        } catch {
            Console.WriteLine("Você digitou algum valor incorreto, tente novamente.");
        }
    }

    public static void ExcluirEvento() {
        Console.WriteLine("Digite o evento que deseja excluir: ");
        int idExcluir = Convert.ToInt32(Console.ReadLine());
        Evento excluir = Agenda.eventos[idExcluir];
        Agenda.eventos.Remove(excluir);
    }
}
