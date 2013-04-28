using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Domain.Util.Diagnostics
{
    /// <summary>
    /// Classe que encapsula o objeto e os metodos da biblioteca de logs Log4Net
    /// </summary>
    public class Logger
    {
        private static ILog _Log = null;
        private static ILog Log
        {
            get
            {
                if (_Log == null)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    _Log = log4net.LogManager.GetLogger("LogPrincipal");                    
                }
                return _Log;
            }
        }

        #region DEBUG

        public static void Debug(string mensagem)
        {
            Log.Debug(mensagem);
        }

        public static void Debug(string mensagemFormat, object arg0)
        {
            Log.DebugFormat(mensagemFormat, arg0);
        }

        public static void Debug(string mensagemFormat, params object[] args)
        {
            Log.DebugFormat(mensagemFormat, args);
        }

        public static void Debug(IFormatProvider provider, string mensagemFormat, params object[] args)
        {
            Log.DebugFormat(provider, mensagemFormat, args);
        }

        #endregion

        #region INFO

        public static void Info(string mensagem)
        {
            Log.Info(mensagem);
        }

        public static void Info(string mensagemFormat, object arg0)
        {
            Log.InfoFormat(mensagemFormat, arg0);
        }

        public static void Info(string mensagemFormat, params object[] args)
        {
            Log.InfoFormat(mensagemFormat, args);
        }

        public static void Info(IFormatProvider provider, string mensagemFormat, params object[] args)
        {
            Log.InfoFormat(provider, mensagemFormat, args);
        }

        #endregion

        #region WARN

        public static void Warn(string mensagem)
        {
            Log.Warn(mensagem);
        }

        public static void Warn(string mensagemFormat, object arg0)
        {
            Log.WarnFormat(mensagemFormat, arg0);
        }

        public static void Warn(string mensagemFormat, params object[] args)
        {
            Log.WarnFormat(mensagemFormat, args);
        }

        public static void Warn(IFormatProvider provider, string mensagemFormat, params object[] args)
        {
            Log.WarnFormat(provider, mensagemFormat, args);
        }

        #endregion

        #region FATAL

        public static void Fatal(string mensagem)
        {
            Log.Fatal(mensagem);
        }

        public static void Fatal(string mensagemFormat, object arg0)
        {
            Log.FatalFormat(mensagemFormat, arg0);
        }

        public static void Fatal(string mensagemFormat, params object[] args)
        {
            Log.FatalFormat(mensagemFormat, args);
        }

        public static void Fatal(IFormatProvider provider, string mensagemFormat, params object[] args)
        {
            Log.FatalFormat(provider, mensagemFormat, args);
        }

        #endregion

        #region ERROR

        public static void Error(string mensagem)
        {
            Log.Error(mensagem);
        }

        public static void Error(string mensagem, Exception ex)
        {
            Log.Error(mensagem, ex);
        }

        public static void Error(string mensagemFormat, object arg0)
        {
            Log.ErrorFormat(mensagemFormat, arg0);
        }

        public static void Error(string mensagemFormat, params object[] args)
        {
            Log.ErrorFormat(mensagemFormat, args);
        }

        public static void Error(IFormatProvider provider, string mensagemFormat, params object[] args)
        {
            Log.ErrorFormat(provider, mensagemFormat, args);
        }

        #endregion
    }
}
