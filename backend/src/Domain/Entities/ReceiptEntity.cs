namespace Domain.Entities;

public class ReceiptEntity : BaseEntity
{
    // This maps to Numeric in PostgreSQL
    public required decimal Total { get; set; }

    public string Note { get; set; } = string.Empty;

    public required DateTimeOffset PrintedAt { get; set; }

    // Relationship

    public required string CurrencyCode { get; set; }

    public required Guid UserId { get; set; }

    public required Guid MerchantId { get; set; }
}
