using System.ComponentModel.DataAnnotations;

namespace FuncionarioApi.Models
{
  public class FuncionarioRequest
  {
    [Required]
    public string Discriminator { get; set; }

    [Required]
    public string Cpf { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Departamento { get; set; }

    [Required]
    public double Salario { get; set; }

    // Propriedades específicas de cada tipo de funcionário
    public double? Bonificacao { get; set; }
    public string? LinguagemDeProgramacao { get; set; }
    public int? HorasPorSemana { get; set; }
  }
}
