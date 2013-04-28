using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Castle.ActiveRecord.Framework.Config;
using Castle.ActiveRecord;
using System.Reflection;
using Domain.Model;
using Domain.Util.Security;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //atribui o idioma Português-brasil ao contexto do sistema. com isso o sistema irá reconhecer os formatos de numero,
            //datra e moedas no padrão Portugues-Brasil
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");

            //Lê o arquivo de configuração do NHibernate. 
            ////var config = new XmlConfigurationSource("d:\\config.xml");

            //Inicializa o NHibernate
            ////ActiveRecordStarter.Initialize(new Assembly[] { Assembly.GetAssembly(typeof(Usuario)) }, config, new Type[] { });

            //ActiveRecordStarter.DropSchema();
            ////ActiveRecordStarter.CreateSchema();// criar tabela

            ////Usuario usuario = new Usuario();
            ////usuario.Nome = "administrador";
            ////usuario.NomeUsuario = "admin";
            ////usuario.Email = "admin@admin.com.br";
            ////usuario.TipoDoUsuario = Usuario.TipoUsuario.AdministradorCondominio;
            ////usuario.StatusDoUsuario = Usuario.Status.Ativo;

            ////usuario.Senha = Criptografia.EncriptMD5("admin");
            ////usuario.CreateAndFlush();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}