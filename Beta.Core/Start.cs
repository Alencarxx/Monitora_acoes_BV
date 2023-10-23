using System;
using System.Net;
using HtmlAgilityPack;

class Program
{
    static void Main()
    {
        // URL do Google Finance para ITSA3 e ITSA4 (ou outra fonte de dados)
        string itsa3Url = "https://www.google.com/finance/quote/ITSA3:BVMF";
        string itsa4Url = "https://www.google.com/finance/quote/ITSA4:BVMF";

        // Defina seu limite de diferença de preço aqui (por exemplo, 5%)
        double limiteDiferenca = 5.0;

        while (true)
        {
            // Obter os preços das ações ITSA3 e ITSA4
            double precoITSA3 = GetStockPrice(itsa3Url);
            double precoITSA4 = GetStockPrice(itsa4Url);

            // Calcular a diferença de preço em porcentagem
            double diferenca = ((precoITSA3 - precoITSA4) / precoITSA4) * 100;

            if (Math.Abs(diferenca) >= limiteDiferenca)
            {
                if (diferenca > 0)
                {
                    Console.WriteLine("Comprar ITSA3 e vender ITSA4");
                    // Coloque aqui a lógica para executar a transação de compra/venda
                }
                else
                {
                    Console.WriteLine("Comprar ITSA4 e vender ITSA3");
                    // Coloque aqui a lógica para executar a transação de compra/venda
                }
            }

            // Aguarde um tempo antes de verificar novamente (por exemplo, a cada 5 minutos)
            System.Threading.Thread.Sleep(300000); // 300000 milissegundos = 5 minutos
        }
    }

    // Função para obter o preço da ação a partir da URL (exemplo, você pode precisar implementar web scraping)
    static double GetStockPrice(string url)
    {
        using (WebClient client = new WebClient())
        {
            string html = client.DownloadString(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Implemente a lógica para extrair o preço da ação da página da web
            // Esta parte depende da estrutura da página da web do Google Finance
            // Você pode usar a biblioteca HtmlAgilityPack para facilitar o web scraping

            // Exemplo fictício de extração de preço (substitua por sua própria lógica)
            double price = 100.0;
            return price;
        }
    }
}