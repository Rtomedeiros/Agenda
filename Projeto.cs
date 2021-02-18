using System;


namespace ProjetoAgenda {
    class Program {
        static void Main(string[] args) {
            Agenda.LoadDatabase();

            short MenuChoice = 0;
            while (true) {
                Console.WriteLine("---- Projeto Agenda ----");
                Console.WriteLine("Digite os números a esquerda para navegar o menu:");
                Console.WriteLine("1 - Listar datas.");
                Console.WriteLine("2 - Criar evento.");
                Console.WriteLine("3 - Excluir evento.");
                Console.WriteLine("4 - Sair.");
                MenuChoice = Convert.ToInt16(Console.ReadLine());
                if (MenuChoice == 1) {
                    Agenda.ListarEventos();
                } else if (MenuChoice == 2) {
                    Agenda.CriarEvento();
                } else if (MenuChoice == 3) {
                    Agenda.ExcluirEvento();
                } else if (MenuChoice == 4) {
                    break;
                } else Console.WriteLine("Digite uma opção válida.");
            }
        }
    }
}
