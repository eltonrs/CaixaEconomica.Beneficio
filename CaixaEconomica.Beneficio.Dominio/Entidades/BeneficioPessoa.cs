using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEconomica.Beneficio.Dominio.Entidades
{
  // relacionamento entre Pessoa e Beneficio
  public class BeneficioPessoa : Entidade
  {
    public int BeneficioId { get; set; }
    public int PessoaId { get; set; }
    public DateTime DataInicioBeneficio { get; set; } // do beneficio da pessoa em si
    public DateTime DataTerminoBeneficio { get; set; } // do beneficio da pessoa em si
    public decimal ValorBeneficio { get; set; }

    public void SetPessoa(Pessoa pessoa)
    {
      if (pessoa != null)
        PessoaId = pessoa.Id;
    }
    
    public void SetBeneficio(Beneficio beneficio)
    {
      if (beneficio != null)
        BeneficioId = beneficio.Id;
    }
  }
}
