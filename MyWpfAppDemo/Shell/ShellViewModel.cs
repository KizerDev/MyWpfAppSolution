using AppCore.AppContextData;
using Prism.Mvvm;
using System;

namespace MyWpfAppDemo.Shell
{
    class ShellViewModel : BindableBase
    {
        public string Title
        {
            get { return AppContextData.Instance.ApplicationTitle; }
            
        }

        public string RaisonSociale
        {
            get { return AppContextData.Instance.RaisonSociale; }

        }

        public string Jour
        {
            get { return DateTime.Today.ToString("dddd"); }
        }

        public string MoisAnnee
        {
            get { return DateTime.Today.ToString("MMMM  yyyy"); }
        }

        public ShellViewModel()
        {

        }
    }
}
