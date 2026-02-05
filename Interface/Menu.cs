using ConsoleApp1TrackFit.Modelos;
using System.Numerics;

namespace ConsoleApp1TrackFit.Interface;

internal class Menu
{
    public virtual void  MostrarTreinos(Central c)
    {
        int laco = 1;
        
        foreach (var treino in c) 
        {
            Console.WriteLine($"{laco}.{treino.Nome}");
            laco++;
        }
    }
    public virtual void Executar()
    {
        
    }
    public static void Iniciando()
    {
        Console.WriteLine("[1] Criar Treino");
        Console.WriteLine("[2] Editar Treino");
        Console.WriteLine("[3] Ver Treino");
        Console.WriteLine("[4] Iniciar Treino");
        Console.WriteLine("[5] Histórico De Treino");
        Console.WriteLine("[6] Excluir Treino");
        Console.WriteLine("[0] Sair");
    }
    public static void Nomear(string Titulo)
    {
        for (int i = 0; i < Titulo.Length; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine("");
        Console.WriteLine(Titulo);
        for (int i = 0; i < Titulo.Length; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine("");
    }

    public Treino EscolherTreino()
    {
        var c = new Central();
        return c.ToList()[EscolhaDeInstanciaTreino(c.ToList())];
    }
    public static int EscolhaDeInstanciaTreino(List<Treino> lista)
    {
        Console.Clear();
        ExibirTreinos(lista);
        int escolha = Escolha(1, lista.Count);
        return escolha - 1;
    }
    public static void ExibirTreinos(List<Treino> lista)
    {
        int i = 1;
        foreach (var item in lista)
        {
            Console.WriteLine($"{i}.{item.Nome}");
            i++;
        }
    }
    public static int Escolha(int menor, int maior)
    {
        while (true)
        {
            int escolha = Treino.RetonarInteiro("Digite A Sua Escolha");
            if (escolha >= menor && escolha <= maior) { return escolha; }

        }

    }
}