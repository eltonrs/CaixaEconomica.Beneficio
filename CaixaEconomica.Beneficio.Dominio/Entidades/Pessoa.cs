using CaixaEconomica.Beneficio.Dominio.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
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

    // Relacionamento de 1 (pessoa) para muitos (endereços)

    /* Forma 1:
     * Quando coloco "virtual" o EF sobrescreve esse método, fazendo as devidas consultas no banco de dados para trazer os endereços da pessoa em específico, retornando assim a lista (enumerable) de endereços.
     * Mais simples, porém, deixa exposta a propriedade.
     
    public virtual ICollection<Endereco> Enderecos { get; set; } // qdo trabalho com ICollection (ou listas), tem que inicializar no constructor
    */

    /* Forma 2
     * 
     * trecho 1: criação de uma variável (privada e somente leitura) utilizando a classe HashSet (lista) tipada por _endereco. Dessa forma
     * a entidade não fica exposta, impedindo que tenha propriedades alteradas.
     * 
     * trecho 2: uma propriedade pública para permitir o acesso à lista privada (trecho 1). A atribuição é feita através de uma expressão lambda (economina de código).
     * 
     * Explicação: se for referencia a classe Pessoa, não terá acesso direto, impedindo a modificação das propriedades.
     */
    private readonly HashSet<Endereco> _enderecos = new HashSet<Endereco>();
    public IEnumerable<Endereco> Enderecos => _enderecos.ToList().AsReadOnly(); // essa expressão lambda equivale a...
    /*public IEnumerable<Endereco> Enderecos()
    {
      return _enderecos.ToList().AsReadOnly();
    }*/

    /* só consigo (e só pode) adicionar endereço, dessa forma...
     */
    public void AdicionarEndereco(Endereco endereco)
    {
      /* Melhorando a validação...
      if (endereco != null)
        _enderecos.Add(endereco);
      */

      if (endereco == null)
      {
        // gera uma exceção (não é uma boa prática)... qwdo for uma coisa muito grave, tudo bem
        // devolver uma mensagem
        // ou mesclar as duas coisas (exceção e mensagem)

        NotificacaoDominio.AdicionarErro("Endereço deve ser instanciado");
      }
      else
      {
        endereco.SetNotificacao(new NotificacaoDominio());

        if (endereco.ValidarPropriedades())
          _enderecos.Add(endereco);
        else
          NotificacaoDominio.AdicionarErro("Não é possível adicionar o endereço para pessoa.");
      }
    }

    // Relacionamento 1 (pessoa) para muitos (BeneficioPessoa). O EF vai, automaticamente, interpretar o relacionamento entre as tabelas
    private readonly HashSet<BeneficioPessoa> _beneficiosPessoa = new HashSet<BeneficioPessoa>();
    public IEnumerable<BeneficioPessoa> BeneficiosPessoa => _beneficiosPessoa.ToList().AsReadOnly();

    public void AdicionarBeneficio(BeneficioPessoa beneficioPessoa)
    {
      _beneficiosPessoa.Add(beneficioPessoa);
    }
    
    public Pessoa()
    {
      // na forma 1, não precisa da inicialização:
      // Enderecos = new List<Endereco>();

      
      /* Notifications:
       * Esquema abaixo é provisório, enqto não se implementa/configura a injeção de dependência:
       */
      SetNotificacao(new NotificacaoDominio());
    }
  }
}
