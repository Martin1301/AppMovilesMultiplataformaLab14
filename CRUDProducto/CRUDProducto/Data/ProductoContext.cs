using CRUDProducto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace CRUDProducto.Data
{
    public class ProductoContext: DbContext 
    {
        public DbSet<ProductoModel> TbProducto { get; set; }

        public ProductoContext()
        {
            /*Necesario para iniciar sqlite en iOS*/
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ProductoDbFonsus.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
