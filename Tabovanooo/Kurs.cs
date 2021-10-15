using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabovanooo
{
	public class Kurs
	{
		public string Naziv { get; set; }
		public ObservableCollection<Polaznik> Polaznici { get; set; } = new();

		public DateTime DatumPocetka { get; set; }
		public DateTime DatumKraja { get; set; }
		public TimeSpan VremePocetka { get; set; }
		public TimeSpan Trajanje { get; set; }

		public override string ToString()
			=> $"{Naziv} -- {Polaznici} polaznika";
	}
}
