using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACore.DemoApp
{
	public static class BootStrapper
	{
		public static void Activate()
		{
			ViewModel.ViewModelLocator.FooBoolObjViewModel.Model = new Model.FooBoolObj();
		}
	}
}
