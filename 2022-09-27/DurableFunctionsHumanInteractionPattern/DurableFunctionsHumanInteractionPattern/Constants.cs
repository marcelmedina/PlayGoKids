namespace DurableFunctionsHumanInteractionPattern
{
    public class Constants
    {
        public const string RunOrchestrator = "RunOrchestrator";
        public const string RunRequestApproval = "RunRequestApproval";
        public const string RunProcessApproval = "RunProcessApproval";
        public const string RunEscalation = "RunEscalation";
        public const string WaitForExternalApprovalEvent = "Approval";
        public const int Timeout = 72;
    }
}
