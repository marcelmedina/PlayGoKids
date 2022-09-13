using SOLID_LSP_GOOD.Interfaces;

namespace SOLID_LSP_GOOD.Models.Case2
{
    public class Bird : IRegularBird
    {
        public string Name { get; }

        public Bird(string name)
        {
            Name = name;
        }

        public virtual void Eat()
        {
            Console.WriteLine($"{Name} eats.");
        }

        public virtual void LayEggs()
        {
            Console.WriteLine($"{Name} lays eggs.");
        }
    }
}
