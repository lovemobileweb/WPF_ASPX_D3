using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamlWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChatWindow windowChat = new ChatWindow();
        //private TestWindow windowTest = new TestWindow();

        public MainWindow()
        {
            InitializeComponent();
            Left = SystemParameters.FullPrimaryScreenWidth - 3;
            slideOutAnimation.From = Left;
            slideOutAnimation.To = SystemParameters.FullPrimaryScreenWidth-this.Width;
            slideInAnimation.From = SystemParameters.FullPrimaryScreenWidth - this.Width;
            slideInAnimation.To = Left;

            windowChat.Show();
            //windowTest.Show();
        }

        private void StoryboardSlideIn_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            slideOutAnimation.From = Left;
        }

        private void StoryboardSlideOut_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            slideInAnimation.From = Left;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void windowMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            windowChat.Close();
            //windowTest.Close();
        }
    }
}
