namespace SOLID_ISP_BAD.Interfaces
{
    public interface IOrderProcessor
    {
        void Validate();

        void Save();

        void Notify();
    }
}
