//[ ] Iniciar um treino
//[ ] Ir percorrendo Exercicios dentro do Treino
//[ ] Só passar quando estiver Recebido que concluiu
//[ ] Ter a opção de finalizar a qualquer momento
//[ ] passar um dicionario de treino, e dizer se foi feito ou não dicionario<Treino,string> 
//[ ] Criar uma classe historico que salva os player de treino
using ConsoleApp1TrackFit.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime;
using System.Text;

namespace ConsoleApp1TrackFit.Modelos;

internal class PlayerDeTreino
{
    public Dictionary<Exercicios, int> player = new Dictionary<Exercicios, int>();
    public Treino TreinoAtual;

    public PlayerDeTreino(Treino t)
    {
        TreinoAtual = t;
    }

    internal void IniciarTreino()
    {
        foreach (var ex in TreinoAtual.ToList())
        {
            int verificador = 0;
            player.Add(ex, 0);
            while (verificador != ex.quantidadeDeSerie)
            {

                Console.WriteLine($"{ex.Nome}");
                Console.WriteLine($"Series: {verificador}/{ex.quantidadeDeSerie}");
                Console.WriteLine("Se Quiser sair, aperte 1");
                Console.WriteLine("Se Quiser continuar , aperte enter");
                string escolha = Console.ReadLine()!;
                if (escolha =="1")
                {
                    return;
                }
                Console.Clear();
                verificador++;
                player[ex] = verificador;
            }
        }
    }
    internal void Exibir()
    {
        foreach (var ex in player.Keys.ToList())
        {
            Console.WriteLine($"{ex.Nome}");
            Console.WriteLine($"Forão feitos {player[ex]}/{ex.quantidadeDeSerie}");
        }
    }
}