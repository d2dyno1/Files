namespace Files.App.ViewModels.UserControls
{
	[Bindable(true)]
	public sealed partial class DropzoneViewModel : ObservableObject
	{
		public ObservableCollection<DropzoneItem> Items { get; }

		public DropzoneViewModel()
		{
			Items = new();
		}

		[RelayCommand]
		private void Clear()
		{
			Items.Clear();
		}
	}
}
