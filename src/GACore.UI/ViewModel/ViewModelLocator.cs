using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACore.UI.ViewModel
{
	public static class ViewModelLocator
	{
		public static IPAddressViewModel IPAddressViewModel { get; } = new IPAddressViewModel();
	}
}
