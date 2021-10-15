using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabovanooo
{
	public class Polaznik
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string PrezimeiIme { get => $"{Prezime} {Ime}"; }

		public override string ToString()
			=> PrezimeiIme;

	}
}
