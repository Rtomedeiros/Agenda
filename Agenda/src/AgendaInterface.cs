using System;
using System.Collections.Generic;

static class AgendaInterface
{
    //Classe Agenda
    public static List<Evento> eventos = new List<Evento>();

    //Método Adicionar evento
    public static void AdicionarEvento(Evento e)
    {
        eventos.Add(e);
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
}
