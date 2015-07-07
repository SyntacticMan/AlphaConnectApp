using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace AlphaConnectApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlatoonsPage : Page
    {
        // instanciar os objectos para fazerem a ligação e transformarem o webservice numa lista que pode ser usada pela listview
        WebConnectionTool tool = new WebConnectionTool();
        Tools listTool = new Tools();

        public PlatoonsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void LVPlatoons_Loaded(object sender, RoutedEventArgs e)
        {
            // mudar o link para apontar para o serviço que existe no computador em que esta app vai ser compilada
            string xmlString = await tool.GetXmlFromService("http://192.168.1.111:55555/service1.svc", "getallplatoons", "");
            List<PlatoonModel> platoonsList = listTool.GetPlatoonsList(xmlString);
            LVPlatoons.ItemsSource = platoonsList;
        }
    }
}
