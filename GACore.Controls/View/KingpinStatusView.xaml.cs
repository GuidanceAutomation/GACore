using GACore.Architecture;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GACore.Controls.View
{
	/// <summary>
	/// Interaction logic for KingpinStatusView.xaml
	/// </summary>
	public partial class KingpinStatusView : UserControl
	{
		public KingpinStatusView()
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
