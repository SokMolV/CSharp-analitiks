using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloApp
{
  class Person
  {
    public string Name { get; set; }
    public int Age { get; set; }
  }
  class User
  {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Company { get; set; }
  }
  class Program
  {
    static async Task ghf()
    {
      Person marya = new Person { Name = "Marya", Age = 19 };
      string json = JsonSerializer.Serialize<Person>(marya);
      Console.WriteLine(json);
      Person restoredPerson = JsonSerializer.Deserialize<Person>(json);
      Console.WriteLine(restoredPerson.Name);
      // сохранение данных
      using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
      {
        Person tom = new Person() { Name = "Tom", Age = 35 };
        await JsonSerializer.SerializeAsync<Person>(fs, tom);
        Console.WriteLine("Data has been saved to file");
      }

      // чтение данных
      using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
      {
        Person restoredPerson_2 = await JsonSerializer.DeserializeAsync<Person>(fs);
        Console.WriteLine($"Name: {restoredPerson_2.Name}  Age: {restoredPerson_2.Age}");
      }

      FileInfo fileGInf = new FileInfo("user.json");
      if (fileGInf.Exists)
      {
        fileGInf.Delete();
        // альтернатива с помощью класса File
        // File.Delete(path);
      }
    }
    static void Main(string[] args)
    {
      DriveInfo[] drives = DriveInfo.GetDrives();

      foreach (DriveInfo drive in drives)
      {
        Console.WriteLine($"Название: {drive.Name}");
        Console.WriteLine($"Тип: {drive.DriveType}");
        if (drive.IsReady)
        {
          Console.WriteLine($"Объем диска: {drive.TotalSize}");
          Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
          Console.WriteLine($"Метка: {drive.VolumeLabel}");
        }
        Console.WriteLine();
      }
      string dirName = "C:\\";

      if (Directory.Exists(dirName))
      {
        Console.WriteLine("Подкаталоги:");
        string[] dirs = Directory.GetDirectories(dirName);
        foreach (string s in dirs)
        {
          Console.WriteLine(s);
        }
        Console.WriteLine();
        Console.WriteLine("Файлы:");
        string[] files = Directory.GetFiles(dirName);
        foreach (string s in files)
        {
          Console.WriteLine(s);
        }
      }

      string path = @"C:\SomeDir";
      string subpath = @"program\avalon";
      DirectoryInfo dirInfo = new DirectoryInfo(path);
      if (!dirInfo.Exists)
      {
        dirInfo.Create();
      }
      dirInfo.CreateSubdirectory(subpath);

      string dirSName = "C:\\Program Files";

      DirectoryInfo dirSInfo = new DirectoryInfo(dirSName);

      Console.WriteLine($"Название каталога: {dirSInfo.Name}");
      Console.WriteLine($"Полное название каталога: {dirSInfo.FullName}");
      Console.WriteLine($"Время создания каталога: {dirSInfo.CreationTime}");
      Console.WriteLine($"Корневой каталог: {dirSInfo.Root}");

      string dirMName = @"C:\SomeFolder";

      try
      {
        DirectoryInfo dirMInfo = new DirectoryInfo(dirMName);
        dirInfo.Delete(true);
        Console.WriteLine("Каталог удален");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      string oldPath = @"C:\SomeFolder";
      string newPath = @"C:\SomeDir";
      DirectoryInfo dirVInfo = new DirectoryInfo(oldPath);
      if (dirInfo.Exists && Directory.Exists(newPath) == false)
      {
        dirVInfo.MoveTo(newPath);
      }

      // создаем каталог для файла
      string path2 = @"C:\SomeDir2";
      DirectoryInfo dirLInfo = new DirectoryInfo(path2);
      if (!dirLInfo.Exists)
      {
        dirLInfo.Create();
      }
      Console.WriteLine("Введите строку для записи в файл:");
      string text = Console.ReadLine();

      // запись в файл
      using (FileStream fstream = new FileStream($"{path2}/note.txt", FileMode.OpenOrCreate))
      {
        // преобразуем строку в байты
        byte[] array = System.Text.Encoding.Default.GetBytes(text);
        // запись массива байтов в файл
        fstream.Write(array, 0, array.Length);
        Console.WriteLine("Текст записан в файл");
      }

      // чтение из файла
      using (FileStream fstream = File.OpenRead($"{path2}/note.txt"))
      {
        // преобразуем строку в байты
        byte[] array = new byte[fstream.Length];
        // считываем данные
        fstream.Read(array, 0, array.Length);
        // декодируем байты в строку
        string textFromFile = System.Text.Encoding.Default.GetString(array);
        Console.WriteLine($"Текст из файла: {textFromFile}");
      }
      string path3 = ($"{path2}/note.txt");
      FileInfo fileInf = new FileInfo(path3);
      if (fileInf.Exists)
      {
        fileInf.Delete();
        // альтернатива с помощью класса File
        // File.Delete(path);
      }

  
      ghf();

      
    }
  }
}