namespace FuncionarioApi.Models
{
  public class Estagiario : Funcionario
  {
    public int HorasPorSemana { get; set; }

    public override string ShowInfo()
    {
      return base.ShowInfo() + $", Horas por Semana: {HorasPorSemana}";
    }
  }
}
