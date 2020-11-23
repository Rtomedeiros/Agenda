using System;

class Evento
{
    DateTime Data = new DateTime();
    string Descricao;

    public Evento(DateTime entradaData, string descricaoEntrada)
    {
        this.Data = entradaData;
        this.Descricao = descricaoEntrada;
    }   

    public void PrintEvento()
    {   
        Console.Write($"Data: {this.Data.ToShortDateString()}. Evento: {this.Descricao}");
    }
}