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
		public DateTime? DatumPocetka { get; set; }
		public DateTime? DatumKraja { get; set; }
		public TimeSpan VremePocetka { get; set; }
		public TimeSpan Trajanje { get; set; }
		public bool[] DaniUNedelji { get; set; } = new bool[7];

		public bool ProveraDatuma(DateTime datum)
		{
			if (DatumPocetka is null || DatumKraja is null)
				return false;
			if (datum.Date >= DatumPocetka.Value.Date && datum.Date <= DatumKraja.Value)
			{
				switch (datum.DayOfWeek)
				{
					case DayOfWeek.Monday:
						if (DaniUNedelji[0])
							return true;
						break;
					case DayOfWeek.Tuesday:
						if (DaniUNedelji[1])
							return true;
						break;
					case DayOfWeek.Wednesday:
						if (DaniUNedelji[2])
							return true;
						break;
					case DayOfWeek.Thursday:
						if (DaniUNedelji[3])
							return true;
						break;
					case DayOfWeek.Friday:
						if (DaniUNedelji[4])
							return true;
						break;
					case DayOfWeek.Saturday:
						if (DaniUNedelji[5])
							return true;
						break;
					case DayOfWeek.Sunday:
						if (DaniUNedelji[6])
							return true;
						break;
				}
			}
			return false;
		}
		public bool ProveraVremena(TimeSpan vreme)
			=> vreme >= VremePocetka && vreme <= VremePocetka + Trajanje;

		public bool ProveraVremena(DateTime vreme)
			=> ProveraDatuma(vreme) && ProveraVremena(vreme.TimeOfDay);
	}
}
