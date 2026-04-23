namespace LiftingApp.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }



        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
// This code defines a simple model class named `ErrorViewModel` within the `LiftingApp.Models` namespace. The class contains a nullable string property `RequestId` and a read-only boolean property `ShowRequestId` that returns true if `RequestId` is not null or empty. This model is typically used in error handling scenarios to display error information to the user.