using System;
using System.Globalization;

class Evento
{
    //Atributos da classe Evento
    public int id { get; set; } //Declarando os m�todos get e set - ID.
    public DateTime Data { get; set; } //Declarando os m�todos get e set - DATA.
    public string Descricao { get; set; } //Declarando os m�todos get e set - DESCRICAO.

    //Set dos atributos da classe evento (Set - GRAVAR)
    public Evento(int id, DateTime entradaData, string descricaoEntrada)
    {
        this.id = id;
        this.Data = entradaData;
        this.Descricao = descricaoEntrada;
    }

}