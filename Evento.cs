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

    public override string ToString()
    {
        return $"Data: {this.Data.ToShortDateString()}. Evento: {this.Descricao}";
    }
}