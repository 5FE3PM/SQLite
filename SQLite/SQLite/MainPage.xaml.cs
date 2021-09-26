using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLite
{
	public class Productos
	{
		[PrimaryKey]
		[AutoIncrement]
		public int Id { get; set; }
		public string Nombre { get; set; }
		public double PrecioVenta { get; set; }
		public int Cantidad { get; set; }
		public double PrecioCosto { get; set; }
		public string Descripcion { get; set; }
		public string Foto { get; set; }
	}
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			AbrirBase();
			productsList.IsRefreshing = false;
			this.Appearing += MainPage_Appearing;
		}

		public void AbrirBase()
		{
			string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
			string DBPath = System.IO.Path.Combine(folder, "MiNegocio1.db");
			
			SQLiteConnection db = new SQLiteConnection(DBPath);
			db.CreateTable<Productos>();
			List<Productos> products = db.Table<Productos>().ToList();
			productsList.ItemsSource = null;
			productsList.ItemsSource = products;
		}

		private async void MenuItem1_Clicked(object sender, EventArgs e)
		{
			var detailPage = new AgregarProducto();
			await Navigation.PushAsync(detailPage);
			AbrirBase();
		}

		private void MainPage_Appearing(object sender, EventArgs e)
		{
			AbrirBase();
		}

		private void productsList_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			var elemento = e.Item as Productos;
			var detailPage = new DetalleProducto();
			detailPage.BindingContext = elemento;
			Navigation.PushAsync(detailPage);
		}
	}
}
