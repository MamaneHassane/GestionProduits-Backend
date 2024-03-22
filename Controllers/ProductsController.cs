using Microsoft.AspNetCore.Mvc;
using TP_SOMEI.Entities;
using TP_SOMEI.Model.DTOs;
using TP_SOMEI.Repositories.Interfaces;

namespace TP_SOMEI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProductsController(IProductRepository productRepository) : ControllerBase
{
    private readonly IProductRepository _productRepository = productRepository;
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product?>>?> GetAllProducts()
    {
        try
        {
            return Ok( await productRepository.GetAllProducts());
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Une erreur s'est produite lors de la recherche exhaustive des produits");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product?>?> GetProductById(int id)
    {
        try
        {
            var theProduct = await productRepository.FindProductById(id);
            if (theProduct is not null) return Ok(theProduct);
            return NotFound($"Le produit avec l'identifiant "+ id + " n'existe pas dans la base de données");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Une erreur s'est produite lors de la recherche du produit par identifiant: identifiant = " + id);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Product?>?> AddProduct([FromBody] ProductDto productDto)
    {
        try
        {
            var theProduct = await productRepository.AddProduct(productDto);
            if(theProduct is not null) return Ok(theProduct);
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Une erreur s'est produite lors de la création de produit");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Une erreur s'est produite lors de la création de produit");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Product?>?> UpdateProduct([FromRoute] int id, [FromBody] ProductDto productDto)
    {
        try
        {
            return Ok(await productRepository.UpdateProduct(id,productDto));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Une erreur s'est produite lors de la mise à jour du produit");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Product?>> DeleteProduct(int id)
    {
        try
        {
            return Ok(await productRepository.DeleteProduct(id));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Une erreur s'est produite lors de la suppression du produit");
        }
    }
}