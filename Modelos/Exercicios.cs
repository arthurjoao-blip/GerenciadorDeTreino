using ConsoleApp1TrackFit.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime;
using System.Text;

namespace ConsoleApp1TrackFit.Modelos;

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
            $"repetição{this.quantidadeDeSerie}");
        Console.WriteLine($"Intervalo Entre serie:{this.intervaloEmSegundos} Segundos");
        Console.WriteLine("------------------------------");
    }
    internal static Exercicios EscolhendoEx(Treino t)
    {
        ListarEx(t);
        return EscolherEX(t);



    }
    internal static void ListarEx(Treino t)
    {
        int contador = 1;
        foreach(var ex in t)
        {
            Console.WriteLine($"{contador}.{ex.Nome}");
            contador++;
        }
    }
    private static Exercicios EscolherEX(Treino t)
    {
        return t.ToList()[EscolhaDeInstanciaEx(t)];
    }
    private static int EscolhaDeInstanciaEx(Treino t)
    {
        
        int escolha = Menu.Escolha(1, t.ToList().Count);
        Console.Clear();
        return escolha - 1;

    }
    public void EditarPropEx(string prop, string newValueProp)
    {
        var propertyInfo = typeof(Exercicios).GetProperty(prop);
        if (prop == null) { return; }
        propertyInfo!.SetValue(this, newValueProp);
    }
}
