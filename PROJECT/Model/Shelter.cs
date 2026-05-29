using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Shelter : ICountable, IFilter
    {
        public string Name { get; set; }
        public int Capacity { get; set; } // вместимость 
        public bool HasOpenArea { get; set; } // наличие открытой территории

        // массив фиксированной длины для хранения питомцев
        public Pet[] Pets { get; set; }

        // счетчик, сколько животных сейчас в приюте
        private int currentPetCount = 0;

        public Shelter() { }

        public Shelter(string name, int capacity, bool hasOpenArea)
        {
            Name = name;
            Capacity = capacity;
            HasOpenArea = hasOpenArea;

            // Инициализируем массив размером под максимальную вместимость
            Pets = new Pet[capacity];
        }

        // Метод для добавления животного в массив (вместо .Add())
        public bool AddPet(Pet pet)
        {
            if (currentPetCount >= Capacity)
            {
                return false; // Приют заполнен
            }

            Pets[currentPetCount] = pet;
            currentPetCount++;
            return true;
        }

        // --- Реализация ICountable ---

        public int Count()
        {
            return currentPetCount;
        }

        public int Count(Type type)
        {
            int count = 0;
            for (int i = 0; i < currentPetCount; i++)
            {
                if (Pets[i].GetType() == type)
                    count++;
            }
            return count;
        }

        public int Percentage(Type type)
        {
            if (currentPetCount == 0) return 0;

            double percent = (double)Count(type) / currentPetCount * 100;
            return (int)Math.Round(percent);
        }

        // --- Реализация IFilter ---

        public Pet[] Filter(Type type)
        {
            // Если тип не задан (null), возвращаем массив только с заполненными животными
            if (type == null)
            {
                Pet[] allActivePets = new Pet[currentPetCount];
                for (int i = 0; i < currentPetCount; i++)
                {
                    allActivePets[i] = Pets[i];
                }
                return allActivePets;
            }

            // Сначала считаем, сколько животных подходят под фильтр
            int matchCount = Count(type);

            // Создаем результирующий массив точного размера
            Pet[] filtered = new Pet[matchCount];
            int index = 0;

            for (int i = 0; i < currentPetCount; i++)
            {
                if (Pets[i].GetType() == type)
                {
                    filtered[index] = Pets[i];
                    index++;
                }
            }
            return filtered;
        }
    }
}
