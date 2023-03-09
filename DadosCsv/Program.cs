//Como ler e Gravar dados CSV com C#

//1° - Instalar o pacote CSVHelper

//2° - Criar uma classe que vai representar os dados que vão estar dentro do arquivo (Venda)

//3° - Realizar o mapeando utilizando anotações na classe venda ou você pode criar um outra classe para fazer o mapeamento com ClassMap<> do CsvHelper.Configuration;

//4° - vamos configurar CSVConfiguration
using CsvHelper;
using CsvHelper.Configuration;
using DadosCsv;
using System.Globalization;

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    HasHeaderRecord = true,//Pegar informação da primeira linha do arquivo(cabeçalho)
};

List<Venda> vendas;

using (var reader = new StreamReader("../../../Data.csv"))
using (var csv = new CsvReader(reader, config))
{
    csv.Context.RegisterClassMap<VendaMap>();

    vendas = csv.GetRecords<Venda>().ToList();

    foreach (var venda in vendas)
    {
        Console.WriteLine($"Cliente:{venda.NomeCliente}, Pacote:{venda.NomePacote}");
    }


}

using (var writer = new StreamWriter("dados_vendas.csv"))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.Context.RegisterClassMap<VendaMap>();

    csv.WriteHeader<Venda>();// Escrever o cabeçalho

    csv.NextRecord();// Avançar em uma linha

    csv.WriteRecords(vendas);//Escrever em um novo arquivo
}



Console.Read();