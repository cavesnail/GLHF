using System.Runtime.InteropServices;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("e0dfdabc-a361-4bed-9a1c-6b8bd7bf9c7a")]

namespace GLHF.Server.Models;
public class Purchase
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public DateTime PurchasedAt { get; set; }
    public required int Quantity { get; set; }
    public required decimal UnitPrice { get; set; }
    public string? Description { get; set; }


}
public class PurchaseSimple
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime PurchasedAt { get; set; }
    public decimal totalCost { get; set; }
    public void SetTotalCost(int Quantity, decimal UnitPrice)
    {
        totalCost = UnitPrice * Quantity;
    }

    public void GenerateFromPurchase(Purchase purchase)
    {
        Id = purchase.Id;
        Name = purchase.Name;
        PurchasedAt = purchase.PurchasedAt;
        SetTotalCost(purchase.Quantity, purchase.UnitPrice);
    }
}