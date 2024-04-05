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

namespace SecretWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddGamesToList();
        }

        private void AddGamesToList()
        {
            GamesList.Items.Add("City Car Driving");
            GamesList.Items.Add("Subway Surfers");
            GamesList.Items.Add("Agar.io");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string newGame = gamingBox.Text;
            if (!string.IsNullOrEmpty(newGame))
            {
                GamesList.Items.Add(newGame);
                gamingBox.Clear();
            }
            else
            {
                MessageBox.Show("Proszę wpisać nazwę gry");
            }
        }

        private void GameList_SekectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GamesList.SelectedItem != null)
            {
                var gameToRemove = GamesList.SelectedItem;
                var result = MessageBox.Show($"Czy na pewno chcesz usunąć grę" +
                    $"{gameToRemove}", "Usuwanie", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    GamesList.Items.Remove(gameToRemove);
                }

                GamesList.SelectedItem = null;
            }
        }

        private void GameList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var gameToRemove = GamesList.SelectedItem;
            if (gameToRemove != null)
            {
                GamesList.Items.Remove(gameToRemove);
            }
        }
    }
}
