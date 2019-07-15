using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Interfaces;
using WPF.Models;
using WPF.ViewModels;

namespace WPF.Infrastructure
{
    class ServiceLocator
    {
        public MainWindowViewModel MainWindowViewModel { get; set; }
       
        public ServiceLocator()
        {
            MainWindowViewModel = IoC.Get<MainWindowViewModel>();
        }

    }
}
