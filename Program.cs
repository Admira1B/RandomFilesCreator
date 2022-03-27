using System;
using System.IO;

namespace RPM
{

    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Введите путь к папке, где вы хотите создать файл(ы):");
            string? folder = Console.ReadLine();
            int repeatCount = 0;
            System.Console.WriteLine("Кол-во файлов для создания: ");
            int numOfReprat = int.Parse(Console.ReadLine());
            
            do
            {
                string folderPATH = @"";
                folderPATH = System.IO.Path.Combine(folderPATH, folder);
                string fileName = System.IO.Path.GetRandomFileName();
                folderPATH = System.IO.Path.Combine(folderPATH, fileName);
                System.IO.File.Create(folderPATH);

                repeatCount++;
                System.Console.WriteLine("Файл создан " + repeatCount);
            } while (repeatCount != numOfReprat);
            
            System.Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
        }
    }
}