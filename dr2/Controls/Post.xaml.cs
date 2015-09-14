using System.Windows;
using System.Windows.Controls;

namespace dr2.Controls
{
    /// <summary>
    /// Interaction logic for Post.xaml
    /// </summary>
    public partial class Post : UserControl
    {
        public Post()
        {
            InitializeComponent();
        }

        public string PostText
        {
            get { return (string)GetValue(PostTextProperty); }
            set { SetValue(PostTextProperty, value); }
        }

        public static readonly DependencyProperty PostTextProperty = DependencyProperty.Register
        (
          "PostText",
          typeof(string),
          typeof(Post),
          new UIPropertyMetadata("PostText")
        );


        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        private void PostC_Loaded(object sender, RoutedEventArgs e)
        {
            this.DeleteIcon.MouseDown += (obj, eventHandler) => RaiseDeleteEvent();
        }
    }
}
