using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRUDProducto.Models
{
    public class ProductoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public double ProductoPrecio { get; set; }
        public bool ProductoPedido { get; set; }
        public DateTime ProductoFecha { get; set; }
    }
}