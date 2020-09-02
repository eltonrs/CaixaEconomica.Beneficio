using System;

namespace CaixaEconomica.Beneficio.Dominio.Entidades
{
  public class Beneficio : Entidade
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataInicioVigencia { get; set; } // do cadastro do beneficio no sistema
    public DateTime? DataTerminoVigencia { get; set; } // do cadastro do beneficio no sistema
    public bool Ativo { get; set; }
  }
}
