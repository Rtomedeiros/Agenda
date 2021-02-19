using System;

class Evento
{
    int id { get; set; }
    DateTime Data { get; set; }
    string Descricao { get; set; }

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