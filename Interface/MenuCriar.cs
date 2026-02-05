using ConsoleApp1TrackFit.Modelos;
using Microsoft.VisualBasic;
using System.Globalization;

namespace ConsoleApp1TrackFit.Interface;

internal class MenuCriar : Menu
{
    public override void Executar()
    {
        Console.Clear();
        Menu.Nomear("Criar Treino");
        string nome = Treino.RetornarString("Digite o Nome: ");
        string modalidade = Treino.RetornarString("Digite a Modalidade");
        string ritmo = Treino.RetornarString("Digite o ritmo do seu treino");
        Console.Clear();
        var instancia = new Treino(nome, modalidade, ritmo,1);
    }
    
}