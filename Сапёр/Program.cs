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
                                    Console.ForegroundColor = ConsoleColor.Red;
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
        static void Numbers(string[,] mass)
        {
            for (int i = 1; i < mass.GetLength(0)-1; i++)
            {
                for (int j = 1; j < mass.GetLength(1)-1; j++)
                {
                    int bombs = 0;
                    if (mass[i,j] !="Ж ")
                    {
                        
                        int vert = i-1;
                        while(vert <= i + 1)
                        {
                            int horizon = j-1;
                            while (horizon <= j + 1)
                            {
                                if (mass[vert, horizon] == "Ж ")
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
            int R = random.Next(min, max + 1);
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
                    Console.Write(mass[i, j]);
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
                for (int j = 0; j < mass.GetLength(0); j++)
                {
                    mass[i, 0] = $"|{i}|\t";
                    mass[0, j] = $"{j} ";
                    //mass[mass.GetLength(0)-1, j] = $"";
                    //mass[i, mass.GetLength(0) - 1] = $"";
                }
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