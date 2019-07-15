using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using WPF.Data;
using WPF.Infrastructure;
using WPF.Interfaces;
using WPF.Models;

namespace WPF.ViewModels
{
    class MainWindowViewModel : Notifier
    {
        private WindowFactory factory;
        IDataService<Repository<Saint>> dataService;
        private Repository<Saint> saints;


        public MainWindowViewModel(IDataService<Repository<Saint>> dataService)
        {
            InitCommands();
            this.dataService = dataService;
            this.saints = new Repository<Saint>();

            SaintsView = CollectionViewSource.GetDefaultView(Saints.Data);
            factory = new WindowFactory();

        }


        private void InitCommands()
        {
            WatchSaintCommand = new RelayCommand(x =>
            {
                WatchSaintViewModel watchSaint = new WatchSaintViewModel();
                watchSaint.SelectedSaint = Saints.Get((int)x);
                factory.GetWindow(watchSaint, "WatchSaintView").ShowDialog();
            });
            SaveCommand = new RelayCommand(x =>
            {
                dataService.Save(Saints);
            });
            LoadCommand = new RelayCommand(x =>
            {
                Repository<Saint> loaded = dataService.Load();

                Saints.Data.Clear();
                foreach (var i in loaded.Data)
                    saints.Data.Add(i);
                SaintsView.Refresh();

            });
            StartupLoadCommand = new RelayCommand(x =>
            {
                Repository<Saint> loaded = dataService.StartupLoad();
                foreach (var i in loaded.Data)
                    saints.Data.Add(i);
                SaintsView.Refresh();

            });
            AddCommand = new RelayCommand(x =>
            {
                Saint saint = new Saint();
                saint.ImagePath = @"../images/default.png";
                saint.Name = "[Name]";
                saint.Id = (Saints.Data.Max(b => b.Id)) + 1;
                Saints.Add(saint);
            });
            RemoveCommand = new RelayCommand(x =>
            {
                Saints.Delete((int)x);
            });
            GetSaints = new RelayCommand(x =>
                {
                    foreach (Saint saint in Saint.GetSaints())
                        Saints.Add(saint);
                    Notify();
                });
            EditImageCommand = new RelayCommand(x =>
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                var result = dlg.ShowDialog();

                if (result == true)
                {
                    Saint saint = Saints.Get((int)x);
                    saint.ImagePath = dlg.FileName;
                }

            });
            CloseWindowCommand = new RelayCommand(x =>
            {
                dataService.ClosingSave(Saints);
                if (x is Window window)
                    window.Close();
            });
            ChangeThemeCommand = new RelayCommand(x =>
            {
                if ((string)x == "Dark")
                {
                    foreach (var resource in Theme.GetLightTheme())
                    {
                        Application.Current.Resources.MergedDictionaries.Remove(resource);
                    }
                    foreach (var resource in Theme.GetDarkTheme())
                    {
                        Application.Current.Resources.MergedDictionaries.Add(resource);
                    }
                }
                else
                {
                    foreach (var resource in Theme.GetDarkTheme())
                    {
                        Application.Current.Resources.MergedDictionaries.Remove(resource);
                    }
                    foreach (var resource in Theme.GetLightTheme())
                    {
                        Application.Current.Resources.MergedDictionaries.Add(resource);
                    }
                }

            });
            SortCommand = new RelayCommand(x =>
            {
                SaintsView.SortDescriptions.Clear();
                SaintsView.SortDescriptions.Add(new SortDescription(x.ToString(), ListSortDirection.Ascending));
            });
            ChangeLanguageCommand = new RelayCommand(x =>
            {
                var ru = Language.GetRussian();
                var eng = Language.GetEnglish();
                if ((string)x == "eng")
                {
                    Application.Current.Resources.MergedDictionaries.Remove(ru);
                    Application.Current.Resources.MergedDictionaries.Add(eng);

                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Remove(eng);
                    Application.Current.Resources.MergedDictionaries.Add(ru);

                }


            });
        }
        #region Properties

        public Repository<Saint> Saints
        {
            get => saints;
            set
            {
                saints = value;
                Notify();
            }
        }
        public ICollectionView SaintsView { get; set; }

        #endregion
        #region Commands

        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand StartupLoadCommand { get; set; }
        public ICommand RemoveCommand { set; get; }
        public ICommand EditCommand { get; set; }
        public ICommand GetSaints { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditImageCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public ICommand ChangeThemeCommand { get; set; }
        public ICommand ChangeLanguageCommand { get; set; }
        public ICommand SortCommand { get; set; }
        public ICommand WatchSaintCommand { get; set; }

        #endregion
    }

}
