﻿using TP_SOMEI.Model.DTOs;
using TP_SOMEI.Model.Entities;

namespace TP_SOMEI.Repositories.Interfaces;

public interface IProductRepository
{
    // Lister tous les produits
    Task<IEnumerable<Product?>?> GetAllProductsByUser(string userId);
    // Lister par page, nombre d'éléments par page par défaut = 20
    Task<IEnumerable<Product>> GetProductsByUserAndPageNumber(string userId, int pageNumber);
    // Lister par page et nombre d'éléments par page
    Task<IEnumerable<Product>> GetProductsByUserAndPageNumberAndPageSize(string userId, int pageNumber, int pageSize);
    // Trouver un produit par son identifiant
    Task<Product?> FindProductByUserAndId(string userId, int productId);
    // Ajouter un nouveau produit
    Task<Product?> AddProduct(ProductDto productDto);
    // Mettre à jour un produit
    Task<Product?> UpdateProduct(int productId, ProductDto productDto);
    // Supprimer un produit
    Task<bool?> DeleteProduct(int productId);
}