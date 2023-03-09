﻿using CsvHelper.Configuration.Attributes;

namespace DadosCsv
{
    public class Venda
    {
        //[Name("Id")]
        public int Id { get; set; }
        //[Name("nome_cliente")]
        public string NomeCliente { get; set; }
        //[Name("nome_pacote")]
        public string NomePacote { get; set; }
       // [Name("data_nascimento")]
        public DateTime DataNascimento { get; set; }
       // [Name("data_atendimento")]
        public DateTime DataAtendimento { get; set; }
        // [Name("cidade_estado")]
        public string CidadeEstado { get; set; }
    }
}
