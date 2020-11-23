using System;
using System.Collections.Generic;

namespace ProjetoAgenda {
    class Program {
        static void Main(string[] args) {
            Agenda agenda = new Agenda();
            bool MostrarMenu = true;
            short MenuChoice = 0;
            while (MostrarMenu) {
                Console.WriteLine("---- Projeto Agenda ----");
                Console.WriteLine("Digite os números a esquerda para navegar o menu:");
                Console.WriteLine("1 - Listar datas.");
                Console.WriteLine("2 - Criar evento.");
                Console.WriteLine("3 - Excluir evento.");
                Console.WriteLine("4 - Sair.");
                MenuChoice = Convert.ToInt16(Console.ReadLine());
                if (MenuChoice == 1) {
                    agenda.ListarEventos();
                } else if (MenuChoice == 2) {
                    CriarEvento(agenda);
                } else if (MenuChoice == 3) {
                    ExcluirEvento(agenda);
                } else if (MenuChoice == 4) {
                    MostrarMenu = false;
                } else Console.WriteLine("Digite uma opção válida.");
            }
        }

        static void ListarDatas(Agenda agenda) {
            agenda.ListarEventos();
        }

        static void CriarEvento(Agenda agenda) {
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
                agenda.AdicionarEvento(novo);
            } catch {
                Console.WriteLine("Você digitou algum valor incorreto, tente novamente.");
            }
        }

        static void ExcluirEvento(Agenda agenda) {
            Console.WriteLine("Digite o evento que deseja excluir: ");
            int excluir = Convert.ToInt32(Console.ReadLine());
            agenda.ExcluirEvento(excluir);
        }
    }
}
