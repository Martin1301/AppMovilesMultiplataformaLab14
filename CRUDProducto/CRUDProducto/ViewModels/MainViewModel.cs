using CRUDProducto.BL;
using CRUDProducto.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUDProducto.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        Producto producto = new Producto();


        private ObservableCollection<ProductoModel> listProducto;
        public ObservableCollection<ProductoModel> ListProducto
        {
            get { return listProducto; }
            set { listProducto = value; RaisePropetyChanged(); }
        }



        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; RaisePropetyChanged(); }
        }

        private string precio;
        public string Precio
        {
            get { return precio; }
            set { precio = value; RaisePropetyChanged(); }
        }

        private string fecha;
        public string Fecha
        {   
            get { return fecha; }
            set { fecha = value; RaisePropetyChanged(); }
        }

        private string pedido;
        public string Pedido
        {
            get { return pedido; }
            set { pedido = value; RaisePropetyChanged(); }
        }


        public ICommand InsertRowCommand { get; set; }
        public ICommand UpdateRowCommand { get; set; }
        public ICommand DeleteRowCommand { get; set; }
        public ICommand DeleteAllRowCommand { get; set; }

        public MainViewModel()
        {

            DeleteRowCommand = new Command<ProductoModel>(execute: async (productoModel) => {
                await producto.DeleteProducto(productoModel);

                LoadListProducto();
            });

            DeleteAllRowCommand = new Command(execute: async () => {
                await producto.DeleteAllProducto();
                LoadListProducto();
            });

            UpdateRowCommand = new Command<ProductoModel>(execute: async (productoModel) => {
                await producto.UpdateProducto(productoModel);

                LoadListProducto();
            });

            InsertRowCommand = new Command(execute: async () => {

                await producto.InsertProducto(new ProductoModel()
                {
                    ProductoNombre = Nombre,
                    ProductoPrecio = Convert.ToDouble(Precio),
                    ProductoFecha = Convert.ToDateTime(Fecha),
                    ProductoPedido = Convert.ToBoolean(Pedido)
                });
                Nombre = nombre;
                Precio = precio;
                Fecha = fecha;
                Pedido = pedido;

                LoadListProducto();
            });


            LoadListProducto();


        }
        async void LoadListProducto()
        {

            ListProducto = new ObservableCollection<ProductoModel>(await producto.GetListProducto());
        }

    }
}
