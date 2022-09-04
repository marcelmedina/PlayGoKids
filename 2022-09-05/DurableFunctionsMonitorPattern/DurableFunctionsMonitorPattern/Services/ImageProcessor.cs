namespace DurableFunctionsMonitorPattern.Services
{
    public interface IImageProcessor
    {
        void Process(string fileName, byte[] file);
        ImageStatus GetStatus(string fileName);
    }

    public enum ImageStatus
    {
        Processing,
        Processed
    }

    public class ImageProcessor : IImageProcessor
    {
        public void Process(string fileName, byte[] file)
        {
            //TODO: process image
        }

        public ImageStatus GetStatus(string fileName)
        {
            //TODO: check status dynamically
            return ImageStatus.Processed;
        }
    }
}
