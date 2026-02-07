using ConsoleApp1TrackFit.Modelos;

namespace ConsoleApp1TrackFit.Interface;
//[ ] Mostrar os ultimos 10 treinos
//[ ] Mostrar status, data e nome do treino

internal class MenuHistorico : Menu
{
    public override void Executar()
    {
        int faixa=Treino.RetonarInteiro("Digite A quantidade de treinos");
        Historico.ExbirHistorico(faixa);
        Console.WriteLine("Aperte enter para voltar ao incio");
        Console.ReadKey();
        Console.WriteLine("saindo...");
    }
}