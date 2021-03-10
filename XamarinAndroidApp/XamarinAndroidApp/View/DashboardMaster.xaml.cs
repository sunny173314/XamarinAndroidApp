using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAndroidApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardMaster : ContentPage
    {
        public ListView ListView;

        public DashboardMaster()
        {
            InitializeComponent();

            BindingContext = new DashboardMasterViewModel();
            ListView = MenuItemsListView;
        }

        class DashboardMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<DashboardMasterMenuItem> MenuItems { get; set; }

            public DashboardMasterViewModel()
            {
                MenuItems = new ObservableCollection<DashboardMasterMenuItem>(new[]
                {
                    new DashboardMasterMenuItem { Id =  1, Title = "Lab Test Data ", TargetType=typeof(UserProfile) },
                    new DashboardMasterMenuItem { Id = 0, Title = "User Data", TargetType=typeof(LoginPage) },
                    new DashboardMasterMenuItem { Id = 2, Title = "Dougnut Chart", TargetType=typeof(View.DougnutChart) },
                    //new DashboardMasterMenuItem { Id = 2, Title = "Page 3" },
                    //new DashboardMasterMenuItem { Id = 3, Title = "Page 4" },
                    //new DashboardMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion
        }
    }
}