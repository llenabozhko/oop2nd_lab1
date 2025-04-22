using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace block5;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click_Color(object sender, RoutedEventArgs e)
    {
        if (Background == Brushes.Crimson)
        {
            Background = Brushes.Yellow;
        }
        else
        {
            Background = Brushes.Crimson;
        }
    }

    private void Button_Click_Opacity(object sender, RoutedEventArgs e)
    {
        if (Opacity > 0.7)
        {
            Opacity -= 0.3;
        }
        else
        {
            Opacity += 0.3;
        }
    }

    private void Button_Click_Hello(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Привіт!", "Привітання", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
    }

    private void CheckBox_Click(object sender, RoutedEventArgs e)
    {
        if (sender is CheckBox checkBox)
        {
            RoutedEventHandler handler = checkBox.Name switch
            {
                "checkColor" => Button_Click_Color,
                "checkOpacity" => Button_Click_Opacity,
                "checkHello" => Button_Click_Hello,
                _ => null
            };

            if (handler != null)
            {
                if (checkBox.IsChecked == true)
                {
                    superButton.Click += handler;
                }
                else
                {
                    superButton.Click -= handler;
                }
            }
        }
    }

    private void Button_Click_Super(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Я супер-кнопка і у мене цього не віднімеш;)");
    }

    private void DragBar_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void Button_CloseWindow(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
