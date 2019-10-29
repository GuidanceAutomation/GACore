using GACore.Architecture;
using GACore.Controls.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace GACore.Controls.View
{
	/// <summary>
	/// Interaction logic for KingpinStateView.xaml
	/// </summary>
	public partial class KingpinStateView : UserControl
	{
		public KingpinStateView()
		{
			InitializeComponent();
			CompositionTarget.Rendering += CompositionTarget_Rendering;
		}

		private void CompositionTarget_Rendering(object sender, EventArgs e)
		{
			if (DataContext is IRefresh)
				((IRefresh)DataContext).Refresh();
		}

		private void UserControl_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
		{
			KingpinStateReporterViewModel viewModel = e.NewValue as KingpinStateReporterViewModel;

			if (viewModel != null)
			{
				IKingpinStateReporter reporter = viewModel.Model;

				if (reporter != null) ksView.DataContext = ViewModelFactory.GetKingpinStatusReporterViewModel(reporter);
			}
		}
	}
}
