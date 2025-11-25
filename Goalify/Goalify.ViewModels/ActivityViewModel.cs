using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Goalify.Common.Models;
using Goalify.Services.DbService;
using SQLite;

namespace Goalify.ViewModels
{
    public partial class ActivityViewModel : BasePageViewModel
    {
        readonly SQLiteService dbService;

        [ObservableProperty]
        ActivityModel activity;

        [ObservableProperty]
        ImageSource cachedImage;

        IconItem iconItem { get; set; }

        public ActivityViewModel(SQLiteService dbService)
        {
            this.dbService = dbService;
            Activity = new ActivityModel();
        }

        public override async Task InitAsync()
        {
            await dbService.InitAsync<ActivityModel>();
        }

        public override void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            
            if (query.ContainsKey("SelectedIcon"))
            {
                iconItem = query["SelectedIcon"] as IconItem;
                if (iconItem != null)
                {
                    CachedImage = iconItem.CachedImage;
                }
            }
        }



        [RelayCommand]
        async Task NavigateToAddActivityAsync()
        {
            await Shell.Current.GoToAsync("AddActivityPage");
        }

        [RelayCommand]
        async Task SaveActivityAsync()
        {
            //Activity.Icon 
            var glyph = Abc.GetGlyph(iconItem.Icon);
            Activity.Icon = Abc.RenderGlyphToBytes(glyph);
            await dbService.AddAsync(Activity);
            // Save activity logic here
            // await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        void SelectIcon()
        {
            Shell.Current.GoToAsync("TestPage");
        }


        public static async Task<byte[]> ImageSourceToBytesAsync(ImageSource imageSource)
        {
            if (imageSource is StreamImageSource streamImageSource)
            {
                using var stream = await streamImageSource.Stream(CancellationToken.None);
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                return ms.ToArray();
            }
            else if (imageSource is FileImageSource fileImageSource)
            {
                return await File.ReadAllBytesAsync(fileImageSource.File);
            }
            else if (imageSource is UriImageSource uriImageSource)
            {
                using var http = new HttpClient();
                return await http.GetByteArrayAsync(uriImageSource.Uri);
            }

            throw new NotSupportedException($"ImageSource type {imageSource.GetType()} is not supported.");
        }
    }



}
