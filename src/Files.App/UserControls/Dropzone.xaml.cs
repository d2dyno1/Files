using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Runtime.InteropServices.ComTypes;
using Vanara.PInvoke;
using WinRT;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Files.App.UserControls
{
	public sealed partial class Dropzone : UserControl
	{
		public Dropzone()
		{
			InitializeComponent();
		}

		public IList<DropzoneItem>? Items
		{
			get => (IList<DropzoneItem>?)GetValue(ItemsProperty);
			set => SetValue(ItemsProperty, value);
		}
		public static readonly DependencyProperty ItemsProperty =
			DependencyProperty.Register(nameof(Items), typeof(IList<DropzoneItem>), typeof(Dropzone), new PropertyMetadata(null));

		private void Dropzone_DragStarting(UIElement sender, DragStartingEventArgs args)
		{
			if (Items is null)
				return;

			var shellItemList = SafetyExtensions.IgnoreExceptions(() => Items.Select(x => new Vanara.Windows.Shell.ShellItem(x.Inner.Id)).ToArray());
			if (shellItemList?[0].FileSystemPath is not null)
			{
				var iddo = shellItemList[0].Parent?.GetChildrenUIObjects<IDataObject>(HWND.NULL, shellItemList);
				if (iddo is null)
					return;

				shellItemList.ForEach(x => x.Dispose());
				var dataObjectProvider = args.Data.As<Shell32.IDataObjectProvider>();
				dataObjectProvider.SetDataObject(iddo);
			}
			else
			{
				// Only support IStorageItem capable paths
				var storageItems = Items.Select(x => VirtualStorageItem.FromPath(x.Inner.Id))
				args.Data.SetStorageItems(storageItems, false);
			}
		}

		private void Dropzone_Drop(object sender, DragEventArgs e)
		{
			DragOperationDeferral? deferral = null;
			try
			{
				deferral = e.GetDeferral();
				// associatedInstance.FilesystemHelpers.PerformOperationTypeAsync
			}
			finally
			{
				deferral?.Complete();
			}
		}
	}
}
