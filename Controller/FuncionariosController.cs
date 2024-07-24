using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FuncionarioApi.Data;
using FuncionarioApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuncionarioApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class FuncionariosController : ControllerBase
  {
    private readonly FuncionarioContext _context;

    public FuncionariosController(FuncionarioContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Get()
    {
      return await _context.Funcionarios.ToListAsync();
    }

    [HttpGet("{cpf}")]
    public async Task<ActionResult<Funcionario>> Get(string cpf)
    {
      var funcionario = await _context.Funcionarios.FindAsync(cpf);
      if (funcionario == null)
      {
        return NotFound();
      }
      return funcionario;
    }

    [HttpPost]
    public async Task<ActionResult<Funcionario>> Post([FromBody] FuncionarioRequest request)
    {
      Funcionario funcionario;

      switch (request.Discriminator)
      {
        case "Gerente":
          funcionario = new Gerente
          {
            Cpf = request.Cpf,
            Nome = request.Nome,
            Departamento = request.Departamento,
            Salario = request.Salario,
            Bonificacao = request.Bonificacao ?? 0
          };
          break;
        case "Desenvolvedor":
          funcionario = new Desenvolvedor
          {
            Cpf = request.Cpf,
            Nome = request.Nome,
            Departamento = request.Departamento,
            Salario = request.Salario,
            LinguagemDeProgramacao = request.LinguagemDeProgramacao
          };
          break;
        case "Estagiario":
          funcionario = new Estagiario
          {
            Cpf = request.Cpf,
            Nome = request.Nome,
            Departamento = request.Departamento,
            Salario = request.Salario,
            HorasPorSemana = request.HorasPorSemana ?? 0
          };
          break;
        default:
          return BadRequest("Tipo de funcionário inválido");
      }

      _context.Funcionarios.Add(funcionario);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(Get), new { cpf = funcionario.Cpf }, funcionario);
    }

    [HttpPut("{cpf}")]
    public async Task<IActionResult> Put(string cpf, FuncionarioRequest request)
    {
      var funcionario = await _context.Funcionarios.FindAsync(cpf);
      if (funcionario == null)
      {
        return NotFound();
      }

      funcionario.Nome = request.Nome;
      funcionario.Departamento = request.Departamento;
      funcionario.Salario = request.Salario;

      if (funcionario is Gerente gerente && request.Discriminator == "Gerente")
      {
        gerente.Bonificacao = request.Bonificacao ?? 0;
      }
      else if (funcionario is Desenvolvedor desenvolvedor && request.Discriminator == "Desenvolvedor")
      {
        desenvolvedor.LinguagemDeProgramacao = request.LinguagemDeProgramacao;
      }
      else if (funcionario is Estagiario estagiario && request.Discriminator == "Estagiario")
      {
        estagiario.HorasPorSemana = request.HorasPorSemana ?? 0;
      }
      else
      {
        return BadRequest("Discriminator mismatch");
      }

      _context.Entry(funcionario).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }

    [HttpDelete("{cpf}")]
    public async Task<IActionResult> Delete(string cpf)
    {
      var funcionario = await _context.Funcionarios.FindAsync(cpf);
      if (funcionario == null)
      {
        return NotFound();
      }

      _context.Funcionarios.Remove(funcionario);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
