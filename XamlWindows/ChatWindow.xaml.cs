using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamlWindows
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private double backupHeight;

        public MessageCollection messages = new MessageCollection();
        private Storyboard scrollViewerStoryboard;
        private DoubleAnimation scrollViewerScrollToEndAnim;

        private MessageSide curside;

        #region VerticalOffset DP

        /// <summary>
        /// VerticalOffset, a private DP used to animate the scrollviewer
        /// </summary>
        private DependencyProperty VerticalOffsetProperty = DependencyProperty.Register("VerticalOffset",
          typeof(double), typeof(ChatWindow), new PropertyMetadata(0.0, OnVerticalOffsetChanged));

        private static void OnVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ChatWindow app = d as ChatWindow;
            app.OnVerticalOffsetChanged(e);
        }

        private void OnVerticalOffsetChanged(DependencyPropertyChangedEventArgs e)
        {
            ConversationScrollViewer.ScrollToVerticalOffset((double)e.NewValue + 100);
        }

        #endregion

        public ChatWindow()
        {
            InitializeComponent();

            backupHeight = Height;
            Left = SystemParameters.FullPrimaryScreenWidth - this.Width;
            Top = SystemParameters.FullPrimaryScreenHeight - 33;
            popupAnimation.From = Top;
            popupAnimation.To = SystemParameters.FullPrimaryScreenHeight - this.Height;
            pullDownAnimation.From = SystemParameters.FullPrimaryScreenHeight - this.Height;
            pullDownAnimation.To = Top;
            Height = 33;

            // FOLLOWING CODEBLOCK IS ONLY FOR DEMONSTRATION PURPOSES
            messages.Add(new Message()
            {
                Side = MessageSide.You,
                Text = "Hello sir. How may I help you?"
            });

            curside = MessageSide.You;
            // END OF DEMO BLOCK
            
            this.DataContext = messages;

            scrollViewerScrollToEndAnim = new DoubleAnimation()
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new SineEase()
            };
            Storyboard.SetTarget(scrollViewerScrollToEndAnim, this);
            Storyboard.SetTargetProperty(scrollViewerScrollToEndAnim, new PropertyPath(VerticalOffsetProperty));

            scrollViewerStoryboard = new Storyboard();
            scrollViewerStoryboard.Children.Add(scrollViewerScrollToEndAnim);
            this.Resources.Add("foo", scrollViewerStoryboard);

            TextInput.Focus();
        }

        private void TextInput_GotFocus(object sender, RoutedEventArgs e)
        {
            ScrollConversationToEnd();
        }

        private void ScrollConversationToEnd()
        {
            scrollViewerScrollToEndAnim.From = ConversationScrollViewer.VerticalOffset;
            scrollViewerScrollToEndAnim.To = ConversationContentContainer.ActualHeight;
            scrollViewerStoryboard.Begin();
        }

        private void TextInput_LostFocus(object sender, RoutedEventArgs e)
        {
            ScrollConversationToEnd();
        }

        private void addTextMe(string text)
        {
            messages.Add(new Message()
            {
                Side = MessageSide.Me,
                Text = text,
                PrevSide = curside
            });

            curside = MessageSide.Me;

            ScrollConversationToEnd();

            TextInput.Text = "";
            TextInput.Focus();
        }

        private void addTextYou(string text)
        {
            messages.Add(new Message()
            {
                Side = MessageSide.You,
                Text = text,
                PrevSide = curside
            });

            curside = MessageSide.You;

            ScrollConversationToEnd();

            TextInput.Text = "";
            TextInput.Focus();
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
            addTextMe(TextInput.Text);
        }

        private void TextInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                buttonSend_Click(null, null);
            }
        }
    }
}
