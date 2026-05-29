using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        public Pet() { }

        public Pet(string name, int age, double weight, double height)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
        }
    }
    public class Cat : Pet
    {
        public string FurColor { get; set; }
        public bool IsLazy { get; set; }

        public Cat()
        {
        }
        public Cat(string name, int age, double weight, double height, string color, bool isLazy) : base(name, age, weight, height)
        {
            FurColor = color;
            IsLazy = isLazy;
        }
    }
    public class Dog : Pet
    {
        public string Breed { get; set; } // порода 
        public bool KnowsCommands { get; set; }

        public Dog()
        {
        }
        public Dog(string name, int age, double weight, double height, string breed, bool knowsCommands) : base(name, age, weight, height)
        {
            Breed = breed;
            KnowsCommands = knowsCommands;
        }
    }
    public class Rabbit : Pet
    {
        public double EarLength { get; set; }
        public bool IsDomestic { get; set; } // домашний чи не

        public Rabbit()
        {
        }
        public Rabbit(string name, int age, double weight, double height, double earLength, bool isDomestic) : base(name, age, weight, height)
        {
            EarLength = earLength;
            IsDomestic = isDomestic;
        }
    }
    public class Parrot : Pet
    {
        public string Gender { get; set; }
        public bool IsTalking { get; set; }

        public Parrot()
        {
        }
        public Parrot(string name, int age, double weight, double height, string gender, bool isTalking) : base(name, age, weight, height)
        {
            Gender = gender;
            IsTalking = isTalking;
        }
    }
}
