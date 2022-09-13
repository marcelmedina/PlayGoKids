using SOLID_LSP_GOOD.Interfaces;

namespace SOLID_LSP_GOOD.Models.Case2
{
    public class FlyingBird : IRegularBird, IFlyingBird
    {
        public string Name { get; }

        public FlyingBird(string name)
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

        public virtual void Fly()
        {
            Console.WriteLine($"{Name} can fly.");
        }
    }
}
