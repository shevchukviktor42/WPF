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

namespace WPF
{
    static class IoC
    {
        public static IKernel Kernel { get; set; } = new StandardKernel();

        public static void Setup()
        {

            Kernel.Bind<IDataService<Repository<Saint>>>().To<JSONService>().WithPropertyValue("FilePath", "data.json");

        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

    }
}
