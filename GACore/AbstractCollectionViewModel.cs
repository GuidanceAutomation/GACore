using GACore.Architecture;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GACore
{
	public abstract class AbstractCollectionViewModel<T, U, V> : AbstractViewModel<T>, ICollectionViewModel<T, U, V>
			where T : class, IModelCollection<V>
			where U : AbstractViewModel<V>, new()
			where V : class
	{
		protected ObservableCollection<U> viewModels = new ObservableCollection<U>();

		public void Dispose() => Dispose(true);

		public AbstractCollectionViewModel()
		{
			ViewModels = new ReadOnlyObservableCollection<U>(viewModels);
		}

		~AbstractCollectionViewModel()
		{
			Dispose(false);
		}

		public ReadOnlyObservableCollection<U> ViewModels { get; }

		private bool isDisposed = false;

		private async Task HandleAddCollectionItemModel(V collectionItemModel)
		{
			if (collectionItemModel == null)
			{
				Logger.Warn("[{0}] HandleAddCollectionItemModel() collectionItemModel was null", GetType().Name);
				return;
			}

			// To solve race condition when getting an item added while the model is changed. 
			if (viewModels.Select(e => e.Model).Any(e => e.Equals(collectionItemModel)))
			{
				Logger.Warn("[{0}] HandleAddCollectionItemModel() viewModels already contains a collectionItemViewModel for this collectionItemModel", GetType().Name);
				return;
			}

			U collectionItemViewModel = new U() { Model = collectionItemModel };

			await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				viewModels.Add(collectionItemViewModel);
			}));

			Logger.Warn("[{0}] HandleAddCollectionItemModel() added: {1}", GetType().Name, collectionItemModel);
		}

		private async void HandleCollectionRefresh()
		{
			await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				viewModels.Clear();
			}));

			if (Model == null) return;

			foreach (V model in Model.GetModels())
			{
				await HandleAddCollectionItemModel(model);
			}
		}

		protected override void HandleModelUpdate(T oldValue, T newValue)
		{
			if (oldValue != null) oldValue.Added -= Model_Added;
			if (oldValue != null) oldValue.Removed -= Model_Removed;

			if (newValue != null) newValue.Added += Model_Added;
			if (newValue != null) newValue.Removed += Model_Removed;

			base.HandleModelUpdate(oldValue, newValue);
			HandleCollectionRefresh();
		}

		public abstract U GetViewModelForModel(V model);

		private async void Model_Removed(V obj)
		{
			if (obj == null)
			{
				Logger.Warn("[{0}] Model_Removed() obj was null", GetType().Name);
				return;
			}

			U viewModel = GetViewModelForModel(obj);

			if (viewModel == null)
			{
				Logger.Warn("[{0}] Model_Removed() GetViewModelForModel() returned null", GetType().Name);
				return;
			}

			await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				viewModels.Remove(viewModel);
			}));
		}

		private async void Model_Added(V obj)
		{
			Logger.Trace("[{0}] Model_Added()", GetType().Name);

			await HandleAddCollectionItemModel(obj);
		}

		protected virtual void Dispose(bool isDisposing)
		{
			if (isDisposed) return;

			if (isDisposing)
			{
				if (Model != null) Model.Added -= Model_Added;
				if (Model != null) Model.Removed -= Model_Removed;
			}

			isDisposed = true;
		}
	}
}
