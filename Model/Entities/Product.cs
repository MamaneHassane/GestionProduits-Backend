using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_SOMEI.Model.Entities;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    
    [Required(ErrorMessage = "Veuillez spécifier le nom du produit")]
    [StringLength(30,ErrorMessage = "Le nom du produit est trop long")]
    public string? ProductName { get; set; }
    
    [Required(ErrorMessage = "Veuillez spécifier la description du produit")]
    [StringLength(100,ErrorMessage = "La description du produit est trop longue")]
    public string? ProductDescription { get; set; }
    [Url]
    [StringLength(300,ErrorMessage = "L'Url de l'image du produit est trop longue")]
    public string? ProductImageUrl { get; set; }
}