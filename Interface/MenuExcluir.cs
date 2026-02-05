using ConsoleApp1TrackFit.Modelos;

namespace ConsoleApp1TrackFit.Interface;

internal class MenuExcluir : Menu
{
    public override void Executar()
    {
        var t = EscolherTreino();
        Central.Remover(t);
        Console.WriteLine($"O {t.Nome} foi apagado");
    }
}