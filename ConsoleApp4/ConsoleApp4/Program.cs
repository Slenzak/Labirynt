
internal class Program
{
    private static void Main(string[] args)
    {
        int rows = 6;
        int columns = 6;
        char[,] labyrinth = new char[rows, columns];
        List<char[,]> labyrinths = new List<char[,]>();
        while (true)
        {
            
            Console.WriteLine("\n");
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
                "5. Zapisz labirynt\n" +
                "6. Wyjdz z programu");
            int wybor = Convert.ToInt32(Console.ReadLine());
            int p = 0;
            switch (wybor)
            {
                case 1:
                    Console.WriteLine("Ile wierszy?");
                    rows = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ile kolumn?");
                    columns = Convert.ToInt32(Console.ReadLine());
                    labyrinth = new char[rows,columns];
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
                    int typ = 0;
                    bool check = true;
                    int temp = 0;
                    while(check)
                    try
                    {
                        Console.WriteLine("Pelna(1) pusta(2) czy sciezka(3)?");
                        temp = Convert.ToInt32(Console.ReadLine())-1;
                        if(temp != 1 && temp != 0 && temp != 2)
                        {
                            throw new Exception();
                        }
                        typ = temp;
                            break;
                    }
                    catch
                    {
                        Console.WriteLine("Hej kolego, miało być 1,2 lub 3 spróbuj ponownie");
                    }
                    if (typ == 0)
                        labyrinth[x, y] = 'X';
                    else if (typ == 1)
                        labyrinth[x, y] = '0';
                    else
                        labyrinth[x, y] = '-';
                    break;
                 case 3:
                    if (!labyrinths.Any())
                    {
                        Console.WriteLine("Nie ma zadnych zapisanych labiryntów");
                        break;
                    }
                    
                    Console.WriteLine("Wybierz element do usuniecia");
                    temp = 0;
                    foreach (char[,] idx in labyrinths)
                    {
                        temp++;
                        Console.WriteLine($"Labirynt #{temp}:");
                        for (int i = 0; i < idx.GetLength(0); i++)
                        {
                            for (int j = 0; j < idx.GetLength(1); j++)
                            {
                                Console.Write(idx[i, j]);
                            }
                            Console.WriteLine();
                        }
                    }
                    while (p != 1)
                    {
                        try
                        {
                            labyrinths.RemoveAt(Convert.ToInt32(Console.ReadLine()) - 1);
                            p = 1;
                        }
                        catch
                        {
                            Console.WriteLine("Nie ma takiego labiryntu");
                            
                        }
                    }
                    break;
                 case 4:
                    if(!labyrinths.Any())
                    {
                        Console.WriteLine("Nie ma zadnych zapisanych labiryntów");
                        break;
                    }
                    Console.WriteLine("Wybierz element do wyswietlenia");
                    temp = 0;
                    foreach (char[,] idx in labyrinths)
                    {
                        temp++;
                        Console.WriteLine($"Labirynt #{temp}:");
                        for (int i = 0; i < idx.GetLength(0); i++)
                        {
                            for (int j = 0; j < idx.GetLength(1); j++)
                            {
                                Console.Write(idx[i, j]);
                            }
                            Console.WriteLine();
                        }
                    }

                    while (p != 1)
                    {
                        try
                        {
                            int selectedLabyrinthIndex = Convert.ToInt32(Console.ReadLine())-1;
                            rows = labyrinths[selectedLabyrinthIndex].GetLength(0);
                            columns = labyrinths[selectedLabyrinthIndex].GetLength(1);
                            labyrinth = new char[rows, columns];
                            Array.Copy(labyrinths[selectedLabyrinthIndex], labyrinth, labyrinth.Length);
                            p = 1;
                        }
                        catch
                        {
                            Console.WriteLine("Nie ma takiego labiryntu");
                            
                        }
                    }
                    break;
                case 5:
                    char[,] labyrinthCopy = new char[rows, columns];
                    Array.Copy(labyrinth, labyrinthCopy, labyrinth.Length);
                    labyrinths.Add(labyrinthCopy);
                    Console.WriteLine("Labirynt zostal zapisany");
                    break;
                case 6:
                    Environment.Exit(0);
                    break;

            }
        }
    }
}