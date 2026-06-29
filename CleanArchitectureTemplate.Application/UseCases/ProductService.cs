using CleanArchitectureTemplate.Application.DTOs;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.UseCases;

public class ProductService 
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task AddSync(ProductDTO productDTO)
    {
        if(string.IsNullOrEmpty(productDTO.Name)) {
            throw new ArgumentException("Product name cannot be null");
        }

        if (productDTO.Price < 0)
        {
            throw new ArgumentException("Product price cannot be negative");
        }
     
        var product = new Product
        {
            Name = productDTO.Name,
            Price = productDTO.Price,
            Description = productDTO.Description,
            CreationDate = DateTime.UtcNow
        };

        await _productRepository.AddSync(product);
        
    }
 

    public async Task DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }

        await _productRepository.DeleteAsync(id);
    }

    public async Task<List<ProductDTO>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(product => new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description, 
            CreationDate = product.CreationDate
        }).ToList();
        

    }
   

    public async Task<ProductDTO> GetByIdAsync(int id)
    {
        var producto = await _productRepository.GetByIdAsync(id);

        if (producto == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }

        return new ProductDTO
        {
            Id = producto.Id,
            Name = producto.Name,
            Price = producto.Price,
            Description = producto.Description,
            CreationDate = producto.CreationDate
        };  
    }

    public Task<Product> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(ProductDTO productDTO)
    {
        if (productDTO == null)
        {
            new ArgumentNullException(nameof(productDTO), "ProductDTO cannot be null.");
        }

        var product = new Product
        {
            Id = productDTO.Id,
            Name = productDTO.Name,
            Price = productDTO.Price,
            Description = productDTO.Description,
            CreationDate = productDTO.CreationDate
        };

        await _productRepository.UpdateAsync(product);  
    }
}
