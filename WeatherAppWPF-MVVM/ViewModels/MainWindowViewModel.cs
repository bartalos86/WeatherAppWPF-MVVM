using System.Windows;
using System.Windows.Input;
using WeatherAppWPF_MVVM.ViewModels.Base;

namespace WeatherAppWPF_MVVM.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        Window mWindow;

        #region Variables

        private int mOuterMarginSize = 10;
        private int mWindowRadius = 10;

        #endregion


        public MainWindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorder));
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadiusThickness));
            };


            MinimizeCommand = new RelayCommand( () => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow,GetMousePosition()));

            //Fix window resizing 
            var resizer = new WindowResizer(mWindow);
        }

        #region Methods

        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(mWindow);

            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);

        }

        #endregion

        #region Properties

        public double WindowMinimumWidth { get; set; } = 400;
        public double WindowMinimumHeight { get; set; } = 400;

        public int ResizeBorder { get { return Borderless ? 0 : 6; } }
        public bool Borderless { get { return mWindow.WindowState == WindowState.Maximized; } }
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder+OuterMarginSize); } }

        public int OuterMarginSize {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            } set { mOuterMarginSize = value; } }
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set { mWindowRadius = value; }
        }
        public int TitleHeight { get; set; } = 30;
        public int InnerContentPadding { get; set; } = 0;


        public Thickness InnerContentPaddingThickness { get { return new Thickness(InnerContentPadding); } }
        public GridLength TitleHeightGridLenght { get { return new GridLength(TitleHeight+ResizeBorder); } }
        public Thickness OuterMarginThickness { get { return new Thickness(OuterMarginSize); } }
        public CornerRadius WindowCornerRadiusThickness { get { return new CornerRadius(WindowRadius); } }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.MainWeather;


        #endregion

        #region Commands

        public ICommand MenuCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        #endregion
      
    }
}
