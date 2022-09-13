namespace SOLID_LSP_BAD.Models
{
    public class Penguin : Bird
    {
        public Penguin(string name) : base(name)
        {
        }

        public override void Fly()
        {
            // Do nothing
        }
    }
}
