using Microsoft.AspNetCore.Identity;

namespace TP_SOMEI.Model.Entities;

public class User : IdentityUser
{
    // Identity User qui possède une liste de produits
    public IEnumerable<Product>? Products { get; set; } = new List<Product>();
}