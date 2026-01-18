using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Converters;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Goalify.Common.Helper;
using Goalify.Common.Models;
using Goalify.Services.DbService;
using System.Collections.ObjectModel;

namespace Goalify.ViewModels
{
    public partial class ActivityViewModel : BasePageViewModel
    {
        readonly SQLiteService dbService;

        [ObservableProperty]
        ActivityModel activity;

        [ObservableProperty]
        ObservableCollection<ActivityModel> activities = [];

        [ObservableProperty]
        ImageSource selectedIcon;

        byte[] cachedImage;

        bool isEdit { get; set; } = false;

        IconItem iconItem { get; set; }

        public ActivityViewModel(SQLiteService dbService)
        {
            this.dbService = dbService;
            Activity = new ActivityModel();
        }

        public override async Task InitAsync()
        {
            await dbService.InitAsync<ActivityModel>();
            Activities = new ObservableCollection<ActivityModel>(await dbService.GetAllAsync<ActivityModel>());
        }

        public override void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("SelectedIcon", out var sIcon))
            {
                if (sIcon is IconItem iconItem)
                {
                    var glyph = Abc.GetGlyph(iconItem.Icon);
                    cachedImage = Abc.RenderGlyphToBytes(glyph);
                    var converter = new ByteArrayToImageSourceConverter();
                    SelectedIcon = converter.ConvertFrom(cachedImage);
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


            Activity.Icon = cachedImage ?? [];
            int? result;
            if (isEdit)
            {
                result = await dbService.UpdateAsync(Activity);
            }
            else
            {
                result = await dbService.AddAsync(Activity);
            }

            if (result == 1)
            {
                await Shell.Current.GoToAsync("..");
                isEdit = false;
            }

            await SnackbarHelper.ShowSnackAsync(result.Value == 1 ? "Successfully Saved" : "Something went wrong!");
        }

        [RelayCommand]
        void SelectIcon()
        {
            Shell.Current.GoToAsync("TestPage");
        }

        [RelayCommand]
        async Task EditActivityAsync(ActivityModel activityModel)
        {
            await Shell.Current.GoToAsync("AddActivityPage");
            Activity.Name = activityModel.Name;
            Activity.Description = activityModel.Description;
            Activity.Icon = cachedImage = activityModel.Icon ?? [];
            Activity.Id = activityModel.Id;
            isEdit = true;

            byte[]? bytes = activityModel.Icon;
            var converter = new ByteArrayToImageSourceConverter();
            SelectedIcon = converter.ConvertFrom(bytes);

            //if (cachedImage is null)
            //{
            //    return;
            //}

            cachedImage = activityModel.Icon ?? [];
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
