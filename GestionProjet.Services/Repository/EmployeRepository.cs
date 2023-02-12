using AutoMapper;
using GestionProject.services.ProdactApi.models.Dtos;
using GestionProject.services.ProdactApi.Repository;
using GestionProjet.Services.ProductAPI.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Artisanal.Services.ProductAPI.Repository
{
   
    public class EmployeRepository : IEmployeRepository
    {
        private readonly ApplicationDbContext _db;

        private IMapper _mapper;











        public EmployeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Task<EmplpoyeDto> CreateUpdateEmplpoye(EmplpoyeDto emplpoyeDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public Task<bool> DeleteEmplpoye(int employeId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<IEnumerable<EmplpoyeDto>> GetEmploye()
        {
            throw new NotImplementedException();
        }

        public Task<EmplpoyeDto> GetEmplpoyeById(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            
            return _mapper.Map<ProductDto>(product);
        }






        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.Products.ToListAsync();

           
            return _mapper.Map<List<ProductDto>>(productList);

        }
    }
}
