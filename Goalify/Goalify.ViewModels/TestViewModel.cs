using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiIcons.Material;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

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
            _ = LoadMoreIcons();
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

        [RelayCommand]
        async Task IconSelectionChangeAsync(IconItem iconItem)
        {
            var snackbar = Snackbar.Make(
                message: iconItem.Icon.ToString(),
                duration: TimeSpan.FromSeconds(4),
                visualOptions: new SnackbarOptions
                {
                    BackgroundColor = Colors.Black,
                    TextColor = Colors.White,
                    ActionButtonTextColor = Colors.Yellow,
                    CornerRadius = new CornerRadius(8),
                    CharacterSpacing = 0.2
                }
            );

            await snackbar.Show();

        }

        [RelayCommand]
        async Task SendSelectedIconAsync()
        {
            if (SelectedIcon is null)
            {
                var snackbar = Snackbar.Make(
                    message: "Icon not selected",
                    duration: TimeSpan.FromSeconds(4),
                    visualOptions: new SnackbarOptions
                    {
                        BackgroundColor = Colors.Black,
                        TextColor = Colors.White,
                        ActionButtonTextColor = Colors.Yellow,
                        CornerRadius = new CornerRadius(8),
                        CharacterSpacing = 0.2
                    }
                );
                await snackbar.Show();
                return;
            }

            await Shell.Current.GoToAsync("..", new Dictionary<string, object>
            {
                {nameof(SelectedIcon), SelectedIcon  }
            });

        }
    }


    public class IconItem
    {
        public MaterialIcons Icon { get; set; }
        public ImageSource? CachedImage { get; set; }

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

    public static byte[] RenderGlyphToBytes(string glyph, int size = 40, SKColor? color = null)
    {
        color ??= SKColors.Black;

        using var bitmap = new SKBitmap(size, size);
        using var canvas = new SKCanvas(bitmap);
        canvas.Clear(SKColors.Transparent);

        // Create font and paint
        using var typeface = SKTypeface.FromFamilyName("MaterialIcons");
        using var font = new SKFont(typeface, size);
        using var paint = new SKPaint
        {
            Color = color.Value,
            IsAntialias = true
        };

        // Measure text width
        float textWidth = font.MeasureText(glyph);

        // Get font metrics from SKFont
        var metrics = font.Metrics;
        float textHeight = metrics.Descent - metrics.Ascent;

        // Calculate position to center text
        float x = (size - textWidth) / 2;
        float y = (size + textHeight) / 2 - metrics.Descent;

        // Draw text
        canvas.DrawText(glyph, x, y, font, paint);
        canvas.Flush();

        // Convert to PNG bytes
        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        return data.ToArray();
    }

}
