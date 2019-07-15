using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.Infrastructure
{
    class WindowFactory
    {
        public Window GetWindow(object dataContext, string view)
        {
            Type windowType = Type.GetType($"WPF.Views.{view}");
            if (windowType != null)
            {
                Window window = (Window)Activator.CreateInstance(windowType);
                window.DataContext = dataContext;
                return window;
            }
            return null;
        }
    }
}
