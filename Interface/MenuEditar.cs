using ConsoleApp1TrackFit.Modelos;
using System.Xml;

namespace ConsoleApp1TrackFit.Interface;

internal class MenuEditar : Menu
{

    public override void Executar()
    {
        var t = EscolherTreino();
        Opcao();
        int escolha =Escolha(1, 3);
        if (escolha == 3) return;
        if (escolha == 1) EditandoTreino(t);
        if (escolha == 2) EditandoEx(t);
    }

    private void Opcao()
    {
        Console.WriteLine("[1]Editar Treino");
        Console.WriteLine("[2]Editar Exercicio");
        Console.WriteLine("[3]Voltar ao inicio");
    }
    private void EditandoTreino(Treino t)
    {
        Console.WriteLine("[1]Excluir Treino");
        Console.WriteLine("[2]Editar Propriedade");
        Console.WriteLine("[3]Editar Adicionar Exercico"); // não funciona
        Console.WriteLine("[4]Voltar ao inicio");
        int escolha = Escolha(1, 3);
        if (escolha == 4) return;
        if (escolha == 1)
        {
            Console.WriteLine($"Ecluindo...");
            Central.Remover(t);
            var editor = new MenuEditar();
            editor.Executar();
        }
        if (escolha == 2)
        {
            string? prop=EscolhendoPropTreino();
            if (prop== null)
            {
                Console.WriteLine("Saindo...");
                return;
            }
            string newValue = Treino.RetornarString(prop);
            t.EditarPropTreino(prop, newValue);
        }
    }
    private static void EditandoEx(Treino t)
    {
        var ex = Exercicios.EscolhendoEx(t);
        Console.WriteLine("[1]Editar Propriedades");
        Console.WriteLine("[2]Excluir Exercicios");
        Console.WriteLine("[3]Voltar ao inicio");
        int escolha=Escolha(1, 3);
        if (escolha == 3) return;
        else if (escolha == 1) 
        {
            string? prop = EscolhendoPropEx();
            if (prop == null)
            {
                Console.WriteLine("Saindo...");
                return;
            }
            string newValue = Treino.RetornarString(prop);
            ex.EditarPropEx(prop, newValue);
        }
        else if (escolha == 2) 
        {
            t.Remover(ex);
            t.quantidadeDeExercicio = t.quantidadeDeExercicio - 1;
        }
    }
    private static string? EscolhendoPropTreino()
    {
        Console.WriteLine("[1] Editar Nome");
        Console.WriteLine("[2] Editar Modalidade");
        Console.WriteLine("[3] Editar ritmo");
        Console.WriteLine("[4] voltar");
        int escolha=Escolha(1, 4);
        switch (escolha){
            case 1: return "Nome";
            case 2: return "Modalidade";
            case 3: return "ritmo";
            case 4: return null;
        }
        return null;
    }
    private static string? EscolhendoPropEx()
    {
        Console.WriteLine("[1] Editar Nome");
        Console.WriteLine("[2] Editar Grupo Muscular");
        Console.WriteLine("[3] Editar quantidade De Repetição ");
        Console.WriteLine("[4] Editar quantidade De Series ");
        Console.WriteLine("[5] Editar intervalo Em Segundos");
        Console.WriteLine("[6] voltar");
        int escolha = Escolha(1, 6);
        switch (escolha)
        {
            case 1: return "Nome";
            case 2: return "GrupoMuscular";
            case 3: return "quantidadeDeRepeticao";
            case 4: return "quantidadeDeSerie";
            case 5: return "intervaloEmSegundos";
            case 6: return null;
        }
        return null;
    }
}