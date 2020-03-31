using GACore.Architecture;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace GACore
{
	public abstract class AbstractCompositionTargetControl : UserControl, IDisposable
	{
		public AbstractCompositionTargetControl(byte onFrames = 1)
		{
			OnFrames = onFrames;
			CompositionTarget.Rendering += CompositionTarget_Rendering;
		}

		private void CompositionTarget_Rendering(object sender, EventArgs e)
		{
			if ((frameCount % OnFrames) == 0 && DataContext is IRefresh)
				((IRefresh)DataContext).Refresh();

			frameCount++;
		}

		private byte frameCount = 0;

		public byte OnFrames { get; private set; } = 1;

		public void Dispose() => Dispose(true);

		private bool isDisposed = false;

		private void Dispose(bool isDisposing)
		{
			if (isDisposed) return;

			CompositionTarget.Rendering -= CompositionTarget_Rendering;

			isDisposed = true;
		}
	}
}
