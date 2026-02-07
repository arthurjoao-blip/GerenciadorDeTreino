using ConsoleApp1TrackFit.Modelos;

namespace ConsoleApp1TrackFit.Interface;
//[ ] Iniciar o player
//[ ] E sair

internal class MenuIniciar : Menu
{ 
    public override void Executar()
    {
        Treino t = EscolherTreino();
        var player =new PlayerDeTreino(t);
        player.IniciarTreino();
        Historico.Add(player);
        Historico.SalvarHistorico();
    }




}
