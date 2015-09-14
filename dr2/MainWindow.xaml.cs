using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using dr2.Controls;

namespace dr2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var child in this.LeftContainer.Children)
            {
                if (!(child is User)) { continue; }

                var user = child as User;
                user.Delete += OnUserDelete;
            }

            foreach (var child in this.RightContainer.Children)
            {
                if (!(child is Post)) { continue; }

                var post = child as Post;
                post.Delete += OnPostDelete;
            }
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User();
            newUser.Width = 80;
            newUser.Height = 80;
            newUser.Margin = new Thickness(5, 5, 5, 5);
            newUser.UserName = "Prijatelj";
            newUser.Delete += OnUserDelete;

            this.LeftContainer.Children.Add(newUser);
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            var newPost = new Post();
            newPost.Margin = new Thickness(30, 15, 30, 15);
            newPost.Background = Brushes.GreenYellow;
            newPost.PostText = "Post text";
            newPost.Delete += OnPostDelete;

            this.RightContainer.Children.Add(newPost);
        }

        void OnUserDelete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }

            var user = sender as User;

            this.LeftContainer.Children.Remove(user);
        }

        void OnPostDelete(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post)) { return; }

            var post = sender as Post;

            this.RightContainer.Children.Remove(post);
        }
    }
}
