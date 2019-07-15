using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Infrastructure;
using WPF.Interfaces;
using WPF.Models;

namespace WPF.ViewModels
{
    class WatchSaintViewModel
    {
        public Saint SelectedSaint { get; set; }
        private RelayCommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new RelayCommand(x => (x as Window).Close());
                return closeCommand;
            }
        }

    }
}
