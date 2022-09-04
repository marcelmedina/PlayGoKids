using DurableFunctionsMonitorPattern.Models;
using DurableFunctionsMonitorPattern.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace DurableFunctionsMonitorPattern
{
    public class Activity
    {
        private readonly IImageProcessor _imageProcessor;
        private readonly ILogger<Activity> _logger;

        public Activity(IImageProcessor imageProcessor, ILogger<Activity> logger)
        {
            _imageProcessor = imageProcessor;
            _logger = logger;
        }

        [FunctionName(nameof(Constants.RunProcessImageActivity))]
        public void RunProcessImageActivity([ActivityTrigger] ImageDto imageDto)
        {
            _logger.LogInformation($"{nameof(RunProcessImageActivity)} for {imageDto.FileName}");

            _imageProcessor.Process(imageDto.FileName, imageDto.File);
        }

        [FunctionName(nameof(Constants.RunGetStatusImageActivity))]
        public ImageStatus RunGetStatusImageActivity([ActivityTrigger] string fileName)
        {
            _logger.LogInformation($"{nameof(RunGetStatusImageActivity)} for {fileName}");

            return _imageProcessor.GetStatus(fileName);
        }

        [FunctionName(nameof(Constants.RunSendAlertActivity))]
        public void RunSendAlertActivity([ActivityTrigger] string fileName)
        {
            _logger.LogInformation($"{nameof(RunSendAlertActivity)} for {fileName}");

            //TODO: send alert
        }
    }
}
