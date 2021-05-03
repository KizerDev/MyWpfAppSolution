using AppCore.Helper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.AppContextData
{
    public class AppContextData
    {
        #region Singleton

        private static AppContextData _instance;
        private static readonly object LockObject = new object();

        public static AppContextData CreateInstance(string settingsFilename)
        {
            lock (LockObject)
            {
                if (null == _instance)
                {
                    _instance = new AppContextData(settingsFilename);
                }
            }
            return _instance;
        }

        public static AppContextData Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        private AppContextData(string settingsFilename)
        {
            MachineName = Environment.MachineName;
            MacAdress = InternalHelper.GetMachinecMacAddress();
            var builder = new ConfigurationBuilder();
            AppConfig = builder.Add<WritableJsonConfigurationSource>(
               (Action<WritableJsonConfigurationSource>)(s =>
               {
                   s.FileProvider = null;
                   s.Path = settingsFilename;
                   s.Optional = false;
                   s.ReloadOnChange = true;
                   s.ResolveFileProvider();
               })).Build();
        }

        public string MachineName { get; private set; }
        public string MacAdress { get; private set; }
        public IConfigurationRoot AppConfig { get; private set; }

        public string ApplicationTitle => "MyCRM App";

        public string RaisonSociale
        {
            get { return AppConfig.GetSection("RaisonSociale").Value; }
            set { AppConfig.GetSection("RaisonSociale").Value = value; }
        }
        public string NomResponsable
        {
            get { return AppConfig.GetSection("NomResponsable").Value; }
            set { AppConfig.GetSection("NomResponsable").Value = value; }
        }
        public string PrenomResponsable
        {
            get { return AppConfig.GetSection("PrenomResponsable").Value; }
            set { AppConfig.GetSection("PrenomResponsable").Value = value; }
        }
        public string LibelleAdresseResponsable
        {
            get { return AppConfig.GetSection("LibelleAdresseResponsable").Value; }
            set { AppConfig.GetSection("LibelleAdresseResponsable").Value = value; }
        }
        public string VilleAdresseResponsable
        {
            get { return AppConfig.GetSection("VilleAdresseResponsable").Value; }
            set { AppConfig.GetSection("VilleAdresseResponsable").Value = value; }
        }
        public string CodePostalAdresseResonsable
        {
            get { return AppConfig.GetSection("CodePostalAdresseResonsable").Value; }
            set { AppConfig.GetSection("CodePostalAdresseResonsable").Value = value; }
        }
        public string Telephone
        {
            get { return AppConfig.GetSection("TelContact").Value; }
            set { AppConfig.GetSection("TelContact").Value = value; }
        }
        public string Email
        {
            get { return AppConfig.GetSection("EmailContact").Value; }
            set { AppConfig.GetSection("EmailContact").Value = value; }
        }
        public string Site
        {
            get { return AppConfig.GetSection("SiteContact").Value; }
            set { AppConfig.GetSection("SiteContact").Value = value; }
        }
    }
}
