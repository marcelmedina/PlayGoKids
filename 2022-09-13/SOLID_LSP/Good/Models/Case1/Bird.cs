namespace SOLID_LSP_GOOD.Models.Case1
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
    }
}
