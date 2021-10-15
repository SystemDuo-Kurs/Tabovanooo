using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Tabovanooo
{
	/// <summary>
	/// Interaction logic for Upisivac.xaml
	/// </summary>
	public partial class Upisivac : Window
	{
		List<Kurs> Kursevi;
		public Upisivac(List<Polaznik> pol, Kurs kurs, List<Kurs> kursevi)
		{
			InitializeComponent();
			Kursevi = kursevi;
			listbPolaznici.ItemsSource = pol;
			DataContext = kurs;
			listbKurs.ItemsSource = kurs.Polaznici;
			//listbPolaznici.DisplayMemberPath = "Ime";
			Tamo.Content = "-->";
			Ovamo.Content = "<--";	
		}

		private void Upis(object sender, RoutedEventArgs e)
		{
			if (listbPolaznici.SelectedItem is not null)
			{
				if (!(DataContext as Kurs).Polaznici.Contains(listbPolaznici.SelectedItem as Polaznik))
				{
					foreach(Kurs k in Kursevi)
					{
						if ((DataContext as Kurs) == k)
							continue;
						if (k.Polaznici.Contains(listbPolaznici.SelectedItem as Polaznik))
						{
							MessageBox.Show("Na drugom kursu jeeee");
						}
					}
					(DataContext as Kurs).Polaznici.Add(listbPolaznici.SelectedItem as Polaznik);
				}
			}
		}
	}
}
