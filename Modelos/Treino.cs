using ConsoleApp1TrackFit.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleApp1TrackFit.Modelos;

internal partial class Treino : IEnumerable<Exercicios>
{
    public List<Exercicios> listaDeExercicio = [] ;
    public int quantidadeDeExercicio;
    public string Nome { get; set; }
    public string Modalidade { get; set; }
    public string ritmo { get; set; }

    public Treino(string Nome, string Modalidade, string ritmo, int tipo)
    {
        this.Nome = Nome;
        this.Modalidade = Modalidade;
        this.ritmo = ritmo;
        if (tipo == 1) { CriarTreino(); }
    }

    public void ExibirTreino()
    {
        foreach (Exercicios t in this)
        {
            t.ListarPropriedades();
        }
    }
    public  void CriarTreino()
    {
        Menu.Nomear("Criando Exercícios");
        while (true)
        {
            Console.Clear();
            Console.WriteLine("[1] Adicionar Exercícios");
            Console.WriteLine("[2] Finalizar Treino");
            Console.WriteLine("[3] Cancelar Treino");
            int escolha;
            escolha = EscolhaDeCriacaoDeTreino();
            if (escolha == 2)
            {
                Central.Add(this);
                Console.WriteLine("Saindo...."); break;
            }
            else if (escolha==3){ break; }
            else { CriandoExercicio(); }

        }


    }

    public IEnumerator<Exercicios> GetEnumerator()
    {
        foreach (var ex in listaDeExercicio) yield return ex;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public static void CarregarTreinoSalvos( StreamReader stream)
    {
        //Treino 1; Musculação; Leve
        while (!stream.EndOfStream)
        {
            var linha =stream.ReadLine();
            if (linha != null)
            {
                var prop = linha.Split(';');
                Central.Add(new Treino(prop[0], prop[1], prop[2],0));
            }
        }
    }
    public static void CarregarExercicioSalvos( StreamReader stream)
    {
        while (!stream.EndOfStream)
        {
            //musculação;leve;12;4;Supino reto ;100;musculação;0
            var linha = stream.ReadLine();
            var prop = linha!.Split(';');
            var c = new Central().ToList();
            c[int.Parse(prop[7])].Add(new Exercicios(prop[0], prop[1], int.Parse(prop[2]), 
                int.Parse(prop[3]), c[int.Parse(prop[7])],
                prop[4], int.Parse(prop[5]), prop[6]));
        }
    }
    public void Add(Exercicios ex)
    {
        this.listaDeExercicio.Add(ex);
    }
    public void Remover(Exercicios ex)
    {
        this.listaDeExercicio.Remove(ex);
    }
}
