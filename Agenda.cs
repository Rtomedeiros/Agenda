using System;
using System.Collections.Generic;
using System.Globalization;

static class Agenda
{
    //Classe Agenda
    static List<Evento> eventos = new List<Evento>();

    //Método Adicionar evento
    public static void AdicionarEvento(Evento e)
    {
        eventos.Add(e);
    }

    //Método Listar evento
    public static void ListarEventos()
    {
        eventos.ForEach(x => Console.Write($"[{eventos.IndexOf(x)}] {x.ToString()}\n"));
        Console.WriteLine("\nPressione QQUER TECLA para voltar ao menu.");
        Console.ReadKey();
        Console.Clear();
    }

    public static void SortByDate()
    {
        eventos.Sort((x, y) => y.Data.CompareTo(x.Data));
        eventos.Reverse();
    }

    //Método Deletar evento
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

    //Método Criar evento
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
                Console.WriteLine("\nEvento criado com sucesso!");
                Console.WriteLine("Pressione QQUER TECLA para voltar ao menu.");
                Console.ReadKey();
                Console.Clear();
                break;
            }
            else
            {
                Console.WriteLine("Data inválida. Digite novamente: ");
            }
        }
    }

    //Método Excluir evento
    public static void ExcluirEvento()
    {
        Console.WriteLine("Digite o evento que deseja excluir: ");
        int indexExcluir = Convert.ToInt32(Console.ReadLine());
        Agenda.DeletarEvento(indexExcluir);
        Console.WriteLine("\nEvento excluido com sucesso!");
        Console.WriteLine("Pressione QQUER TECLA para voltar ao menu.");
        Console.ReadKey();
        Console.Clear();
    }
}
