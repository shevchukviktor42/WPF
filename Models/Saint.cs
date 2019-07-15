using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Infrastructure;
using WPF.Interfaces;

namespace WPF.Models
{
    public class Saint : Notifier, ICloneable, IEntity
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                Notify();
            }
        }

        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                Notify();
            }
        }
        private int year;
        public int Year
        {
            get => year;
            set
            {
                year = value;
                Notify();
            }
        }
        private string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                Notify();
            }

        }
        private int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                Notify();
            }
        }
        public static ObservableCollection<Saint> GetSaints()
        {
            return new ObservableCollection<Saint>
            {
                new Saint { Name = "Макарий", Description = "Святой Макарий, во избавление от греховных мыслей «надолго погружал зад и гениталии в муравейник». ", Year = 300, ImagePath = "/Images/Makariy.jpg" ,id =0},
                new Saint { Name = "Ориген", Description = "Святой Ориген, публично отрезал себе пенис во имя «царствия небесного».", Year = 185, ImagePath = "/Images/Origen.jpg" ,id =1},
                new Saint { Name = "Тихон Калужский", Description = "Святой Тихон Калужский, всю жизнь прожил как белка, в дупле дуба».", Year = 1400, ImagePath = "/Images/Kalug.jpg" ,id =2},
                new Saint { Name = "Корнилий Молчальник", Description = "Святой Корнилий Молчальник всю свою жизнь молчал", Year = 1643, ImagePath = "/Images/Korniliy.jpg" ,id =3},
                new Saint { Name = "Василий Блаженный", Description = "Святой Василий Блаженный ходил зимой и летом голый и кидался человеческим калом в тех, кого считал еретикам", Year = 1469, ImagePath = "/Images/Vasiliy.png" ,id =4},
                new Saint { Name = "Анджела Меричи", Description = "Святая Анджела прославилась тем, что горящим поленом регулярно прижигала себе интимные места, чтобы «избавиться от огня сладострастия»", Year = 1474, ImagePath = "/Images/angela.jpg" ,id =5},
               
           
           };

        }

        public object Clone()
        {
            return MemberwiseClone();
            
        }

    }
}
