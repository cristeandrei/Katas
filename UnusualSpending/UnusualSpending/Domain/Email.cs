namespace UnusualSpending.Domain;

public record Email
{
    public string Subject { get; init; } = "No subject";
    public string Content { get; private set; } = "";

    public void AddLine(string text) => Content += $"{text}/n";
}
