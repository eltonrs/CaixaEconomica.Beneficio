using CaixaEconomica.Beneficio.Dominio.Interfaces.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaixaEconomica.Beneficio.Dominio.Notificacoes
{
  public class NotificacaoDominio : INotificacaoDominio
  {
    private List<string> _erroMensagem = new List<string>();
    private List<string> _avisoMensagem = new List<string>();

    public IEnumerable<string> ErroMensagem => _erroMensagem;

    public IEnumerable<string> AvisoMensagem => _avisoMensagem;

    public void AdicionarAviso(string mensagem)
    {
      _avisoMensagem.Add(mensagem);
    }

    public void AdicionarErro(string mensagem)
    {
      _erroMensagem.Add(mensagem);
    }

    public bool PossuiAviso() => _avisoMensagem.Any();

    public bool Validar() => !_erroMensagem.Any();
  }
}
