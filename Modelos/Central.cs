using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp1TrackFit.Modelos;

internal class Central : IEnumerable<Treino>
{

    public static List <Treino> listaDeTreinos = [];

    public IEnumerator<Treino> GetEnumerator()
    {
        foreach(var t in listaDeTreinos) yield return t;
    }

    
    public static void Add(Treino t)
    {
        listaDeTreinos.Add(t);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)listaDeTreinos).GetEnumerator();
    }
    // Ao adicionar isso no fim do sistema, tem que excluir atualização no meio do sistema
    //pois torna redundante ( para essa aplicação)
    public static void AtualizarTreino(StreamWriter stream)
    {
        foreach(var t in listaDeTreinos)
        {
            stream.WriteLine($"{t.Nome};{t.Modalidade};{t.ritmo}");
            stream.Flush();
        }
    }
    public static void AtualizarEx(StreamWriter stream)
    {
        foreach (var t in listaDeTreinos)
        {
            List<string> listaDeExercicio = t.SalvarTreinoNoTxt();
            foreach (var mensagem in listaDeExercicio)
            {
                stream.WriteLine(mensagem);
                stream.Flush();
            }
        }
    }
    
    public static void Remover(Treino t )
    {
        listaDeTreinos.Remove(t);
    }
}

