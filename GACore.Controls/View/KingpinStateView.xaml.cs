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
	}
}
