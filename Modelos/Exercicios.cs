using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleApp1TrackFit.Modelos
{
    internal class Exercicios : Treino
    {
        public int quantidadeDeRepeticao { get; }
        public int quantidadeDeSerie { get; }
        public int intervaloEmSegundos { get; }
        public string GrupoMuscular { get; }
        public  int carga {  get; set; }
        

        public Exercicios(string ritmo, string modalidade, int quantidadeDeRepeticao, 
            int quantidadeDeSerie,Treino TreinoBase, string Nome,
            int intervalo, string GrupoMuscular,int tipo=0) : base(Nome,ritmo, modalidade,tipo)
        {
            this.GrupoMuscular = GrupoMuscular;
            TreinoBase.quantidadeDeExercicio++;
            this.quantidadeDeRepeticao = quantidadeDeRepeticao;
            this.quantidadeDeSerie = quantidadeDeSerie;
            this.intervaloEmSegundos = intervalo;
        }
        internal void ListarPropriedades()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"{this.Nome}");
            Console.WriteLine($"Grupo Muscular:{this.GrupoMuscular}| Ritmo{this.ritmo}");
            Console.WriteLine($"Quantidade de serie: {this.quantidadeDeSerie} | Quantidade de " +
                $"repetição{this.quantidadeDeRepeticao}");
            Console.WriteLine($"Intervalo Entre serie:{this.intervaloEmSegundos} Segundos");
            Console.WriteLine("------------------------------");

        }
    }
}
