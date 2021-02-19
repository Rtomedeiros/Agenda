using System;
using System.Collections.Generic;
using System.Data.SQLite; // dotnet add package Microsoft.Data.Sqlite
using System.Globalization;

static class Agenda
{
    static List<Evento> eventos = new List<Evento>();

    public static void AdicionarEvento(Evento e)
    {
        eventos.Add(e);
    }

    public static void ListarEventos()
    {
        eventos.ForEach(x => Console.WriteLine($"[{eventos.IndexOf(x)}] {x.ToString()}\n"));
    }

    public static void DeletarEvento(int id)
    {
        Evento deletar = eventos[id];
        if (deletar == null)
        {
            Console.WriteLine("Este evento não existe.");
            return;
        }
        eventos.RemoveAt(id);
    }

    public static void CriarEvento()
    {
        Console.WriteLine("Digite a data do evento: (Ex: 15/02/2021)");
        while (true)
        {
            string data = Console.ReadLine();
            if (DateTime.TryParse(data, new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime dataValida))
            {
                Console.WriteLine("Digite uma descrição para o evento: ");
                string descricao = Console.ReadLine();
                Evento evento = new Evento(dataValida, descricao);
                Agenda.AdicionarEvento(evento);
                break;
            }
            else
            {
                Console.WriteLine("Data inválida. Digite novamente: ");
            }
        }
    }

    public static void ExcluirEvento()
    {
        Console.WriteLine("Digite o evento que deseja excluir: ");
        int idExcluir = Convert.ToInt32(Console.ReadLine());
        Agenda.DeletarEvento(idExcluir);
    }
}
