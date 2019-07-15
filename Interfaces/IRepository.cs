using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Interfaces
{
    interface IRepository<T> where T : class, IEntity
    {
        ObservableCollection<T>Data {get;set;}
        ObservableCollection<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Delete(int id);
        void Update(T item);

    }
}
