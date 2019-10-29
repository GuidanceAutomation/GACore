using GACore.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACore.Controls.ViewModel
{
	public static class ViewModelFactory
	{
		public static KingpinStateReporterViewModel GetKingpinStateReporterViewModel(IKingpinStateReporter kingpinStateReporter)
		{
			if (kingpinStateReporter == null) throw new ArgumentNullException("kingpinStateReporter");

			return new KingpinStateReporterViewModel()
			{
				Model = kingpinStateReporter
			};
		}

		public static KingpinStatusReporterViewModel GetKingpinStatusReporterViewModel(IKingpinStateReporter kingpinStateReporter)
		{
			if (kingpinStateReporter == null) throw new ArgumentNullException("kingpinStateReporter");

			return new KingpinStatusReporterViewModel()
			{
				Model = kingpinStateReporter
			};
		}
	}
}
