using GACore.Architecture;
using System;

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
	}
}
