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
	public partial class AgregarProducto : ContentPage
	{
		public AgregarProducto()
		{
			InitializeComponent();
		}

		private void MenuItem1_Clicked(object sender, EventArgs e)
		{
			AgregarProductos();
			Application.Current.MainPage.Navigation.PopAsync();
		}

		private void AgregarProductos()
		{
			string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
			string rutaDb = System.IO.Path.Combine(folder, "MiNegocio1.db");
			// DisplayAlert("Ruta de la base de datos", rutaDb, "ok");
			// Crea la base de datos si no existe, y crea una conexión
			SQLiteConnection db = new SQLiteConnection(rutaDb);
			// Crea la tabla si no existe
			db.CreateTable<Productos>();
			Productos nuevoProducto = new Productos
			{
				Nombre = nombre.Text,
				PrecioCosto = double.Parse(preciodecosto.Text),
				Cantidad = int.Parse(cantidad.Text),
				PrecioVenta = double.Parse(preciodeventa.Text),
				Descripcion = descipcion.Text,
				Foto = foto.Text
			};
			db.Insert(nuevoProducto);
			DisplayAlert("Agregado", "El registro fue agregado con exito!", "ok");
		}
	}
}