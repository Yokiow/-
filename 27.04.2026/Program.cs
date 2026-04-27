using Newtonsoft.Json;

namespace ClassWOrk
{
    internal class Program
    {
        public class Movie
        {
            private string _name;
            private int _duration;
            private int[] _review;

            public string Name => _name;
            public int Duration => _duration;
            public int[] Review => _review;

            public Movie(string name,int duration)
            {
                _name = name;
                _duration = duration;
                _review = new int[0];
            }
            public void Add(int num)
            {
                Array.Resize(ref _review, num);
                _review[^1] = num;
            }
        }
        static void Main(string[] args)
        {
            Movie movie1 = new Movie("Fight Club", 102);
            movie1.Add(5);
            movie1.Add(6);
            movie1.Add(4);

            // --- сериализация ---
            var temp = new
            {
                movie1.Name,
                movie1.Duration,
                movie1.Review
            };

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(folderPath, "Test", "example.json");

            string json = JsonConvert.SerializeObject(temp);
            Console.WriteLine(json);

            // --- десериализация --
            string content = File.ReadAllText(filePath);
            var newJson = JsonConvert.DeserializeObject<dynamic>(content);

            Movie movie2 = new Movie(newJson.Name, newJson.Duration);
            foreach (var n in newJson.Review)
            {
                movie2.Add((int)n);
            }
        }
        
        //static void Main(string[] args)
        //{
        //    // --- Получение путей к папкам ---

        //    // --- Абсолютный путь --- подходит только на мой пк, на другом пк другой путь
        //    //
        //    // --- Относительный путь (Relative path) ---
        //    // "data.txt" - (файл), "dataset/data.txt" - (папка/файл)

        //    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //.MyDocuments
        //    string filePath = Path.Combine(folderPath,"Test", "example.txt"); // соединяет пути вместо folder
        //    //Console.WriteLine(folderPath);
        //    //Console.WriteLine(filePath);

        //    string folderPath1 = Path.Combine(folderPath, "Test");
        //    string filePath1 = Path.Combine(folderPath1, "example.txt");

        //    string folderPathCheck = Path.GetDirectoryName(filePath1);
        //    string fileNameCheck = Path.GetFileName(filePath1);
        //    string fileExtCheck = Path.GetExtension(filePath1);
        //    //Console.WriteLine(folderPathCheck);

        //    if (Directory.Exists(folderPath1))
        //    {
        //        Directory.CreateDirectory(folderPath1);
        //    }
        //    if (File.Exists(filePath))
        //    {
        //        File.CreateText(filePath).Close();
        //    }
        //    File.WriteAllText(filePath, "Hey!!"); 
        //    File.WriteAllLines(filePath, new string[] { "So", "cold", "today", "ew"});
        //    // в папке Test в файле example пишет это, перезаписывает ифну если текст меняем
        //    // Если файла не было - создает и записывает, если был, то перезаписывает

        //    //File.WriteAllText(filePath, ""); // убирает то что было до 
        //    File.AppendAllText(filePath, "Wohooo");
        //    File.AppendAllLines(filePath, new string[] { " ", "I", "want", "sun" });

        //    string content = File.ReadAllText(filePath);
        //    string[] Lines = File.ReadAllLines(filePath);
        //    Console.WriteLine(content); // вывело то, что в файле
        //    foreach (string line in Lines)
        //    {
        //        //Console.WriteLine(line);
        //    }

        //    //Console.WriteLine(folderPath1);
        //    //if (Directory.Exists(folderPath1))
        //    //{
        //    //    Console.WriteLine("есть папка");
        //    //}
        //    //else
        //    //{
        //    //    Console.WriteLine("нету папки");
        //    //    Directory.CreateDirectory(folderPath1); // после этого второй раз запустить и выведет, что папка есть
        //    //    Console.WriteLine("создан");
        //    //}

        //    //if (File.Exists(filePath)) // провка существует ли файл
        //    //{
        //    //    Console.WriteLine("файл существует на компьютере");
        //    //}
        //    //else
        //    //{
        //    //    Console.WriteLine("не существует указанный файл");
        //    //    File.CreateText(filePath).Close(); // возвращает поток
        //    //    Console.WriteLine("файл создан");
        //    //}
        //    //File.CreateText(filePath).Close();

        //}
    }
}
