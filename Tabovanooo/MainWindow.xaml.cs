using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tabovanooo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Polaznik polaznik = new Polaznik { Ime = "Pera", Prezime = "Peric" };

		ObservableCollection<Kurs> Kursevi { get; set; } = new();
		Kurs kurs = new();

		public MainWindow()
		{
			InitializeComponent();

			tiKurs.DataContext = kurs;

			Kursevi.Add(new Kurs { Naziv = "Prvi" });
			Kursevi.Add(new Kurs { Naziv = "Drugi" });
			Kursevi.Add(new Kurs { Naziv = "Treci" });
			Kursevi.Add(new Kurs { Naziv = "Peti" });

			dgKursevi.ItemsSource = Kursevi;
		}

		private void Brisanje(object sender, RoutedEventArgs e)
		{
			if (dgKursevi.SelectedItem is not null)
			{
				Kursevi.Remove(dgKursevi.SelectedItem as Kurs);
			}
		}

		private void Unos(object sender, RoutedEventArgs e)
		{   
			if (!(string.IsNullOrEmpty((tiKurs.DataContext as Kurs).Naziv) || 
				string.IsNullOrWhiteSpace((tiKurs.DataContext as Kurs).Naziv)))
			{
				(tiKurs.DataContext as Kurs).Naziv = (tiKurs.DataContext as Kurs).Naziv.Trim();

				//Dinosaursi 
				//for (int indeks = 0; indeks < Kursevi.Count; indeks++)
				//	MessageBox.Show(Kursevi[indeks].Naziv);

				//Modernije
				//foreach (Kurs k in Kursevi)
				//	MessageBox.Show(k.Naziv);

				//LINQ
				Kursevi.ToList().ForEach(k => MessageBox.Show(k.Naziv));
				
				Kursevi.Add(tiKurs.DataContext as Kurs);
				tiKurs.DataContext = new Kurs();
			} else
			{
				MessageBox.Show("JOKKKKKKK");
			}
		}
	}
	public class Polaznik
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string PrezimeiIme { get => $"{Prezime} {Ime}"; }
	}
	public class Kurs
	{
		public string Naziv { get; set; }
	}
}
