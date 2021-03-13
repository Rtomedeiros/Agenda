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
        eventos.ForEach(x => Console.Write($"[{eventos.IndexOf(x) + 1}] {x.ToString()}\n"));
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
        if (index < 1 || index > eventos.Count)
        { // [0] [1]
            Console.WriteLine("Este evento não existe.1");
            return;
        }
        Evento deletar = eventos[index - 1];
        if (deletar == null)
        {
            Console.WriteLine("Este evento não existe.2");
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
        //Console.WriteLine("\nEvento excluido com sucesso!");
        Console.WriteLine("Pressione QQUER TECLA para voltar ao menu.");
        Console.ReadKey();
        Console.Clear();
    }

    //Método Mudar Tema (Esquema de cores do console)
    public static void MudarTema()
    {
        Console.WriteLine("1- Tema Padrão - Fundo Preto e letras brancas.");
        Console.WriteLine("2- Tema Claro  - Fundo Branco e letras azuis.");
        Console.WriteLine("Digite o número abaixo para escolher o tema: ");
        if (!Int16.TryParse(Console.ReadLine(), out short TemaChoice)) //Condição para verificar se o número digitado está dentro das opções.
        {
            Console.WriteLine("Digite uma opção válida."); //Caso o nº digitado não esteja dentro das opções, mostrar esta mensagem.
            Console.Clear();
        }
        if (TemaChoice == 1)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        else if (TemaChoice == 2)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Digite uma opção válida.");
            Console.WriteLine("Pressione QQUER TECLA para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        //Console.ForegroundColor = ConsoleColor.Black;
        //Console.BackgroundColor = ConsoleColor.White;
        //Console.Clear();
    }


}
