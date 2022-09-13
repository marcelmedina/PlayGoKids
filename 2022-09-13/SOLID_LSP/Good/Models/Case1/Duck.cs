namespace SOLID_LSP_GOOD.Models.Case1
{
    public class Duck : Bird
    {
        public Duck(string name) : base(name)
        {
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} can fly.");
        }
    }
}
