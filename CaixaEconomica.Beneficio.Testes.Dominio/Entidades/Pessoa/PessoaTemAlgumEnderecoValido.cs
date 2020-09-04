using CaixaEconomica.Beneficio.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaixaEconomica.Beneficio.Testes.Dominio.Entidades.Pessoa
{
  [TestClass]
  public class PessoaTemAlgumEnderecoValido
  {
    /* Para não precisar alterar o namespace (por causa do "Pessoa") eu faço direto:
     */
    private CaixaEconomica.Beneficio.Dominio.Entidades.Pessoa pessoa;
    private Endereco endereco;

    [TestInitialize]
    public void Init() // < Pode ser qlq nome
    {
      pessoa = new Beneficio.Dominio.Entidades.Pessoa();
      endereco = new Endereco();
      pessoa.AdicionarEndereco(endereco);
    }

    [TestMethod]
    public void TestarPessoaTemEnderecoValido()
    {
      Assert.IsTrue(pessoa.Enderecos.Any(), "Pessoa não tem nenhum endereço.");
    }
  }
}
