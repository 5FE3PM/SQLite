using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalleProducto : ContentPage
	{
		public DetalleProducto()
		{
			InitializeComponent();
		}

		private async void MenuItem1_Clicked(object sender, EventArgs e)
		{
			string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
			string rutaDb = System.IO.Path.Combine(folder, "MiNegocio1.db");
			SQLiteConnection db = new SQLiteConnection(rutaDb);

			int id = int.Parse(Id.Text);
			//DisplayAlert("ID", "" + MiId, "Ok");

			var registro = new Productos
			{
				Id = id,
				Nombre = nombre.Text,
				PrecioCosto = double.Parse(preciodecosto.Text),
				Cantidad = int.Parse(cantidad.Text),
				PrecioVenta = double.Parse(preciodeventa.Text),
				Descripcion = descipcion.Text,
				Foto = foto.Text
			};

			db.Table<Productos>();

			db.Update(registro);

			await DisplayAlert("Actualizado", "Producto actualizado", "ok");

			Application.Current.MainPage.Navigation.PopAsync();
		}

		private async void MenuItem2_Clicked(object sender, EventArgs e)
		{
			string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
			string rutaDb = System.IO.Path.Combine(folder, "MiNegocio1.db");
			SQLiteConnection db = new SQLiteConnection(rutaDb);

			int id = int.Parse(Id.Text);

			var respuesta = await DisplayAlert("Eliminar Producto", "¿Deseas eliminar este producto?", "Si", "No");

			if (respuesta == true)
			{
				db.Delete<Productos>(id);
				await Application.Current.MainPage.Navigation.PopAsync();
			}
		}
	}
}