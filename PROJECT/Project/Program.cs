using Model;
namespace оProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ТЕСТИРОВАНИЕ НА МАССИВАХ (БЕЗ LIST) ===\n");

            // 1. Создаем питомцев
            Cat cat1 = new Cat("Мурзик", 3, 4.5, "Рыжий", true);
            Cat cat2 = new Cat("Барсик", 5, 6.0, "Черный", false);
            Cat cat3 = new Cat("Сима", 1, 2.8, "Белый", true);

            Dog dog1 = new Dog("Рекс", 4, 25.2, "Овчарка", true);
            Dog dog2 = new Dog("Шарик", 2, 12.0, "Дворняга", false);
            Dog dog3 = new Dog("Барон", 6, 35.0, "Лабрадор", true);

            Rabbit rabbit1 = new Rabbit("Пушок", 1, 1.5, 12.5, false);
            Rabbit rabbit2 = new Rabbit("Зубастик", 2, 2.1, 14.0, true);

            // 2. Создаем приюты
            Shelter shelter1 = new Shelter("Приют 'Добрые руки'", 15, true);
            Shelter shelter2 = new Shelter("Приют 'Уютный дом'", 10, false);
            Shelter shelter3 = new Shelter("Приют 'Лесной уголок'", 20, true);

            // Массив для контроля уникальности (максимум 20 животных по ТЗ)
            Pet[] assignedPets = new Pet[20];
            int assignedCount = 0;

            // Распределяем питомцев по приютам через наш метод с проверкой
            TryAddPet(cat1, shelter1, assignedPets, ref assignedCount);
            TryAddPet(cat2, shelter1, assignedPets, ref assignedCount);
            TryAddPet(dog1, shelter1, assignedPets, ref assignedCount);

            TryAddPet(cat3, shelter2, assignedPets, ref assignedCount);
            TryAddPet(dog2, shelter2, assignedPets, ref assignedCount);
            TryAddPet(rabbit1, shelter2, assignedPets, ref assignedCount);

            TryAddPet(dog3, shelter3, assignedPets, ref assignedCount);
            TryAddPet(rabbit2, shelter3, assignedPets, ref assignedCount);

            // ПРОВЕРКА ОГРАНИЧЕНИЯ: Пробуем добавить Мурзика (cat1) повторно в shelter2
            Console.WriteLine("--- Проверка ограничения на дублирование животного ---");
            TryAddPet(cat1, shelter2, assignedPets, ref assignedCount);
            Console.WriteLine();

            // 3. Выводим статистику приютов (массив приютов)
            Shelter[] allShelters = new Shelter[] { shelter1, shelter2, shelter3 };

            for (int i = 0; i < allShelters.Length; i++)
            {
                Shelter currentShelter = allShelters[i];
                Console.WriteLine($"=== СТАТИСТИКА: {currentShelter.Name} ===");
                Console.WriteLine($"Всего животных: {currentShelter.Count()} из {currentShelter.Capacity}");
                Console.WriteLine($"Кошек: {currentShelter.Count(typeof(Cat))} ({currentShelter.Percentage(typeof(Cat))}% от общего числа)");
                Console.WriteLine($"Собак: {currentShelter.Count(typeof(Dog))} ({currentShelter.Percentage(typeof(Dog))}% от общего числа)");
                Console.WriteLine($"Кроликов: {currentShelter.Count(typeof(Rabbit))} ({currentShelter.Percentage(typeof(Rabbit))}% от общего числа)");
                Console.WriteLine();
            }

            // 4. Проверяем работу IFilter
            Console.WriteLine("=== ТЕСТИРОВАНИЕ ФИЛЬТРАЦИИ ===");
            Console.WriteLine($"Фильтруем '{shelter1.Name}' по типу Собаки (Dog):");

            Pet[] filteredDogs = shelter1.Filter(typeof(Dog));
            for (int i = 0; i < filteredDogs.Length; i++)
            {
                Dog dog = (Dog)filteredDogs[i];
                Console.WriteLine($"- Кличка: {dog.Name}, Возраст: {dog.Age}, Порода: {dog.Breed}");
            }

            Console.ReadLine();
        }

        // Вспомогательный метод добавления без использования коллекций
        static void TryAddPet(Pet pet, Shelter shelter, Pet[] assigned, ref int assignedCount)
        {
            // Проверяем, нет ли уже этого питомца в массиве занятых
            for (int i = 0; i < assignedCount; i++)
            {
                if (assigned[i] == pet)
                {
                    Console.WriteLine($"[ОШИБКА]: Питомец {pet.Name} уже находится в одном из приютов!");
                    return;
                }
            }

            // Пытаемся добавить в приют
            if (shelter.AddPet(pet))
            {
                assigned[assignedCount] = pet;
                assignedCount++;
            }
            else
            {
                Console.WriteLine($"[ОШИБКА]: Не удалось добавить {pet.Name}. Приют заполнен.");
            }
        }
    }
}
