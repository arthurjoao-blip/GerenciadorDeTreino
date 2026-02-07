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
        if (!File.Exists(Acesso)) return;

        var c = new Central();
        var listaCentral = c.ToList();

        using (var stream = new StreamReader(new FileStream(Acesso, FileMode.Open)))
        {
            PlayerDeTreino playerAtual = null;
            int ultimoIndiceTreinoNoArquivo = -1;

            while (!stream.EndOfStream)
            {
                var linhaTexto = stream.ReadLine();
                if (string.IsNullOrWhiteSpace(linhaTexto)) continue;

                var colunas = linhaTexto.Split(';');

                // colunas[3] é o índice do Treino na Central
                // colunas[4] é o índice do Exercício dentro do Treino
                int idTreino = int.Parse(colunas[3]);
                int idExercicio = int.Parse(colunas[4]);
                int seriesFeitas = int.Parse(colunas[1]);

                // Se mudou o ID do treino, significa que começamos um novo bloco de exercícios de outro treino
                if (idTreino != ultimoIndiceTreinoNoArquivo)
                {
                    var treinoBase = listaCentral.ElementAtOrDefault(idTreino);
                    if (treinoBase != null)
                    {
                        playerAtual = new PlayerDeTreino(treinoBase);
                        HistoricoDeTreino.Push(playerAtual);
                        ultimoIndiceTreinoNoArquivo = idTreino;
                    }
                }

                // Adiciona o exercício ao player que acabamos de criar/recuperar
                if (playerAtual != null)
                {
                    // Pega o exercício da lista do TreinoAtual
                    var exercicio = playerAtual.TreinoAtual.ToList().ElementAtOrDefault(idExercicio);
                    if (exercicio != null)
                    {
                        // Se o exercício já existir (por erro no arquivo), ele sobrescreve, senão adiciona
                        playerAtual.player[exercicio] = seriesFeitas;
                    }
                }
            }
        }
    }

}
