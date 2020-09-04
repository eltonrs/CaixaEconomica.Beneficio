using CaixaEconomica.Beneficio.Dominio.Interfaces.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEconomica.Beneficio.Dominio.Entidades
{
  /* Leitura:
   * É uma classe que não pode ser instanciada, apenas herdada.
   * 
   * Também é utilizada para implementar as Notifications, pois é um "local" comuns para todas as entidades.
   */
  public abstract class Entidade
  {
    /* Notifications:
     * 
     * Tenho que registrar essa interface no mecanismo de injeção de dependência
     */
    private INotificacaoDominio _notificacaoDominio;
    protected INotificacaoDominio NotificacaoDominio
    {
      get
      {
        return _notificacaoDominio == null ?
          throw new Exception("NotificacaoDominio não instanciada. Por favor, chamar o método SetNotificacao.") :
          _notificacaoDominio;
      }
    }

    public void SetNotificacao(INotificacaoDominio notificacaoDominio)
    {
      _notificacaoDominio = notificacaoDominio;
    }

    public bool ValidarNotificacaoErro()
    {
      return _notificacaoDominio.Validar();
    }
  }
}
