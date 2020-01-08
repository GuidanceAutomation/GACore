using GACore.Command;
using GACore.DemoApp.Model;
using System;
using System.Windows.Input;

namespace GACore.DemoApp.ViewModel
{
	public class FooBoolObjViewModel : AbstractViewModel<FooBoolObj>
	{
		public bool IsSet
		{
			get { return Model != null ? Model.IsSet : false; }
			private set
			{
				if (Model != null) Model.ToggleIsSet();
				OnNotifyPropertyChanged();
			}
		}

		private void HandleToggleIsSet() => IsSet = false; // Set forces recalc

		protected override void HandleModelUpdate(FooBoolObj oldValue, FooBoolObj newValue)
		{
			OnNotifyPropertyChanged("IsSet");
			base.HandleModelUpdate(oldValue, newValue);
		}

		public ICommand ClickCommand { get; set; }

		private void HandleCommands()
		{
			ClickCommand = new CustomCommand(ClickCommandClick, CanClickCommandClick);
		}

		private void ClickCommandClick(object obj) => IsSet = false; // Forces recalc

		private bool CanClickCommandClick(object obj) => true;

		public FooBoolObjViewModel()
		{
			HandleCommands();
		}
	}
}
