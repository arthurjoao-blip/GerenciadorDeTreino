using System.Xml;

namespace ConsoleApp1TrackFit.Interface;

internal class MenuEditar : Menu
{
    //[ ]Exibir listra de treinos 
    //[ ]Escolher treino para editar
    //[ ]Escolher Se o que quer mudar
    //[ ]Propriedades do treino
    //[ ]Excluir ou adicioanr treino
    //[ ]Editar Treino existente
    //[ ]Sair
    public override void Executar()
    {
        var t = EscolherTreino();
        Opcao();
        int escolha =Escolha(1, 3);
        if (escolha == 3) return;
        if (escolha == 1) EditandoTreino();
        if (escolha == 2) EditandoTreino();
    }

    private void Opcao()
    {
        Console.WriteLine("[1]Editar Treino");
        Console.WriteLine("[2]Editar Exercicio");
        Console.WriteLine("[3]Voltar ao inicio");
    }
    private void EditandoTreino()
    {

    }
}