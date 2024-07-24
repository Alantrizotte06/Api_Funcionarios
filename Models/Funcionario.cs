using System.ComponentModel.DataAnnotations;

namespace FuncionarioApi.Models
{
  public class Funcionario
  {
    [Key]
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public string Departamento { get; set; }
    public double Salario { get; set; }

    public virtual string ShowInfo()
    {
      return $"CPF: {Cpf}, Nome: {Nome}, Departamento: {Departamento}, Salário: {Salario:C}";
    }
  }
}
