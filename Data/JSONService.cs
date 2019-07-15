using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Newtonsoft.Json;
using WPF.Data;
using WPF.Interfaces;

namespace WPF.Models
{
    class JSONService : IDataService<Repository<Saint>>
    {
        public string FilePath { get; set; }
        public Repository<Saint> StartupLoad()
        {
            Repository<Saint> data = new Repository<Saint>();
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                data.Data = JsonConvert.DeserializeObject<ObservableCollection<Saint>>(json);
                return data;
            }
            else
                return data;

        }
        public Repository<Saint> Load()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "data";
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON (.json)|*.json";
            var result = dlg.ShowDialog();
            if (result == true)
            {
                FilePath = dlg.FileName;
                return StartupLoad();
            }
            else return new Repository<Saint>();
      
        }

        public void Save(Repository<Saint> data)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "data";
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON (.json)|*.json";
            var result = dlg.ShowDialog();
            if (result == true)
            {
                FilePath = dlg.FileName;
                ClosingSave(data);
            }

        }
        public void ClosingSave(Repository<Saint> data)
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(data.GetAll(), Formatting.Indented));
        }
    }
}
