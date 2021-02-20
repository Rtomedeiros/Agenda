using System;
using System.Globalization;

class Evento
{
    public int id { get; set; }
    public DateTime Data { get; set; }
    public string Descricao { get; set; }

    public Evento(int id, DateTime entradaData, string descricaoEntrada)
    {
        this.id = id;
        this.Data = entradaData;
        this.Descricao = descricaoEntrada;
    }

    public override string ToString()
    {
        CultureInfo pt = new CultureInfo("pt-BR");
        return $"Data: {this.Data.ToString(pt.DateTimeFormat.ShortDatePattern, pt)}. Evento: {this.Descricao}";
    }
}