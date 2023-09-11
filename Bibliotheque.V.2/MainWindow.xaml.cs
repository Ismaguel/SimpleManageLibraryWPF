using Bibliotheque.V._2.View;
using Bibliotheque.V._2.ViewModel;
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

namespace Bibliotheque.V._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isLib;
        ImprinterView imprinterView;
        ImprintView imprintView;
        BookView bookView;

        public MainWindow()
        {
            InitializeComponent();
            BookViewModel bibliothèqueView = new BookViewModel() ;
            imprinterView = new ImprinterView() { DataContext = new ImprinterViewModel() };
            imprintView = new ImprintView() { DataContext = new ImprintViewModel() };
            bookView = new BookView() { DataContext = new BookViewModel() };
            isLib = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        private void Emprinteur_GotFocus(object sender, RoutedEventArgs e)
        {
            if (isLib)
            {
                GridViews.Child = imprinterView;
            }
        }
        private void Livre_GotFocus(object sender, RoutedEventArgs e)
        {
            if (isLib)
            {
                GridViews.Child = bookView;
            }
        }
        private void Emprint_GotFocus(object sender, RoutedEventArgs e)
        {
            if (isLib)
            {
                GridViews.Child = imprintView;
            } 
        }

    }
}
