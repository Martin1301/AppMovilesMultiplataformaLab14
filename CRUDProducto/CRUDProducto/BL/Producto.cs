using CRUDProducto.Data;
using CRUDProducto.Models;
using CRUDProducto.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProducto.BL
{
    public class Producto : IProducto
    { 
     public async Task<List<ProductoModel>> GetListProducto()
    {
        using (var productoContext = new ProductoContext())
        {
            return await productoContext.TbProducto.ToListAsync();
        }
    }

    public async Task<ProductoModel> GetProducto(int ProductoId)
    {
        using (var productoContext = new ProductoContext())
        {
            return await productoContext.TbProducto
                .Where(p => p.ProductoId == ProductoId).FirstOrDefaultAsync();
        }

    }


    public async Task<bool> InsertProducto(ProductoModel productoModel)
    {
        using (var productoContext = new ProductoContext())
        {
            productoContext.Add(productoModel);

            await productoContext.SaveChangesAsync();
        }
        return true;
    }

    public async Task<bool> UpdateProducto(ProductoModel productoModel)
    {
        using (var productoContext = new ProductoContext())
        {
            var tracking = productoContext.Update(productoModel);

            await productoContext.SaveChangesAsync();

            var isModified = tracking.State == EntityState.Modified;
            return isModified;
        }
    }

    public async Task<bool> DeleteProducto(ProductoModel productoModel)
    {
        using (var productoContext = new ProductoContext())
        {
            var tracking = productoContext.Remove(productoModel);

            await productoContext.SaveChangesAsync();

            var isDeleted = tracking.State == EntityState.Deleted;
            return isDeleted;
        }

    }


    public async Task<bool> DeleteAllProducto()
    {
        using (var productoContext = new ProductoContext())
        {
            productoContext.RemoveRange(productoContext.TbProducto);

            await productoContext.SaveChangesAsync();
        }
        return true;
      }
    }
}
