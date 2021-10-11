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
	/// Interaction logic for EditorPol.xaml
	/// </summary>
	public partial class EditorPol : Window
	{
		public EditorPol(Polaznik p)
		{
			InitializeComponent();
			BindingGroup = new();
			DataContext = p;
		}

		private void Izmena(object sender, RoutedEventArgs e)
		{ 
			BindingGroup.UpdateSources();
			Close();
		}

		private void Otkazi(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
