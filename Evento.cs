using System;
using System.Globalization;

class Evento
{
    //Atributos da classe Evento
    public int id { get; set; } //Declarando os métodos get e set - ID.
    public DateTime Data { get; set; } //Declarando os métodos get e set - DATA.
    public string Descricao { get; set; } //Declarando os métodos get e set - DESCRICAO.

    //Set dos atributos da classe evento (Set - GRAVAR)
    public Evento(int id, DateTime entradaData, string descricaoEntrada)
    {
        this.id = id;
        this.Data = entradaData;
        this.Descricao = descricaoEntrada;
    }

    //Get dos atributos da classe evento (Get - PEGAR)
    public override string ToString()
    {
        CultureInfo pt = new CultureInfo("pt-BR");
        return $"Data: {this.Data.ToString(pt.DateTimeFormat.ShortDatePattern, pt)}. Evento: {this.Descricao}";
    }
}