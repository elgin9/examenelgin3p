using Plugin.Maui.Audio;
using examenelgin3p.Views;
using examenelgin3p.Controllers;
using examenelgin3p.Models;

namespace examenelgin3p
{
    public partial class App : Application
    {
        public static FirebaseController db = new FirebaseController();
        public static Notas nota;

        public App()
        {
            InitializeComponent();

           
            MainPage = new NavigationPage(new Principal(AudioManager.Current));

        }

       
    }
}
