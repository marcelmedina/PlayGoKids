using System.Diagnostics;
using System.Text.Json;
using OpenTelemetry;

namespace OpenTelemetryExporter
{
    class MyConsoleExporter : BaseExporter<Activity>
    {
        private readonly string _name;

        public MyConsoleExporter(string name = "MyConsoleExporter")
        {
            this._name = name;
        }

        public override ExportResult Export(in Batch<Activity> batch)
        {
            // SuppressInstrumentationScope should be used to prevent exporter
            // code from generating telemetry and causing live-loop.
            using var scope = SuppressInstrumentationScope.Begin();

            foreach (var activity in batch)
            {
                ConsoleWriteData($"{activity.StartTimeUtc:o}");
                ConsoleWriteData($"{activity.Status}");
                ConsoleWriteData("NAME", activity.DisplayName);
                ConsoleWriteData("TRACE-ID", activity.TraceId.ToString());
                ConsoleWriteData("BAGGAGE", JsonSerializer.Serialize(activity.Baggage));

                foreach (var ev in activity.Events)
                {
                    ConsoleWriteData("EVENT", $"{ev.Name}:{JsonSerializer.Serialize(ev.Tags)}");
                }

                Console.WriteLine();
            }

            return ExportResult.Success;
        }

        private void ConsoleWriteData(string title, string? content = null)
        {
            Console.Write(!string.IsNullOrEmpty(content) ? $"[{title} \"{content}\"]" : $"[{title}]");
        }
    }
}