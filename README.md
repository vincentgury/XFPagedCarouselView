<img alt="Icon" src="https://raw.githubusercontent.com/vincentgury/XFPagedCarouselView/master/art/icon.png" height="128" align="left" style="margin:20px 20px 20px 0" />

## Paged Carousel View for Xamarin.Forms (Android & iOS)

Create paged carousel views from shared code for your mobile apps!
<br/><br/><br/>
### Setup & Usage
* Available on NuGet: https://www.nuget.org/packages/VG.XFPagedCarouselView/ [![NuGet](https://img.shields.io/nuget/v/VG.XFPagedCarouselView.svg?label=NuGet)](https://www.nuget.org/packages/VG.XFPagedCarouselView/)
* Install into your PCL project and Client projects.
* Add a PagedCarouselView to your page, set its properties (don't forget to set a DataTemplate) and see the result.
* Follow this quick guide for deeper understanding.

**Platform Support**

|Platform|Supported|Version|
| ------ | :-------: | :-----: |
|Xamarin.iOS|<img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20">|iOS 6+|
|Xamarin.Android|<img alt="Yes" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ok.png" width="20">|API 15+|
|Windows Phone Silverlight|<img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20">||
|Windows Phone RT|<img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20">||
|Windows Store RT|<img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20">||
|Windows 10 UWP|<img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20">||
|Xamarin.Mac|<img alt="No" src="https://raw.githubusercontent.com/vincentgury/Resources/master/images/ko.png" width="20">||


### PagedCarouselView properties

Under construction

### Example
You can draw a box with a content Label, responding to touch like so:

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:xfpcv="clr-namespace:XFPagedCarouselView;assembly=XFPagedCarouselView"
             x:Class="XFPagedCarouselViewSample.MainPage">
  <xfpcv:PagedCarouselView x:Name="PagedCarouselView" VerticalOptions="FillAndExpand" PagerStyle="Circle">
    <xfpcv:PagedCarouselView.ItemTemplate>
      <DataTemplate>
        <StackLayout BackgroundColor="{Binding BackgroundColor}">
          <Label Text="{Binding Title}" VerticalOptions="FillAndExpand" HorizontalTextAlignment="Center" VerticalTextAlignment="Center" TextColor="White" FontSize="Large"></Label>
        </StackLayout>
      </DataTemplate>
    </xfpcv:PagedCarouselView.ItemTemplate>
  </xfpcv:PagedCarouselView>
</ContentPage>
```

## Screenshots
**Android**


<img alt="Android" src="https://raw.githubusercontent.com/vincentgury/XFPagedCarouselView/master/art/screenshots/screenshot-android-1.png" width="200" />
&nbsp;&nbsp;
<img alt="Android" src="https://raw.githubusercontent.com/vincentgury/XFPagedCarouselView/master/art/screenshots/screenshot-android-2.png" width="200" />
&nbsp;&nbsp;
<img alt="Android" src="https://raw.githubusercontent.com/vincentgury/XFPagedCarouselView/master/art/screenshots/screenshot-android-3.png" width="200" />

**iOS**


<img alt="iOS" src="https://raw.githubusercontent.com/vincentgury/XFPagedCarouselView/master/art/screenshots/screenshot-ios-1.png" width="200" />
&nbsp;&nbsp;
<img alt="iOS" src="https://raw.githubusercontent.com/vincentgury/XFPagedCarouselView/master/art/screenshots/screenshot-ios-2.png" width="200" />
&nbsp;&nbsp;
<img alt="iOS" src="https://raw.githubusercontent.com/vincentgury/XFPagedCarouselView/master/art/screenshots/screenshot-ios-3.png" width="200" />

## Contributing

Contributions are absolutely welcome. 

1. Fork the project!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request and I will be happy to test it

Thank you for your suggestions!

## Credits

A lot of thanks to ***Adam Pedley*** for inspiring me with his blog post: https://xamarinhelp.com/carousel-view-page-indicators

## Copyright

&copy; 2016 Vincent Gury
