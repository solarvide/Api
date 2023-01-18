using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Util
{
    public class ExceptionControlled : Exception
    {
        public bool Status { get; set; } = false;

        public bool? ShowAlert { get; set; }

        public NotificacaoMensagem Notificacao { get; set; }

        public string ExceptionMsg { get; set; }


        public ExceptionControlled(string mensagemAmigavel = "", string titulo = "", string exception = "", bool status = false)
        {
            Status = status;
            Notificacao = new NotificacaoMensagem { 
                MensagemAmigavel = mensagemAmigavel,
                Titulo = titulo
            };
            ExceptionMsg = exception;
        }

        public ExceptionControlled(string mensagemParaDesenvolvedor = "", bool? showAlert = null, bool status = false)
        {
            Status = status;
            ShowAlert = showAlert;
            Notificacao = new NotificacaoMensagem
            {
                MensagemAmigavel = "",
                Titulo = ""
            };
            ExceptionMsg = mensagemParaDesenvolvedor;
        }
        

        public class NotificacaoMensagem
        {
            public string Titulo { get; set; }
            public string MensagemAmigavel { get; set; }

        }

        public class ResponseObject
        {   
            public bool Status { get; set; }

            public bool ShowNotificacao { get; set; } = true;

            public NotificacaoMensagem Notificacao { get; set; }

            public string ExceptionForDev { get; set; } = "";
            public string ExceptionForDevInner { get; set; } = "";

        }


        public ResponseObject ResponseToJson()
        {
            return new ResponseObject
            {
                Status = this.Status,
                ExceptionForDev = this.ShowAlert.HasValue ? (this.ShowAlert.Value == false ? this.ExceptionMsg : "") : this.Message,
                ExceptionForDevInner = this.ShowAlert.HasValue ? (this.ShowAlert.Value == false ? this.ExceptionMsg : "") : GetInnerMessage(this),
                ShowNotificacao = this.ShowAlert.HasValue ? this.ShowAlert.Value :  !String.IsNullOrWhiteSpace(this.Notificacao.MensagemAmigavel),
                Notificacao = this.Notificacao
                
            };
        }

        public static ResponseObject ResponseToJson(Exception e)
        {
            return new ResponseObject
            {
                Status = false,
                ExceptionForDev = e.Message,
                ExceptionForDevInner = GetInnerMessage(e),
                ShowNotificacao = false,
                Notificacao = null

            };
        }

        public static string GetInnerMessage(Exception e) {

            return e.InnerException == null ? "" : (e.InnerException.Message == null ? "" : e.InnerException.Message);


        }

    }
}
