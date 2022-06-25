using CRUDProducto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProducto.Services
{
    public interface IProducto
    {
        Task<List<ProductoModel>> GetListProducto();
        Task<ProductoModel> GetProducto(int ProductoId);
        Task<bool> InsertProducto(ProductoModel productoModel);
        Task<bool> UpdateProducto(ProductoModel productoModel);
        Task<bool> DeleteProducto(ProductoModel productoModel);
        Task<bool> DeleteAllProducto();
    }
}
