namespace SOLID_LSP_BAD.Models
{
    public class Kiwi : Bird
    {
        public Kiwi(string name) : base(name)
        {
        }

        public override void Fly()
        {
            throw new Exception("Kiwi birds can't fly.");
        }
    }
}
