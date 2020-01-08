using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GACore.DemoApp.Service
{
	public static class DialogService
	{
		public static Window CreateFooWizardWindow()
		{
			FooWizardWindow window = new FooWizardWindow();

			return window;
		}
	}
}
