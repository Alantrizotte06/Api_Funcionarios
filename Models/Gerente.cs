namespace FuncionarioApi.Models
{
  public class Gerente : Funcionario
  {
    public double Bonificacao { get; set; }

    public override string ShowInfo()
    {
      return base.ShowInfo() + $", Bonificação: {Bonificacao:C}";
    }
  }
}
