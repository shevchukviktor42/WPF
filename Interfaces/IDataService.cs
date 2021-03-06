﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models
{
    interface IDataService<T>
    {
        void Save(T data);
        void ClosingSave(T data);
        T StartupLoad();
        T Load();
    }
}
