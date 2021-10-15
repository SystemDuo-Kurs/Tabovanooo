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
		ObservableCollection<Polaznik> Polaznici { get; set; } = new();
		ObservableCollection<Kurs> Kursevi { get; set; } = new();

		public MainWindow()
		{
			InitializeComponent();
			dgPolaznik.ItemsSource = Polaznici;

			tiPolaznik.DataContext = new Polaznik();
			tiKurs.DataContext = new Kurs();

			Kursevi.Add(new Kurs { Naziv = "Prvi" });
			Kursevi.Add(new Kurs { Naziv = "Drugi" });
			Kursevi.Add(new Kurs { Naziv = "Treci" });
			Kursevi.Add(new Kurs { Naziv = "Peti" });

			Polaznici.Add(new Polaznik { Ime = "Pera", Prezime = "Peric" });
			Polaznici.Add(new Polaznik { Ime = "Neko", Prezime = "Nekic" });
			Polaznici.Add(new Polaznik { Ime = "Asd", Prezime = "Qwe" });
			Polaznici.Add(new Polaznik { Ime = "Trecko", Prezime = "Treckovic" });

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
				if (!Kursevi.Where(k => k.Naziv.ToLower() == (tiKurs.DataContext as Kurs).Naziv.ToLower())
					.Any())
				{

					Kurs k = tiKurs.DataContext as Kurs;

					if (k.DatumPocetka.HasValue && k.DatumKraja.HasValue &&
					    (k.DatumKraja.Value - k.DatumPocetka.Value).Days >= 7)
					{
						if (k.DaniUNedelji.Where(dan => dan == true).Any())
						{
							try
							{
								int sati = int.Parse(Sati.Text);
								int minuta = int.Parse(Minute.Text);
								int trajanje = int.Parse(VremeTrajanja.Text);
								//nova skola :) : sati is >= 0 and <=23
								//stara skola: sati >= 0 && sati <= 23
								if (sati is >= 0 and <=23 && minuta is >= 0 and <= 59 &&
									trajanje >= 30)
								{
									k.VremePocetka = new TimeSpan(sati, minuta, 0);
									k.Trajanje = new TimeSpan(0, trajanje, 0);
								} else
								{
									Console.WriteLine("Vreme joook");
									return;
								}
							}
							catch
							{
								MessageBox.Show("Greeeeeska!");
								return;
							}
							Kursevi.Add(tiKurs.DataContext as Kurs);
							tiKurs.DataContext = new Kurs();
						} else
						{
							MessageBox.Show("Dan joook");
						}
					}else
					{
						MessageBox.Show("Datum joook");
					}
				}
				else
					MessageBox.Show("DUPLIKAAAAAT!");
			} else
			{
				MessageBox.Show("JOKKKKKKK");
			}
			
		}

		private void UnosPol(object sender, RoutedEventArgs e)
		{
			Polaznik p = tiPolaznik.DataContext as Polaznik;
			if (!(string.IsNullOrEmpty(p.Ime) ||
				string.IsNullOrWhiteSpace(p.Ime) ||
				string.IsNullOrEmpty(p.Prezime) ||
				string.IsNullOrWhiteSpace(p.Prezime)))
			{
				Polaznici.Add(tiPolaznik.DataContext as Polaznik);
				tiPolaznik.DataContext = new Polaznik();
			}
			else
				MessageBox.Show("Jooook");
		}

		private void IzmenaPol(object sender, MouseButtonEventArgs e)
		{
			if (dgPolaznik.SelectedItem is not null)
			{
				EditorPol ep = new(dgPolaznik.SelectedItem as Polaznik);
				ep.Owner = this;
				ep.ShowDialog();
			}
		}

		private void Upis(object sender, MouseButtonEventArgs e)
		{
			if (dgKursevi.SelectedItem is not null)
			{
				Upisivac up = new(Polaznici.ToList(), dgKursevi.SelectedItem as Kurs, 
					Kursevi.ToList());
				up.Owner = this;
				up.ShowDialog();
			}
		}
	}
	
	
}
