
internal class Program
{
    private static void Main(string[] args)
    {
        int rows = 6;
        int columns = 6;

        char[,] labyrinth = new char[rows, columns];
        List<char[,]> labyrinths = new List<char[,]>();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {if (i == 0 || i == 5 || j == 0 || j == 5)
                {
                    labyrinth[i, j] = 'X';
                }
                else
                {
                    labyrinth[i, j] = '0';
                }
             }
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(labyrinth[i, j]);
            }
            Console.WriteLine();
        }
        while (true)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(labyrinth[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("1. Dodaj nowy labirynt \n" +
                "2. Edytuj labirynt \n" +
                "3. Usun labirynt\n" +
                "4. Wybierz labirynt do widoku (domyslnie widzisz labirynt który ostatnio był zmieniany)\n" +
                "5. Zapisz labirynt");
            int wybor = Convert.ToInt32(Console.ReadLine());
            switch (wybor)
            {
                case 1:
                    Console.WriteLine("Ile wierszy?");
                    rows = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ile kolumn?");
                    columns = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if (i == 0 || i == rows-1 || j == 0 || j == columns-1)
                            {
                                labyrinth[i, j] = 'X';
                            }
                            else
                            {
                                labyrinth[i, j] = '0';
                            }
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Który wiersz?");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Która kolumna?");
                    int y = Convert.ToInt32(Console.ReadLine());
                    bool typ = false;
                    typbool:
                    try
                    {
                        Console.WriteLine("Pusta(1) czy pełna(2)");
                        int temp = Convert.ToInt32(Console.ReadLine())-1;
                        if(temp != 1 && temp != 0)
                        {
                            throw new Exception();
                        }
                        typ = Convert.ToBoolean(temp);
                    }
                    catch
                    {
                        Console.WriteLine("Hej kolego, miało być 1 lub 2 spróbuj ponownie");
                        goto typbool;
                    }
                    if (typ)
                        labyrinth[x, y] = 'X';
                    else
                        labyrinth[x, y] = '0';
                    break;
                 case 3:
                    Console.WriteLine("Wybierz ")
                    labyrinths.RemoveAt();
                    break;

            }
        }
    }
}