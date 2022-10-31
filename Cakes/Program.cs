namespace Cakes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sub = 0;
            int position = 1;
            Cake.MainParam mainParam = new Cake.MainParam();
            while (true)
            {
                int maxPos = 0;
                Console.Clear();
                Console.WriteLine("Онлайн заказ тортиков \"5 рублей\". Выбор критериев:");
                List<string> menu = new List<string>();
                List<Cake.MainParam> mainMenu = Cake.MainMenu();
                List<Cake.SubParam> subMenu = Cake.SubMenu(sub);
                if (sub == 0)
                {
                    List<Cake.MainParam> rsp = Cake.MainMenu();
                    foreach (Cake.MainParam param in mainMenu)
                    {
                        menu.Add("   " + param.title);
                        maxPos++;
                    }
                }
                else
                {
                    List<Cake.SubParam> rsp = Cake.SubMenu(sub);
                    foreach (Cake.SubParam param in subMenu)
                    {
                        menu.Add($"   {param.title} - {param.price}");
                        maxPos++;
                    }
                }
                foreach (string line in menu)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("----------------------------------------------------------------"); // чудо-разограничитель я в шоке
                Console.WriteLine($"Ваш заказ будет стоить {Cake.getPrice()}:\n{Cake.GetTextProperties()}");
                Console.SetCursorPosition(0, position);
                Console.Write(">>");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        sub = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (sub == 0)
                        {
                            mainParam = mainMenu[position - 1];
                            if (mainParam.type == 7)
                            {
                                if (Cake.GetOrderCompleted())
                                {
                                    Cake.CompleteOrder();
                                }
                                else
                                {
                                    sub = 0;
                                    mainParam = new Cake.MainParam();
                                }

                            }
                            else
                            {
                                sub = position;
                            }
                                
                        }
                        else
                        {
                            Cake.SubParam buttonPressed = subMenu[position - 1];
                            mainParam.setValue(sub, $"{buttonPressed.title} - {buttonPressed.price}", buttonPressed.price);
                            Console.SetCursorPosition(0,mainParam.type);
                            sub = 0;
                        }
                        position = 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (position != maxPos)
                        {
                            position++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (position != 1)
                        {
                            position--;
                        }
                        break;
                }
                
            }
        }
    }
}