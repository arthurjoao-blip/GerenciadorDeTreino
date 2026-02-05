using ConsoleApp1TrackFit.Modelos;
using System.Collections;

namespace ConsoleApp1TrackFit.Interface;

internal class MenuExibir : Menu
{
    public override void Executar()
    {
        Console.Clear();
        int i = 1;
        var c = new Central();
        Opcao();
        int escolha = Escolha(1, 2);
        if (escolha == 2)
        {
            return;
        }
        foreach (var item in c)
        {
            Console.WriteLine($"{i}.{item.Nome}");
            i++;
        }
        var instancia = EscolherTreino();
        Console.Clear();
        instancia.ExibirTreino(); 
        Console.WriteLine("Digite algo para voltar para o inicio...");
        Console.ReadKey();
        Console.Clear();


    }

    private static void Opcao()
    {
        Console.WriteLine("[1] Ver Treino");
        Console.WriteLine("[2] Voltar Para o inicio");
    }



}