using static System.Reflection.Metadata.BlobBuilder;

namespace Сапёр
{
    internal class Program
    {

        static void Main()
        {
            int index1 = VvodInt();
            string[,] mass = Mass2String(index1+2);
            string[,] massUI = Mass2String(index1+2);
            UI(massUI);
            GetInMass2Random(mass, 1, 1);
            Bombs(mass,index1);
            Numbers(mass);
            Foreach2(massUI);
            while (true)
            {
                Gameplay(mass, massUI);
                Foreach2(massUI);
            }
        }
        static void Gameplay(string[,] mass, string[,] massUI)
        {
            int vert = VvodInt("Выберите вертикаль");
            if (vert < mass.GetLength(0) && vert != 0)
            {
                int horizon = VvodInt("Выберите горизонталь");
                if (horizon < mass.GetLength(0))
                {
                    if (mass[vert, horizon] == "Ж ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("BOOOOOOOOOOOOM!");
                    }
                    else if (mass[vert,horizon] == "0 ")
                    {
                        OpenRoundZero(mass, massUI, vert, horizon);
                    }
                    else
                    {
                        massUI[vert, horizon] = mass[vert, horizon];
                    }
                }
            }
            else if (vert == 0)
            {
                Print("1 поставить флаг");
                Print("2 проверить флаги");
                Print("3 убрать флаг");
                Print("4 продолжить");
                switch (VvodInt())
                {
                    case 1:
                        int vert1 = VvodInt("Выберите вертикаль");
                        if (vert1 < mass.GetLength(0))
                        {
                            int horizon = VvodInt("Выберите горизонталь");
                            if (horizon < mass.GetLength(0))
                            {
                                massUI[vert1, horizon] = "P ";
                            }
                        }
                        break;
                    case 2:
                        bool end = false;
                        for (int i = 1; i < mass.GetLength(0) - 1; i++)
                        {
                            for (int j = 1; j < mass.GetLength(1) - 1; j++)
                            {
                                if (mass[i, j] == "Ж " && massUI[i,j] != "P ")
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.WriteLine("BOOOOOOOOOOOOM!");
                                    end = true;
                                }
                            }
                        }
                        if(end == true)
                            break;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Success");
                        break;
                    case 3:
                        int vert2 = VvodInt("Выберите вертикаль");
                        if (vert2 < mass.GetLength(0))
                        {
                            int horizon = VvodInt("Выберите горизонталь");
                            if (horizon < mass.GetLength(0))
                            {
                                massUI[vert2, horizon] = $"█ ";
                            }
                        }
                        break;
                    case 4:
                        break;
                }
                    
            }
        }

        private static void OpenRoundZero(string[,] mass, string[,] massUI, int vert, int horizon)
        {
            massUI[vert,horizon] = mass[vert,horizon];
            if (massUI[vert,horizon] == mass[vert, horizon])
            return;
            if (mass[vert,horizon] != "0 ")
                return;
            int i = vert - 1;
            int j = horizon - 1;
            while (i <= vert + 1)
            {
                j = horizon - 1;
                while (j <= horizon + 1)
                {
                    massUI[i, j] = mass[i, j];
                    if (mass[i, j] == "0 ")
                        OpenRoundZero(mass, massUI, i, j);
                    j++;
                }
                i++;
            }
            return;
        }

        static void Numbers(string[,] mass)
        {
            int bombs = 0;
            int vert = 0;
            int horizon = 0;
            string bombSymbol = "Ж ";
            for (int i = 1; i < mass.GetLength(0)-1; i++)
            {
                for (int j = 1; j < mass.GetLength(1)-1; j++)
                {
                    bombs = 0;
                    if (mass[i, j] != bombSymbol)
                    {
                        vert = i - 1;
                        while (vert <= i + 1)
                        {
                            horizon = j - 1;
                            while (horizon <= j + 1)
                            {
                                if (mass[vert, horizon] == bombSymbol)
                                    bombs++;
                                horizon++;
                            }
                            vert++;
                        }
                        mass[i, j] = $"{bombs} ";
                    }
                }
            }
        }
        static double Randomazer(int min, int max)
        {
            Random random = new Random();
            double R = random.Next(min, max+1);
            return R;
        }
        static int RandomazerInt(int min, int max)
        {
            Random random = new Random();
            int R = random.Next(min, max);
            return R;
        }
        static void UI(string[,] massUI)
        {  
            for (int i = 0; i < massUI.GetLength(0)-1; i++)
            {
                for(int j = 0; j < massUI.GetLength(1)-1; j++)
                {
                    massUI[i, j] = $"█ ";
                    massUI[i, 0] = $"|{i}|\t";
                    massUI[0, j] = $"{j} ";
                    massUI[0, 0] = $"\t";

                }
            }
        }
        static void Print(string text)
        {
            Console.WriteLine(text);
        }
        static void Foreach2(string[,] mass)
        {
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    switch (mass[i, j])
                    {
                        case "1 ":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "2 ":
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            break;
                        case "3 ":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case "4 ":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "5 ":
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        case "6 ":
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            break;
                        case "7 ":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "8 ":
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case "█ ":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "P ":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                    }
                    Console.Write(mass[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
        static int VvodInt(string text = "Введите число int")
        {
            Console.WriteLine(text);
            int.TryParse(Console.ReadLine(), out int num);
            return num;
        }
        static object VvodObject(string text = "Введите объект")
        {
            Console.WriteLine(text);
            object num = Console.ReadLine();
            return num;
        }
        static string VvodString(string text = "Введите text")
        {
            Console.WriteLine(text);
            string str = Console.ReadLine();
            return str;
        }
        static void Vsvod(object x)
        {
            Console.WriteLine(x);
        }
        static string[,] Mass2String(int index1)
        {
            string[,] mass = new string[index1, index1]; 
            return mass;
        }
        static void Bombs(string[,] mass, int index)/*💣︎*/
        {
            for(int i = 0; i < index * 2; i++)
            {
                int x = RandomazerInt(1, mass.GetLength(0)-1);
                int y = RandomazerInt(1, mass.GetLength(1)-1);
                mass[x, y] = "Ж ";
            }
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(0)-2; j++)
                {
                    mass[i, 0] = $"|{i}|\t";
                    mass[0, j] = $"{j}_";
                    //mass[mass.GetLength(0)-1, j] = $"";
                    //mass[i, mass.GetLength(0) - 1] = $"";
                }
                mass[0, mass.GetLength(1)-1] = $"{mass.GetLength(1)-2}.";
            }
            mass[0, 0] = "\t";
        }
        static void GetInMass2Random(string[,] mass, int min, int max)
        {
            for (int i = 1;i < mass.GetLength(0)-1; i++)
            {
                for(int j = 1;j < mass.GetLength(1)-1; j++)
                {
                    mass[i, j] = $"{Randomazer(min, max)} ";
                }
            }
        }
    }
}