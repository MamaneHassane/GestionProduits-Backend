using TP_SOMEI.Entities;
using TP_SOMEI.Model.DTOs;

namespace TP_SOMEI.Repositories.Interfaces;

public interface IProductRepository
{
    // Lister tous les produits
    Task<IEnumerable<Product?>?> GetAllProducts();
    // Trouver un produit par son identifiant
    Task<Product?> FindProductById(int productId);
    // Ajouter un nouveau produit
    Task<Product?> AddProduct(ProductDto productDto);
    // Mettre à jour un produit
    Task<Product?> UpdateProduct(int productId, ProductDto productDto);
    // Supprimer un produit
    Task<bool?> DeleteProduct(int productId);
}