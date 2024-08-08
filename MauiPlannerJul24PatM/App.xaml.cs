using MauiPlannerJul24PatM.MVVM.Views;

namespace MauiPlannerJul24PatM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainView());
            //MainPage = new NewTaskView();
        }
    }
}
