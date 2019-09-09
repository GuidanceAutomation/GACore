using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;

namespace GACore.Controls
{
	public partial class IPV4Control : UserControl
	{
		private Regex regex = new Regex(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$");

		public IPV4Control()
		{
			InitializeComponent();
		}

		public IPAddress ToIPV4Address()
		{
			Match match = regex.Match(ipV4TextBox.Text);

			if (match.Success) return IPAddress.Parse(match.Value);
			return null;
		}

		private void IpV4TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			Match match = regex.Match(ipV4TextBox.Text);

			if (!match.Success) ipV4TextBox.Background = Brushes.Crimson;
			else ipV4TextBox.Background = Brushes.White;
		}
	}
}