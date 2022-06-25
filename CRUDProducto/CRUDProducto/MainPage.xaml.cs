using CRUDProducto.Models;
using CRUDProducto.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUDProducto
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        
        }

        MainViewModel Vm { get { return BindingContext as MainViewModel; } }

        public async void UpdateRow_Tapped(object sender, EventArgs e)
        {
            var contenedor = ((Frame)sender).GestureRecognizers[0];

            ProductoModel productoModel = ((TapGestureRecognizer)contenedor).CommandParameter as ProductoModel;


            string Nombre = await DisplayPromptAsync("Actualizar Nombre", productoModel.ProductoNombre);
            string Precio = await DisplayPromptAsync("Actualizar Precio", productoModel.ProductoPrecio.ToString());
            string Fecha = await DisplayPromptAsync("Actualizar Fecha", productoModel.ProductoFecha.ToString("dd-MM-yyyy"));
            string Pedido = await DisplayPromptAsync("Actualizar Pedido", productoModel.ProductoPedido.ToString());

            productoModel.ProductoNombre = Nombre;
            productoModel.ProductoPrecio = Convert.ToDouble(Precio);
            productoModel.ProductoFecha = Convert.ToDateTime(Fecha);
            productoModel.ProductoPedido = Convert.ToBoolean(Pedido);

            Vm.UpdateRowCommand.Execute(productoModel);

        }
        void DeliveryYN(object sender, EventArgs args)
        {
            RadioButton radioButton = sender as RadioButton;
            label.Text = $"{radioButton.Content}";
        }

        private async void DeleteRow_Swiped(object sender, SwipedEventArgs e)
        {

            bool resultado = await DisplayAlert("Eliminar", "¿Seguro que desea eliminar el registro?", "Si", "No");

            if (resultado)
            {
                var contenedor = ((Frame)sender).GestureRecognizers[0];

                ProductoModel productoModel = ((TapGestureRecognizer)contenedor).CommandParameter as ProductoModel;

                Vm.DeleteRowCommand.Execute(productoModel);
            }

        }

    }
}
