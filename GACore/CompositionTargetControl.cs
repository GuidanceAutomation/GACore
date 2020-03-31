using GACore.Architecture;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace GACore
{
	public class CompositionTargetControl : UserControl, IDisposable
	{
		private byte frameCount = 0;

		private bool isDisposed = false;

		public CompositionTargetControl(byte onFrames = 1)
		{
			OnFrames = onFrames;
			CompositionTarget.Rendering += CompositionTarget_Rendering;
		}

		~CompositionTargetControl()
		{
			Dispose(false);
		}

		public byte OnFrames { get; private set; } = 1;

		public void Dispose() => Dispose(true);

		private void CompositionTarget_Rendering(object sender, EventArgs e)
		{
			if ((frameCount % OnFrames) == 0 && DataContext is IRefresh)
				((IRefresh)DataContext).Refresh();

			frameCount++;
		}
		private void Dispose(bool isDisposing)
		{
			if (isDisposed) return;

			CompositionTarget.Rendering -= CompositionTarget_Rendering;

			isDisposed = true;
		}
	}
}
