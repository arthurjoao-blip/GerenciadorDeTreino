using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace ConsoleApp1TrackFit.Modelos;

internal  partial class Treino
{
    private static int EscolhaDeCriacaoDeTreino()
    {
        while (true)
        {
            try
            {
                int escolha = int.Parse(Console.ReadLine()!);
                if (escolha == 1 || escolha == 2 || escolha == 3)
                {
                    return escolha;
                }
                else
                {
                    Console.WriteLine("Escolha fora da faixa");
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
            }
        }
    }
    private void CriandoExercicio()
    {
        Console.Clear();
        string nome = RetornarString("Nome do exercicio");
        string GrupoMuscular = RetornarString("Nome do Grupo Muscular");
        string ritmo = RetornarString("Digite Ritmo");
        string Modalidade = RetornarString("Digite Modalidade");
        int intervalo = RetonarInteiro("Digite o intervalo");
        int serie = RetonarInteiro("Digite a quantidade de serie");
        int repeticao = RetonarInteiro("digite a quantidade de repetição");
        this.Add(new Exercicios(ritmo, Modalidade, repeticao, serie, this, nome, intervalo, GrupoMuscular));

    }
    public static string RetornarString(string titulo)
    {
        while (true)
        {
            Console.WriteLine($"Digite {titulo}:");
            try
            {
                return (Console.ReadLine()!);
            }
            catch
            {
                Console.WriteLine($"{titulo} invalido");
            }
        }
    }
    public static int RetonarInteiro(string titulo)
    {
        while (true)
        {
            Console.WriteLine($"Digite {titulo}:");
            try
            {
                return int.Parse(Console.ReadLine()!);
            }
            catch
            {
                Console.WriteLine($"{titulo} invalido");
            }
        }
    }
    public List<string> SalvarTreinoNoTxt()
    {
        List<string> list = new List<string>();
        foreach (var ex in listaDeExercicio)
        {
            
            string mensagem = $"{ex.ritmo};{ex.Modalidade};{ex.quantidadeDeRepeticao};{ex.quantidadeDeSerie};{ex.Nome};{ex.intervaloEmSegundos};{ex.GrupoMuscular};{PosiçãoIntancia()}";
            list.Add(mensagem);
        }
        return list;
    }

    public int PosiçãoIntancia()
    {
        var c = new Central();
        return c.ToList().IndexOf(this);

    }
}