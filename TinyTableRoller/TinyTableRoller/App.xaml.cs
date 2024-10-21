using System.Text.Json;
using TinyTableRoller.Data;

namespace TinyTableRoller
{
    public partial class App : Application
    {
        public IServiceProvider Services { get; private set; }

        public App(IServiceProvider provider)
        {
            InitializeComponent();

            Services = provider;

            MainPage = new AppShell();
        }
    }
}
