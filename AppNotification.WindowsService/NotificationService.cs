using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AppNotification.WindowsService
{
    public partial class NotificationService : ServiceBase
    {
        public NotificationService()
        {
            try
            {
                InitializeComponent();
                AutoLog = false;
            }
            catch (Exception e)
            {
                //LogController.Instance.GravarLogErro(e);
                throw;
            }
        }


        protected override void OnStart(string[] args)
        {
            try
            {
                InitializeSelfHosting();
                //LogController.Instance.GravarLogInformacao("Gateway Comunicação Iniciado");
            }
            catch (Exception e)
            {
                //LogController.Instance.GravarLogErro(e);
                throw;
            }
        }

        protected override void OnStop()
        {
            //LogController.Instance.GravarLogInformacao("Gateway Comunicação parado");
        }

        public void InitializeSelfHosting()
        {
            try
            {
                string url = Convert.ToString(ConfigurationManager.AppSettings["uriService"]);
                WebApp.Start(url);
            }
            catch (Exception e)
            {
                //LogController.Instance.GravarLogErro(e);
                throw;
            }
        }
    }
}
