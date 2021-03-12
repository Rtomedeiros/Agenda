using System;

namespace ProjetoAgenda
{
    class Program
    {
        static void Main(string[] args)
        {
            //Carregar o Banco de Dados ao iniciar o programa
            Database.LoadDatabase();

            while (true)
            {
                //Console.ForegroundColor = ConsoleColor.Blue;
                //Console.BackgroundColor = ConsoleColor.White;
                //Console.Clear();

                //Menu Principal da Agenda
                Console.WriteLine("|----------------------------------------------------------------------------------------|");
                Console.WriteLine("|------------------------------------ AGENDA PESSOAL ------------------------------------|");
                Console.WriteLine("|----------------------------------------------------------------------------------------|");
                Console.WriteLine("| Digite os números abaixo para navegar o menu:                                          |");
                Console.WriteLine("|----------------------------------------------------------------------------------------|");
                Console.WriteLine("| 1 - LISTAR EVENTO                                                                      |");
                Console.WriteLine("| 2 - CRIAR EVENTO                                                                       |");
                Console.WriteLine("| 3 - EXCLUIR EVENTO                                                                     |");
                Console.WriteLine("| 4 - SAIR                                                                               |");
                Console.WriteLine("|----------------------------------------------------------------------------------------|");
                if (!Int16.TryParse(Console.ReadLine(), out short MenuChoice)) //Condição para verificar se o número digitado está dentro das opções.
                {
                    Console.WriteLine("Digite uma opção válida."); //Caso o nº digitado não esteja dentro das opções, mostrar esta mensagem.
                    Console.Clear();
                }
                if (MenuChoice == 1)
                {
                    Agenda.ListarEventos(); //Método para listar as anotações da agenda.
                }
                else if (MenuChoice == 2)
                {
                    Agenda.CriarEvento(); //Método para criar as anotações da agenda.
                }
                else if (MenuChoice == 3)
                {
                    Agenda.ExcluirEvento(); //Método para excluir as anotações da agenda.
                }
                else if (MenuChoice == 4)
                {
                    break; //Opção para fechar o programa.
                }
                else
                {
                    Console.WriteLine("Digite uma opção válida.");
                    Console.WriteLine("Pressione QQUER TECLA para voltar ao menu.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}