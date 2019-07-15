using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Infrastructure;
using WPF.Interfaces;
using WPF.Models;

namespace WPF.Data
{
    public class Repository<Saint> : Notifier,ICloneable, IRepository<Saint>
        where Saint : class, IEntity
    {
        private ObservableCollection<Saint> data;
        public ObservableCollection<Saint> Data
        {
            get => data;
            set
            {
                data = value;
                Notify();
            }
        }
        public Repository()
        {
            data = new ObservableCollection<Saint>();
        }


        public void Add(Saint item)
        {
            data.Add(item);
        }

        public void Delete(int id)
        {
            var databaseEntity = Get(id);
            if (data == null)
            {
                throw new InvalidOperationException("ноуп");
            }
            data.Remove(databaseEntity);
        }

        public Saint Get(int id)
        {
            return data.FirstOrDefault(x => x.Id == id);
        }

        public ObservableCollection<Saint> GetAll()
        {
            return data;
        }


        public void Update(Saint item)
        {
            var databaseEntity = Get(item.Id);
            databaseEntity = item;
        }

        public object Clone()
        {
            Repository<Saint> clone = new Repository<Saint>();
            foreach (var item in data)
            {
                clone.data.Add((Saint)item.Clone());
            }

            return clone;

        }
    }
}
