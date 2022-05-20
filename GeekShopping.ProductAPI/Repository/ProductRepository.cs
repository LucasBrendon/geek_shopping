using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySqlDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            return _mapper.Map<IEnumerable<ProductVO>>(await _context.Products.AsNoTracking().ToListAsync());
        }

        public async Task<ProductVO> FindById(long id)
        {
            return _mapper.Map<ProductVO>(await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync());
        }

        public async Task<ProductVO> Create(ProductVO productVO)
        {
            var product = _mapper.Map<Product>(productVO);

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO productVO)
        {
            var product = _mapper.Map<Product>(productVO);

            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

                _context.Products.Remove(product);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
