using ClassWork_18._03._2023;
using System;
using System.Diagnostics.Metrics;

//var obj = new Catalog(0);
var obj = new Catalog();
Main();
void Main()
{
    Console.CursorVisible = false;
    DisplayMenu();
    int index = 2;
    while (true)
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.UpArrow:
                {
                    if (index > 2)
                        SelectMenuItem(--index, index + 1);
                    break;
                }
            case ConsoleKey.DownArrow:
                {
                    if (index < obj.Directories.Count + 1)
                        SelectMenuItem(++index, index - 1);
                    break;
                }
            case ConsoleKey.LeftArrow: 
                {
                    UpdateMenu(obj.Parent, ref index);
                    break;
                }
            case ConsoleKey.RightArrow:
                {
                    if (obj.Directories.Count > 0)
                        UpdateMenu(obj.Directories[index - 2], ref index);
                    break;
                }
        }
    }

    void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine($"Текущий каталог: {obj.SelectDirectoryPath} " + "\n" + "----------------------------------------------------------------------------------------");
        foreach (var item in obj.Directories)
        {
            Console.WriteLine(item == obj.Directories.First() && obj.IsCatalog
                ? " -> " + item
                : "    " + item);
        }
    }


    void SelectMenuItem(int end, int start)
    {
        for (int i = start; ; i = end)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine(i == start
                ? "    " : " -> " + obj.Directories[i - 2]);
            if (i == end) break;
        }
    }

    void UpdateMenu(string item, ref int index)
    {
        if (item is "root")
            obj.GetRootCatalog();
        else
            obj.UpdateCatalog(item);
        DisplayMenu();
        index = 2;
    }
}

