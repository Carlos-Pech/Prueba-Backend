using backend.Core.Interfaces;
using backend.Data;
using backend.DTOs.Product;
using backend.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;

        }
        // GET ALL
        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            return await _context.Products
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    IsActive = p.IsActive
                })
                .ToListAsync();
        }

        //Get product by id
        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            if (product == null)
                return null;

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                IsActive = product.IsActive
            };
        }

        //Create a new product
        public async Task<ProductResponseDto> CreateAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                IsActive = product.IsActive,
                 CreatedAt = product.CreatedAt

            };
        }
        
        //Update an existing product
        // UPDATE
        public async Task<ProductResponseDto?> UpdateAsync(int id, ProductUpdateDto dto)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            if (product == null)
                return null;

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            await _context.SaveChangesAsync();

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                IsActive = product.IsActive
            };
        }
        public async Task<ProductResponseDto?> PatchAsync(int id, ProductPatchDto dto)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id );

            if (product == null)
                return null;

            if (dto.Name != null)
                product.Name = dto.Name;

            if (dto.Price.HasValue)
                product.Price = dto.Price.Value;

            if (dto.Stock.HasValue)
                product.Stock = dto.Stock.Value;

            if (dto.IsActive.HasValue)
                product.IsActive = dto.IsActive.Value;



            await _context.SaveChangesAsync();

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                IsActive = product.IsActive
            };
        }

        //Delete a product
        // DELETE (soft delete)
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return false;

            product.IsActive = false;

            await _context.SaveChangesAsync();
            return true;
        }



    }
}
