namespace Pluralsight.CShPlaybook.NullValues;
public enum MessageStatus { Info, Warning, Error }
public class Message
{
    public string Header { get; init; }
    public string Details { get; init; }
    public MessageStatus Status { get; init; }

    public Message(MessageStatus status, string header, string details = null)
    {
        if (string.IsNullOrWhiteSpace(header))
            throw new ArgumentNullException(nameof(status), "Status must have a header");
        this.Status = status;
        this.Header = header;
        this.Details = details;
    }
}