using System;
using System.Collections.Generic;
using System.Linq;

namespace CaixaEconomica.Beneficio.Dominio.Entidades
{
  public class Beneficio : Entidade
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataInicioVigencia { get; set; } // do cadastro do beneficio no sistema
    public DateTime? DataTerminoVigencia { get; set; } // do cadastro do beneficio no sistema
    public bool Ativo { get; set; }

    // Relacionamento 1 (Beneficio) para muitos (BeneficioPessoa). O EF vai, automaticamente, interpretar o relacionamento entre as tabelas
    private readonly HashSet<BeneficioPessoa> _beneficiosPessoa = new HashSet<BeneficioPessoa>();
    public IEnumerable<BeneficioPessoa> BeneficiosPessoa => _beneficiosPessoa.ToList().AsReadOnly();
  }
}
