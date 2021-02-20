using System;
using System.Collections.Generic;
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
        eventos.ForEach(x => Console.Write($"[{eventos.IndexOf(x)}] {x.ToString()}\n"));
    }

    public static void SortByDate()
    {
        eventos.Sort((x, y) => y.Data.CompareTo(x.Data));
        eventos.Reverse();
    }

    public static void DeletarEvento(int index)
    {
        Evento deletar = eventos[index];
        if (deletar == null)
        {
            Console.WriteLine("Este evento não existe.");
            return;
        }
        eventos.Remove(deletar);
        Database.DatabaseDelete(deletar);
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
                Evento novo = Database.DatabaseCreate(descricao, dataValida);
                Agenda.AdicionarEvento(novo);
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
        int indexExcluir = Convert.ToInt32(Console.ReadLine());
        Agenda.DeletarEvento(indexExcluir);
    }
}
