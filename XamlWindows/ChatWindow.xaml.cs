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
using System.Windows.Shapes;

namespace XamlWindows
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private double backupHeight;

        public ChatWindow()
        {
            InitializeComponent();
            backupHeight = Height;
            Left = SystemParameters.FullPrimaryScreenWidth-this.Width;
            Top = SystemParameters.FullPrimaryScreenHeight - 33;
            popupAnimation.From = Top;
            popupAnimation.To = SystemParameters.FullPrimaryScreenHeight - this.Height;
            pullDownAnimation.From = SystemParameters.FullPrimaryScreenHeight - this.Height;
            pullDownAnimation.To = Top;
            Height = 33;
        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StoryboardPullDown_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            popupAnimation.From = Top;
            pullDownAnimation.From = Top;
            Height = SystemParameters.FullPrimaryScreenHeight - Top;
        }

        private void StoryboardPopup_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            popupAnimation.From = Top;
            pullDownAnimation.From = Top;
            Height = SystemParameters.FullPrimaryScreenHeight - Top;
        }

        private void StoryboardPullDown_Completed(object sender, EventArgs e)
        {
            popupAnimation.From = pullDownAnimation.To;
            pullDownAnimation.From = pullDownAnimation.To;
            Height = 33;
        }

        private void StoryboardPopup_Completed(object sender, EventArgs e)
        {
            popupAnimation.From = popupAnimation.To;
            pullDownAnimation.From = popupAnimation.To;
            Height = backupHeight;
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
