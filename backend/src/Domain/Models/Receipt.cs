namespace Domain.Models;

public class Receipt
{
    public required Guid Id { get; set; }

    public required decimal Total { get; set; }

    public string Note { get; set; } = String.Empty;

    public required DateTimeOffset PrintedAt { get; set; }

    // Relationship

    public required Guid UserId { get; set; }

    public required Currency Currency { get; set; }

    public required Merchant Merchant { get; set; }
}
