using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using XFShapeView;

namespace XFPagedCarouselView
{
    /// <summary>
    /// A pager view allowing to display page indicator depending on the content of its ItemsSource property
    /// </summary>
    public class PagerView : StackLayout
    {
        #region Properties

#pragma warning disable 1591
        public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(int), typeof(PagerView), 0, BindingMode.TwoWay);
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<BasePageableItem>), typeof(PagerView), null, BindingMode.OneWay);
        public static readonly BindableProperty PagerStyleProperty = BindableProperty.Create(nameof(PagerStyle), typeof(PagerStyle), typeof(PagerView), PagerStyle.Circle, BindingMode.OneWay);

        public static readonly BindableProperty CustomSizeProperty = BindableProperty.Create(nameof(CustomSize), typeof(Size?), typeof(PagerView), null, BindingMode.OneWay);
        public static readonly BindableProperty CustomSelectedColorProperty = BindableProperty.Create(nameof(CustomSelectedColor), typeof(Color?), typeof(PagerView), null, BindingMode.OneWay);
        public static readonly BindableProperty CustomUnselectedColorProperty = BindableProperty.Create(nameof(CustomUnselectedColor), typeof(Color?), typeof(PagerView), null, BindingMode.OneWay);
#pragma warning restore 1591

        /// <summary>
        /// Allows you to set a custom size on all the page indicators - ignored if null - default value is null
        /// </summary>
        public Size? CustomSize
        {
            get { return (Size?)this.GetValue(CustomSizeProperty); }
            set { this.SetValue(CustomSizeProperty, value); }
        }

        /// <summary>
        /// Allows you to set a custom color when the current page indicator is selected - ignored if null - default value is null
        /// </summary>
        public Color? CustomSelectedColor
        {
            get { return (Color?)this.GetValue(CustomSelectedColorProperty); }
            set { this.SetValue(CustomSelectedColorProperty, value); }
        }

        /// <summary>
        /// Allows you to set a custom color when the current page indicator is unselected - ignored if null - default value is null
        /// </summary>
        public Color? CustomUnselectedColor
        {
            get { return (Color?)this.GetValue(CustomUnselectedColorProperty); }
            set { this.SetValue(CustomUnselectedColorProperty, value); }
        }

        /// <summary>
        /// Allows you to set a custom page indicator style on all the page indicators - ignored if null - default value is null
        /// </summary>
        public PagerStyle PagerStyle
        {
            get { return (PagerStyle)this.GetValue(PagerStyleProperty); }
            set { this.SetValue(PagerStyleProperty, (object)value); }
        }

        /// <summary>
        /// Get or sets the current position - default value is 0
        /// </summary>
        public int Position
        {
            get { return (int)this.GetValue(PositionProperty); }
            set { this.SetValue(PositionProperty, value); }
        }

        /// <summary>
        /// Get or sets the items to build the page indicators - default value is null
        /// </summary>
        public IEnumerable<BasePageableItem> ItemsSource
        {
            get { return (IEnumerable<BasePageableItem>)this.GetValue(ItemsSourceProperty); }
            set
            {
                this.SetValue(ItemsSourceProperty, (object)value);
            }
        }

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public PagerView()
        {
            this.Orientation = StackOrientation.Horizontal;

            this.SetOrientation();
        }

        #region Init

        private void UpdatePosition(int currentPosition)
        {
            if (this.Children.Count > 0)
            {
                for (var i = 0; i < this.Children.Count; ++i)
                {
                    var currentView = this.Children[i];
                    var selected = i == currentPosition;

                    if (bool.Parse(currentView.ClassId) != selected)
                        this.UpdateView(this.ItemsSource.ElementAt(i), selected, (ShapeView)this.Children[i]);
                }
            }
            else if (this.ItemsSource != null)
            {
                var count = this.ItemsSource.Count();

                for (var i = 0; i < count; ++i)
                {
                    this.Children.Add(this.BuildIndicator(i == currentPosition, i));
                }
            }
        }

        private void Clear()
        {
            this.Children.Clear();
        }

        private void Reset()
        {
            this.Clear();
            if (this.Position == 0)
                this.UpdatePosition(0);
            else
                this.Position = 0;
        }

        #endregion

        #region Properties Handlers

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected override void OnPropertyChanged(string propertyName = null)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.Orientation):
                    this.SetOrientation();
                    break;
                case nameof(this.Position):
                    this.UpdatePosition(this.Position);
                    break;
                case nameof(this.ItemsSource):
                case nameof(this.PagerStyle):
                case nameof(this.CustomSize):
                case nameof(this.CustomSelectedColor):
                case nameof(this.CustomUnselectedColor):
                    this.Reset();
                    break;
            }
        }

        private void SetOrientation()
        {
            if (this.Orientation == StackOrientation.Vertical)
            {
                this.VerticalOptions = LayoutOptions.CenterAndExpand;

                AbsoluteLayout.SetLayoutBounds(this, new Rectangle(0, 0, AbsoluteLayout.AutoSize, 1));
                AbsoluteLayout.SetLayoutFlags(this, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.HeightProportional);
            }
            else
            {
                this.HorizontalOptions = LayoutOptions.CenterAndExpand;

                AbsoluteLayout.SetLayoutBounds(this, new Rectangle(0, 1, 1, AbsoluteLayout.AutoSize));
                AbsoluteLayout.SetLayoutFlags(this, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
            }
        }

        #endregion

        #region View Utils
        private ShapeView BuildIndicator(bool selected, int position)
        {
            var currentItem = this.ItemsSource.ElementAt(position);

            var view = this.GetApplicableView(currentItem, selected);

            view.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => this.Position = position)
            });

            return view;
        }

        private ShapeView GetApplicableView(BasePageableItem item, bool selected)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var result = new ShapeView
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            this.UpdateView(item, selected, result);

            return result;
        }

        private void UpdateView(BasePageableItem item, bool selected, ShapeView view)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var style = item.CustomPagerStyle ?? this.PagerStyle;
            var color = selected ? item.CustomSelectedColor ?? this.CustomSelectedColor ?? Color.White : item.CustomUnselectedColor ?? this.CustomUnselectedColor ?? Color.FromRgba(1, 1, 1, 0.5);
            var size = this.GetApplicableSize(item, style);

            view.Color = color;
            view.HeightRequest = size.Height;
            view.WidthRequest = size.Width;
            view.ClassId = selected.ToString();

            switch (style)
            {
                case PagerStyle.Rectangle:
                case PagerStyle.Square:
                    view.ShapeType = ShapeType.Box;
                    break;
                case PagerStyle.RoundedRectangle:
                case PagerStyle.RoundedSquare:
                    view.CornerRadius = (float) (size.Height + size.Width)/10f;
                    break;
                case PagerStyle.Star:
                    view.ShapeType = ShapeType.Star;
                    break;
                case PagerStyle.Triangle:
                    view.ShapeType = ShapeType.Triangle;
                    break;
                case PagerStyle.Oval:
                    view.ShapeType = ShapeType.Oval;
                    break;
                case PagerStyle.Diamond:
                    view.ShapeType = ShapeType.Diamond;
                    break;
                case PagerStyle.Heart:
                    view.ShapeType = ShapeType.Heart;
                    break;
                case PagerStyle.Circle:
                default:
                    view.ShapeType = ShapeType.Circle;
                    break;
            }
        }

        private Size GetApplicableSize(BasePageableItem item, PagerStyle style)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var size = item.CustomSize ?? this.CustomSize;

            if (size.HasValue)
                return size.Value;
            else
            {
                switch (style)
                {
                    case PagerStyle.Rectangle:
                    case PagerStyle.Oval:
                        return new Size(8, 4);
                    case PagerStyle.Diamond:
                        return new Size(6, 8);
                    case PagerStyle.Square:
                    case PagerStyle.Circle:
                    case PagerStyle.Star:
                    case PagerStyle.Triangle:
                    case PagerStyle.Heart:
                    default:
                        return new Size(8, 8);
                }
            }
        }

        #endregion
    }
}