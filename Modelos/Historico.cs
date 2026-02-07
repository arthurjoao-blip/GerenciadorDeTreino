using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1TrackFit.Modelos;

internal class Historico : IEnumerable<PlayerDeTreino>
{
    public static void ExbirHistorico(int QuantidadeDeTreinos)
    {
        var historico = new Historico();
        var listaDeTreinos = historico.ToList();
        if (QuantidadeDeTreinos < listaDeTreinos.Count)
        {
            foreach (var player in listaDeTreinos.Take(QuantidadeDeTreinos))
            {
                player.Exibir();
                Console.WriteLine("Aperte enter para continar");

                Console.ReadKey();

            }
        }
        else
        {
            foreach (var player in listaDeTreinos)
            {
                player.Exibir();
                Console.WriteLine("Aperte enter para continar");
                Console.ReadKey();

            }
        }
    }
    public static Stack<PlayerDeTreino> HistoricoDeTreino = [];
    public IEnumerator<PlayerDeTreino> GetEnumerator()
    {
        foreach (var player in HistoricoDeTreino)
        {
            yield return player;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    internal static void Add(PlayerDeTreino pt)
    {
        HistoricoDeTreino.Push(pt);
    }
    internal static void SalvarHistorico()
    {
        string Acesso = "Historico.txt";
        File.Delete(Acesso);
        using (var fluxoDeArquivo = new FileStream(Acesso, FileMode.OpenOrCreate))
        using (var stream = new StreamWriter(fluxoDeArquivo))
        {
            foreach(var item in HistoricoDeTreino)
            {
                int posicaoTreino = item.TreinoAtual.PosiçãoIntancia();
                int posicaoEx = 0;
                foreach (var key in item.player.Keys.ToList())
                {
                    stream.WriteLine($"{key.Nome};{item.player[key]};{key.quantidadeDeSerie};{posicaoTreino};{posicaoEx}");
                    posicaoEx++;
                }
            }
        }
    }
    internal static void CarregarTreino()
    {
        string Acesso = "Historico.txt";
        using (var fluxoDeArquivo = new FileStream(Acesso, FileMode.OpenOrCreate))
        using (var stream = new StreamReader(fluxoDeArquivo))
        {
            while (!stream.EndOfStream) 
            {
                var linhaTexto = stream.ReadLine();

                if (!string.IsNullOrWhiteSpace(linhaTexto))
                {
                    var colunas = linhaTexto.Split(';');

                    var c = new Central();
                    if (int.TryParse(colunas[3], out int indice))
                    {
                        var entidade = c.ElementAtOrDefault(indice);
                        if (entidade != null)
                        {
                            var player = new PlayerDeTreino(entidade);
                            HistoricoDeTreino.Push(player);
                            player.player.Add(entidade.ToList()[int.Parse(colunas[4])], int.Parse(colunas[1]));
                        }
                    }
                }
            }
        }

    }

}
