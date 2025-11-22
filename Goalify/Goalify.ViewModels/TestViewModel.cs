using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiIcons.Material;

namespace Goalify.ViewModels
{
    public partial class TestViewModel : BasePageViewModel
    {

        [ObservableProperty]
        ObservableCollection<IconItem> icons = new();

        [ObservableProperty]
        IconItem selectedIcon;

        [ObservableProperty]
        bool isLoading;

        private readonly List<MaterialIcons> _allIcons;
        private int _pageSize = 50;
        private int _currentPage = 0;


        public TestViewModel()
        {
            Icons = new ObservableCollection<IconItem>();
            _allIcons = Abc.GetAllEnumValues<MaterialIcons>();  // Get all icons from enum
            LoadMoreIcons();
        }

        public override Task InitAsync()
        {
            if (Icons.Count > 0)
            {
                return Task.CompletedTask;
            }

            // Add your icon sets here
            // Example for Material Icons

            //var materialIconList = Abc.GetAllEnumValues<MaterialIcons>();

            //foreach (var iconName in materialIconList)
            //{
            //    Icons.Add(new IconItem
            //    {
            //        Icon = iconName  // The name of the Material icon (e.g., "home")
            //    });
            //}
            return base.InitAsync();
        }

        public async Task LoadMoreIcons()
        {

            if (IsLoading)
                return;
            if (_currentPage * _pageSize >= _allIcons.Count)
                return;

            IsLoading = true;

            var nextBatch = _allIcons.Skip(_currentPage * _pageSize).Take(_pageSize).ToList();

            await Task.Run(() =>
            {
                var newItems = nextBatch
                    .Select(icon => new IconItem { Icon = icon, CachedImage = IconItem.CreateFontImage(icon) })
                    .ToList();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var item in newItems)
                        Icons.Add(item);
                });
            });

            _currentPage++;
            IsLoading = false;
        }
    }


    public class IconItem
    {
        public MaterialIcons Icon { get; set; }
        public ImageSource CachedImage { get; set; }

        public static FontImageSource CreateFontImage(MaterialIcons icon)
        {
            return new FontImageSource
            {
                Glyph = Abc.GetGlyph(icon),
                FontFamily = "MaterialIcons",
                Size = 40,
                Color = Colors.Black
            };
        }
    }
}

public static class Abc
{
    public static List<MaterialIcons> GetAllEnumValues<MaterialIcons>() where MaterialIcons : Enum
    {
        return Enum.GetValues(typeof(MaterialIcons))
            .Cast<MaterialIcons>()
            .ToList();  // Explicitly cast to List<MaterialIcons>
    }

    public static string GetGlyph(MaterialIcons icon)
    {
        var fieldInfo = icon.GetType().GetField(icon.ToString());
        var description = fieldInfo?.GetCustomAttribute<DescriptionAttribute>();
        return description?.Description ?? string.Empty;
    }
}
