using System;
using System.IO;
using Tarea1_4PM02.Controller;
using Xamarin.Forms;


namespace Tarea1_4PM02
{
    public partial class App : Application
    {
        static DB db;

        public static DB dba
        {
            get
            {
                if (db == null)
                {
                    String folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbaFotos.db3");

                    db = new DB(folderPath);
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
