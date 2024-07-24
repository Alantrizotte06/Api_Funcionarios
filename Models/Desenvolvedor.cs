namespace FuncionarioApi.Models
{
  public class Desenvolvedor : Funcionario
  {
    public string LinguagemDeProgramacao { get; set; }

    public override string ShowInfo()
    {
      return base.ShowInfo() + $", Linguagem de Programação: {LinguagemDeProgramacao}";
    }
  }
}
