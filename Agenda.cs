using System;
using System.Collections.Generic;

class Agenda {
    List<Evento> eventos = new List<Evento>();

    public void AdicionarEvento(Evento e) {
        eventos.Add(e);
    }

    public void ListarEventos() {
        int index = 1;
        Console.WriteLine("");
        foreach (Evento e in this.eventos) {
            Console.Write($"{index}) "); e.PrintEvento();
            Console.WriteLine("");
            index++;
        }
    }

    public void ExcluirEvento(int excluir) {
        int index = 1;
        foreach (Evento i in eventos) {
            if (index == excluir) {
                eventos.Remove(i);
                break;
            }
            index++;
        }
    }
}
