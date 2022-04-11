using System;
using System.IO;

namespace lab3rpm
{

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Введите путь к папке, где вы хотите создать файл(ы):");
            string folder = Console.ReadLine();
            int repeatCount = 0;
            System.Console.WriteLine("Кол-во файлов для создания: ");
            int numOfReprat = int.Parse(Console.ReadLine());
            string folderPath = @"";

            do
            {
                var fullPathToCreate = System.IO.Path.Combine(folderPath, folder);
                var fileName = System.IO.Path.GetRandomFileName();
                fullPathToCreate = System.IO.Path.Combine(fullPathToCreate, fileName);
                var fileClose = System.IO.File.Create(fullPathToCreate);
                fileClose.Close();
                repeatCount++;
                System.Console.WriteLine("Файл создан " + repeatCount);
            } while (repeatCount != numOfReprat);
            
            for (int i = 0; i < 3; i++)
            {
                System.Console.WriteLine("Введите маску для поиска файлов: ");
                string filtSearch = Console.ReadLine();
                string fullPathToSeatch = System.IO.Path.Combine(folderPath, folder);
                string NewCatalog = System.IO.Path.Combine(fullPathToSeatch, @$"{filtSearch}");
                System.IO.Directory.CreateDirectory(NewCatalog);
                foreach (var fileSearched in Directory.GetFiles(fullPathToSeatch, $"*{filtSearch}*.*"))
                    {
                        System.Console.WriteLine(fileSearched);
                        string name = Path.GetFileName(fileSearched);
                        File.Move(fileSearched, NewCatalog + @"/" + name);
                        System.Console.WriteLine("Файл был пермещен в папку{0}", NewCatalog);

                    }
            }

            string fullPathToMoveA = System.IO.Path.Combine(folderPath, folder);
            string AllAnFilesDir = System.IO.Path.Combine(fullPathToMoveA, "AnotherFiles");
            System.IO.Directory.CreateDirectory(AllAnFilesDir);
            Console.WriteLine(AllAnFilesDir);
            foreach (var fileSearched in Directory.GetFiles(fullPathToMoveA, $"*.*"))
                {
                System.Console.WriteLine(fileSearched);
                string name = Path.GetFileName(fileSearched);
                File.Move(fileSearched, AllAnFilesDir + @"/" + name);
                System.Console.WriteLine("Файл был пермещен в папку{0}",AllAnFilesDir);
                }
        }
    }
}