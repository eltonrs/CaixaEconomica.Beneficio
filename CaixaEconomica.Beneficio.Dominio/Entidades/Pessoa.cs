using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace CaixaEconomica.Beneficio.Dominio.Entidades
{
  public class Pessoa : Entidade
  {
    public int Id { get; set; }
    public string CPF { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public int Idade { get; set; }
    public int QtdeFilhos { get; set; }
    public int CodigoOcupacao { get; set; }
  }
}
