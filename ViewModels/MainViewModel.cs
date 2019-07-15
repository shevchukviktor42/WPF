using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using WPF.Data;
using WPF.Infrastructure;
using WPF.Models;



namespace WPF.ViewModels
{
    class MainViewModel : Notifier
    {
        private WindowFactory factory;
       // private ObservableCollection<Car> cars = new ObservableCollection<Car>();
        private Car selectedCar =new Car();
        IDataService<Repository<Car>> dataService;
        private Repository<Car> cars=new Repository<Car>();
        public MediaPlayer Player { get; set; }
        public MainViewModel(IDataService<Repository<Car>> dataService)
        {
            InitCommands();
            this.dataService = dataService;
            factory = new WindowFactory();
            Player.Open(new Uri("../../1.mp3", UriKind.Relative));

        }


        private void InitCommands()
        {
           PlayCommand = new RelayCommand(x => Player.Play());


            SaveCommand = new RelayCommand(x =>
            {
                dataService.Save(Cars);
            });
            LoadCommand = new RelayCommand(x =>
           {
               Cars = dataService.Load();
               Notify();

           });

            RemoveCommand = new RelayCommand(x => Cars.Delete(selectedCar.Id));


            EditCommand = new RelayCommand(x =>
            {
                EditViewModel edit = new EditViewModel();
                //edit.Message(SelectedCar);

                edit.NewCar = (Car)selectedCar.Clone();
                factory.GetWindow(edit, "EditView").ShowDialog();
                if (edit.flag)
                {
                    selectedCar.Color = edit.NewCar.Color;
                    //Car editCar = Cars.FirstOrDefault(car => car.Equals(selectedCar)) ;
                   // selectedCar = (Car)edit.NewCar.Clone();
                   
                }
            });




            GetCars = new RelayCommand(x =>
           {
               foreach (Car car in Car.GetCars())
                   Cars.Add(car);
              Notify();
           });


            AddCommand = new RelayCommand(x =>
            {
                AddViewModel add = new AddViewModel();
                factory.GetWindow(add, "AddView").ShowDialog();
                if(add.flag)
                Cars.Add(add.NewCar);
                
            });

               


        }


        #region Properties

        //public ObservableCollection<Car> Cars
        //{
        //    get => cars;
        //    set
        //    {
        //        cars = value;
        //        Notify();
        //    }
        //}
        public Repository<Car> Cars
        {
            get => cars;
            set
            {
                cars = value;
                Notify();
            }
        }

        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                Notify();
            }
        }


        #endregion
        #region Commands

        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand RemoveCommand { set; get; }
        public ICommand EditCommand { get; set; }
        public ICommand GetCars { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand PlayCommand { get; set; }

        #endregion
    }
}
