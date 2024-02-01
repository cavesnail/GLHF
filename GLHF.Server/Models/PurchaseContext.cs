namespace GLHF.Server.Models;

public interface IPurchaseRepository
{
    IEnumerable<Purchase> GetPurchases();
    Purchase? GetPurchase(long id);
}
public class PurchaseRepository : IPurchaseRepository
{
    private readonly IEnumerable<Purchase> _purchases = new List<Purchase>
    {
        new() { Id = 1, Name = "Block Blob Storage V2", PurchasedAt = Date(1, 1), Quantity = 3, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 2, Name = "Power BI Embedded A5", PurchasedAt = Date(1, 2), Quantity = 1, UnitPrice = 22.55m, Description = Desc },
        new() { Id = 3, Name = "D2 V3 Compute", PurchasedAt = Date(1, 4), Quantity = 4, UnitPrice = 7.95m, Description = Desc },
        new() { Id = 4, Name = "Azure SQL Database S9 1600 DTU", PurchasedAt = Date(1, 5), Quantity = 7, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 5, Name = "B1 App Service", PurchasedAt = Date(1, 12), Quantity = 2, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 6, Name = "Azure Function C Tier", PurchasedAt = Date(1, 15), Quantity = 2, UnitPrice = 22.55m, Description = Desc },
        new() { Id = 7, Name = "Table Storage S LRS", PurchasedAt = Date(1, 19), Quantity = 1, UnitPrice = 4.49m, Description = Desc },
        new() { Id = 8, Name = "Power BI Embedded A5", PurchasedAt = Date(1, 24), Quantity = 3, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 9, Name = "P1V2 App Service", PurchasedAt = Date(1, 27), Quantity = 5, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 10, Name = "D2 V3 Compute", PurchasedAt = Date(1, 28), Quantity = 2, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 11, Name = "Queue Storage GV2 LRS", PurchasedAt = Date(2, 3), Quantity = 2, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 12, Name = "P1V2 App Service", PurchasedAt = Date(2, 4), Quantity = 3, UnitPrice = 22.55m, Description = Desc },
        new() { Id = 13, Name = "P2V2 App Service", PurchasedAt = Date(2, 5), Quantity = 3, UnitPrice = 22.55m, Description = Desc },
        new() { Id = 14, Name = "Power BI Embedded A3", PurchasedAt = Date(2, 9), Quantity = 3, UnitPrice = 4.49m, Description = Desc },
        new() { Id = 15, Name = "HX 176 Compute", PurchasedAt = Date(2, 11), Quantity = 3, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 16, Name = "Azure SQL Database S3 100 DTU", PurchasedAt = Date(2, 12), Quantity = 4, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 17, Name = "Table Storage S LRS", PurchasedAt = Date(2, 14), Quantity = 5, UnitPrice = 7.95m, Description = Desc },
        new() { Id = 18, Name = "Azure SQL Database S3 100 DTU", PurchasedAt = Date(2, 20), Quantity = 3, UnitPrice = 7.95m, Description = Desc },
        new() { Id = 19, Name = "Azure Files", PurchasedAt = Date(2, 21), Quantity = 3, UnitPrice = 7.95m, Description = Desc },
        new() { Id = 20, Name = "Power BI Embedded A7", PurchasedAt = Date(2, 26), Quantity = 2, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 21, Name = "D2 V3 Compute", PurchasedAt = Date(3, 1), Quantity = 7, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 22, Name = "HX 176 Compute", PurchasedAt = Date(3, 3), Quantity = 2, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 23, Name = "Azure Function C Tier", PurchasedAt = Date(3, 4), Quantity = 6, UnitPrice = 4.49m, Description = Desc },
        new() { Id = 24, Name = "S1 App Service", PurchasedAt = Date(3, 6), Quantity = 1, UnitPrice = 4.49m, Description = Desc },
        new() { Id = 25, Name = "Block Blob Storage V2", PurchasedAt = Date(3, 11), Quantity = 1, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 26, Name = "HC 44 Compute", PurchasedAt = Date(3, 21), Quantity = 3, UnitPrice = 7.95m, Description = Desc },
        new() { Id = 27, Name = "HX 176 Compute", PurchasedAt = Date(3, 22), Quantity = 4, UnitPrice = 4.49m, Description = Desc },
        new() { Id = 28, Name = "Azure SQL Database S9 1600 DTU", PurchasedAt = Date(3, 23), Quantity = 3, UnitPrice = 12.95m, Description = Desc },
        new() { Id = 29, Name = "S2 App Service", PurchasedAt = Date(3, 26), Quantity = 1, UnitPrice = 22.55m, Description = Desc },
        new() { Id = 30, Name = "Table Storage S LRS", PurchasedAt = Date(3, 28), Quantity = 7, UnitPrice = 12.95m, Description = Desc }
    };

    public IEnumerable<Purchase> GetPurchases()
    {
        return _purchases.ToList();
    }

    public Purchase? GetPurchase(long id)
    {
        return _purchases.SingleOrDefault(p => p.Id == id);
    }

    private const string Desc =
        "A string is an object of type String whose value is text. Internally, the text is stored as a sequential " +
        "read-only collection of Char objects. There's no null-terminating character at the end of a C# string; " +
        "therefore a C# string can contain any number of embedded null characters ('\\0'). The Length property of a " +
        "string represents the number of Char objects it contains, not the number of Unicode characters. To access " +
        "the individual Unicode code points in a string, use the StringInfo object.";

    private static DateTime Date(int month, int day)
    {
        return new DateTime(2023, month, day);
    }
}
