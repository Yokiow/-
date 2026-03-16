using System.Threading.Channels;

namespace ClassWork5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Humans human1 = new Humans(95, "Vovchik");
            Boy boy1 = new Boy( 25, "Mixail", 50);
            
            human1.Method();
            boy1.Print();
            human1.Print();
            Humans vovсhik = new Boy(4, "No Vovchik", 10);

            vovсhik.Method(); // вывод - Boy method
            vovсhik.Print(); // вывод - Не вовчик 10

            Boy boy2 = vovсhik as Boy; // вовчик в классе boys а не human
            boy2.Print();
        }
    }
    public class Humans
    {
        // поля
        protected string _name; // чтобы в наследниках были видны переменные, надо ставить protected
        protected int _age;
        // свойства
        public string Name  => _name;
        public int Age => _age;
        // rjycnhernjh 
        public Humans(int age, string name)
        {
            _age = age;
            _name = name;
        }
        public virtual void Method() //virtual - якобы разрешение от родителей
        {
            Console.WriteLine("method");
        }
        public virtual void Voice()
        {
            Console.WriteLine("хз");
        }
        public void Print()
        {
            Console.WriteLine(_name + " " + _age);
        }
    }
    public class Boy : Humans
    {
        // поле
        private int _voice; 
        // свойство
        public int Voicу => _voice;
        public Boy(int age, string name, int voice) : base(age, name) // важно смотреть до ":"
        {
            _age += 5;
            _voice = voice;
        }
        public override void Method() // override - право поменять
        {
            Console.WriteLine("Boy method");
        }
        public override void Voice()
        {
            Console.WriteLine("бе-бе-бе");
        }
        public void Print()
        {
            Console.WriteLine(_age + " " + _name + " " + _voice);
        }
    }
}
