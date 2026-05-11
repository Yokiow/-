using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;// добавили библиотеку

namespace _11._05._2026
{
    public class Game // желательно чтобы было про один обьект 
    {
        private string _name;
        private int _ocenka;
        private int[] _rating;

        public string Name => _name;
        public int Ocenka => _ocenka;
        public int[] Rating => _rating.ToArray();

        public Game(string name, int ocenka)
        {
            _name = name;
            _ocenka = ocenka;
            _rating = new int[0];
        }
        public void Add(int stars)
        {
            Array.Resize(ref _rating, _rating.Length+1);
            _rating[_rating.Length - 1] = stars;
        }
    }
    public class GameDTO
    {
        public string Name { get; set; }
        public int Ocenka { get; set; }
        public int[] Rating { get; set; }
        // Конструкторы для сериализации Game
        public GameDTO() // для сериализации
        {
        }
        public GameDTO(string name, int ocenka) // 1 варианта для обычного обьекта в ДТО обьект
        {
            Name = name;
            Ocenka = ocenka;
            Rating = new int[0];
        }
        public GameDTO(GameDTO game) // 2 вариант
        {
            Name = game.Name;
            Ocenka = game.Ocenka;
            Rating = new int[0];
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Построи путь для рабочего стала  и создаем путь для файла xml
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(folderPath, "game.xml");

            // Создаем XML-сериализатор
            // - класс должен иметь конструктор без параматеров
            // - класс должен быть публичным
            // - в классе все свойства должна быть публичными get и set

            // Оригинальный обьект -> DTO обьект -> отдать его в сериализатор
            // Обьект для сериализации

            Game game = new Game("Minecraft", 100);
            game.Add(5);
            game.Add(6);
            game.Add(7);
            GameDTO gameDTO = new GameDTO(game.Name, game.Ocenka);

            var serializer = new XmlSerializer(typeof(GameDTO));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, gameDTO);
            }
            // десереализует обьект из файла -> полоучаем DTO обьект -> оригнальнрый обьект
            GameDTO gameDTO2;
            using( var reader = new StreamReader(filePath))
            {
                gameDTO2 = (GameDTO)serializer.Deserialize(reader);
            }
            Game game2 = new Game(gameDTO2.Name, gameDTO2.Ocenka); // десериализация обьект
            if (CompareGame(game, game2))
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Smt is wrong");
            }
        }
        private static bool CompareGame(Game g1, Game g2)
        {
            if (g1.Name != g2.Name) return false;
            if (g1.Ocenka != g2.Ocenka) return false;

            return true;
        }
    }
}
