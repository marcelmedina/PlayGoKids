namespace SOLID_LSP_BAD.Models
{
    public class Bird
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

        public virtual void Fly() // can all birds fly?
        {
            Console.WriteLine($"{Name} can fly.");
        }
    }
}
