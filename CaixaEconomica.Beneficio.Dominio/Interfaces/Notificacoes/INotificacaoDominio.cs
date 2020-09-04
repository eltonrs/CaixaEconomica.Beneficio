using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEconomica.Beneficio.Dominio.Interfaces.Notificacoes
{
  public interface INotificacaoDominio
  {
    bool Validar();
    bool PossuiAviso();
    IEnumerable<string> ErroMensagem { get; }
    IEnumerable<string> AvisoMensagem { get; }
    void AdicionarErro(string mensagem);
    void AdicionarAviso(string mensagem);
  }
}
