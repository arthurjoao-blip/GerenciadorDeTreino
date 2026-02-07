using ConsoleApp1TrackFit.Interface;
using ConsoleApp1TrackFit.Modelos;
using System.Runtime.CompilerServices;

namespace ConsoleApp1TrackFit;

internal class Program
{
    public static List<Treino> ListaDeTreinos = new List<Treino>();
    static void Main(string[] args)
    {
        Historico.CarregarTreino();
        using (var fluxoDeArquivo = new FileStream("Treinos.txt", FileMode.Open))
        using (var streamTreino = new StreamReader(fluxoDeArquivo))
            Treino.CarregarTreinoSalvos(streamTreino);
        using (var fluxoDeArquivo = new FileStream("Exercicio.txt", FileMode.Open))
        using (var streamExercicio = new StreamReader(fluxoDeArquivo))
            Treino.CarregarExercicioSalvos(streamExercicio);


        Dictionary<int, Menu> OpcaoDeMenu=new Dictionary<int, Menu>();
        OpcaoDeMenu.Add(1, new MenuCriar());
        OpcaoDeMenu.Add(2, new MenuEditar());
        OpcaoDeMenu.Add(3, new MenuExibir());
        OpcaoDeMenu.Add(4, new MenuIniciar());
        OpcaoDeMenu.Add(5, new MenuHistorico());
        OpcaoDeMenu.Add(6, new MenuExcluir());
        while (true)
        {
            Console.Clear();
            Menu.Iniciando();
            int escolha = Escolha();
            if (escolha == 0) { break; }

            OpcaoDeMenu[escolha].Executar();

        }
        File.Delete("Treinos.txt");
        using (var fluxoDeArquivo = new FileStream("Treinos.txt", FileMode.Create))
        using (var streamTreino = new StreamWriter(fluxoDeArquivo))
            Central.AtualizarTreino(streamTreino);
        File.Delete("Exercicio.txt");
        using (var fluxoDeArquivo = new FileStream("Exercicio.txt", FileMode.Create))
        using (var streamEx = new StreamWriter(fluxoDeArquivo))
            Central.AtualizarEx(streamEx);


        Console.WriteLine("Saindo...");
    }
    internal static int Escolha()
    {
        while (true)
        {
            try
            {
                int escolha = int.Parse(Console.ReadLine()!);
                if (escolha >= 0 && escolha < 7)
                {
                    return escolha;
                }
                Console.WriteLine("Escolha invalido");
            }
            catch
            {
                Console.WriteLine("Escolha invalido");
            }
            Console.Clear();
        }
        
    }
}
 



