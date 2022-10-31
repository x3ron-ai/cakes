using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    public class Cake
    {
        public static void CompleteOrder()
        {
            string data = DateTime.Now.ToLongDateString();
            File.AppendAllText("C:\\Users\\Roman\\Desktop\\orders.txt", $"\nЗаказ от {data}\n\tИтоговая цена: {getPrice()}\n\tПолный заказ:{GetTextProperties()}");
            Console.Clear();
            Console.WriteLine("Заказ оформлен\nНажмите Esc чтобы закрыть или Enter чтобы продолжить");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            Properties.shape = new CakeProperty();
            Properties.size = new CakeProperty();
            Properties.flavor = new CakeProperty();
            Properties.count = new CakeProperty();
            Properties.glaze = new CakeProperty();
            Properties.decor = new CakeProperty();

        }
        public static string GetTextProperties()
        {
            string response = $"\tФорма тортика: {Properties.shape.title}\n" +
                $"\tРазмер тортика: {Properties.size.title}\n" +
                $"\tВкус тортика: {Properties.flavor.title}\n" +
                $"\tКоличество коржей у тортика: {Properties.count.title}\n" +
                $"\tГлазурь тортика: {Properties.glaze.title}\n" +
                $"\tДекорации тортика: {Properties.decor.title}\n";
            return response;
        }
        public static bool GetOrderCompleted()
        {
            if (Properties.shape.price == 0 | Properties.size.price == 0 | Properties.flavor.price == 0 | Properties.count.price == 0 | Properties.glaze.price == 0 | Properties.decor.price == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private class Properties {
            public static CakeProperty shape = new CakeProperty() { price = 0};
            public static CakeProperty size = new CakeProperty() { price = 0 };
            public static CakeProperty flavor = new CakeProperty() { price = 0 };
            public static CakeProperty count = new CakeProperty() { price = 0 };
            public static CakeProperty glaze = new CakeProperty() { price = 0 };
            public static CakeProperty decor = new CakeProperty() { price = 0 };
        }
        public static int getPrice()
        {
            int price = 0;
            price += Properties.shape.price
                + Properties.size.price
                + Properties.flavor.price
                + Properties.count.price
                + Properties.glaze.price
                + Properties.decor.price;
            return price;
        }

        public static List<MainParam> MainMenu()
        {
            List<MainParam> response = new List<MainParam>()
            {
                new MainParam() { title = "Форма", type = 1},
                new MainParam() { title = "Размер", type = 2},
                new MainParam() { title = "Вкус", type = 3},
                new MainParam() { title = "Кол-во коржей", type = 4},
                new MainParam() { title = "Глазурь" , type = 5},
                new MainParam() { title = "Декор", type = 6},
                new MainParam() { title = "Заказать тортик", type = 7}
            };
            return response;
        }
        public static List<SubParam> SubMenu(int feature)
        {
            List<SubParam> response;
            switch (feature)
            {
                case 1:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "Круг", price = 50 },
                        new SubParam() { title = "Квадрат", price = 70 },
                        new SubParam() { title = "Тангенциальная трапеция", price = 80 },
                        new SubParam() { title = "Кардиоида", price = 70 },
                        new SubParam() { title = "Плитка Пенроуза", price = 180 }
                    };
                    break;
                case 2:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "Большой", price = 300 },
                        new SubParam() { title = "Очень большой", price = 400 },
                        new SubParam() { title = "4XL", price = 500 }
                    };
                    break;
                case 3:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "Манго", price = 40 },
                        new SubParam() { title = "Клубника", price = 40 },
                        new SubParam() { title = "Шоколад", price = 30 },
                        new SubParam() { title = "Диетламид лизергеновой кислоты", price = 1300 },
                    };
                    break;
                case 4:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "1", price = 20 },
                        new SubParam() { title = "2", price = 40 },
                        new SubParam() { title = "3", price = 60 },
                        new SubParam() { title = "4", price = 80 },
                    };
                    break;
                case 5:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "Ягоды", price = 20 },
                        new SubParam() { title = "Шоколад", price = 40 },
                        new SubParam() { title = "Крем", price = 60 },
                    };
                    break;
                case 6:
                    response = new List<SubParam>()
                    {
                        new SubParam() { title = "Клубника", price = 20 },
                        new SubParam() { title = "Шоколад", price = 40 },
                        new SubParam() { title = "Вишенки", price = 60 }
                    };
                    break;
                default:
                    response = new List<SubParam>();
                    break;
            }
            return response;
        }

        public class SubParam
        {
            public string title = "";
            public int price;
        }
        private class CakeProperty
        {
            public string title = " ";
            public int price = 0;
            /*public string getText()
            {
                if (title != " ")
                    return $"{title} - {price}";
                else
                    return " ";
            }*/
        }
        public class MainParam
        {
            public string title = "";
            public int type;
            public void setValue(int sub, string text, int price)
            {
                switch (sub)
                {
                    case 1:
                        Properties.shape = new CakeProperty { title = text, price = price };
                        break;
                    case 2:
                        Properties.size = new CakeProperty { title = text, price = price };
                        break;
                    case 3:
                        Properties.flavor = new CakeProperty { title = text, price = price };
                        break;
                    case 4:
                        Properties.count = new CakeProperty { title = text, price = price };
                        break;
                    case 5:
                        Properties.glaze = new CakeProperty { title = text, price = price };
                        break;
                    case 6:
                        Properties.decor = new CakeProperty { title = text, price = price };
                        break;
                }
            }
        }
        
    }
}
