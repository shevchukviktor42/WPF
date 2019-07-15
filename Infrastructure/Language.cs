using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.Infrastructure
{
    public static class Language
    {
        public static ResourceDictionary GetRussian()
        {

            return Application.LoadComponent(new Uri("Resources/ru-RU.xaml", UriKind.Relative)) as ResourceDictionary;
        }

        public static ResourceDictionary GetEnglish()
        {
            return Application.LoadComponent(new Uri("Resources/en-US.xaml", UriKind.Relative)) as ResourceDictionary;
        }
    }
}
