using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEconomica.Beneficio.Dominio.Entidades
{
  /* Implementando uma forma de evitar duplicidades de endereços na entidade Pessoa...
   * colocando ", IEquatable<tipado pela entidade>
   */
  public class Endereco : Entidade, IEquatable<Endereco>
  {
    public int Id { get; set; }
    public string Rua { get; set; }
    public int Numero { get; set; }
    /// <summary>
    /// 1: EResidencial
    /// 2: Comercial
    /// </summary>
    public int TipoEndereco { get; set; }

    // Relacionamento de 1 (endereço) para 1 (pessoa)

    /* 1ª forma 
     * Leitura:
     * Da forma como está abaixo, o EF entende que há um relacionamento entre Endereco e Pessoa
     * e preenche o objeto Pessoa com a instância correta
     */
    public int PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }

    public bool Equals(Endereco other) // veio da interface IEquatable
    {
      return Id.Equals(other.Id);
    }

    public override int GetHashCode() // sobrescrevo esse método para indicar qual a propriedade eu quero verificar a duplicidade
    {
      return Id.GetHashCode(); // não deveria ser somente "return GetHashCode();", ou seja, o hash da classe (this)?
    }

    public bool ValidarPropriedades()
    {
      if (string.IsNullOrEmpty(Rua))
        NotificacaoDominio.AdicionarErro("Rua deve ser preenchida.");

      if (Numero <= 0)
        NotificacaoDominio.AdicionarErro("Número deve ser preenchido.");

      return NotificacaoDominio.Validar();
    }
  }
}
