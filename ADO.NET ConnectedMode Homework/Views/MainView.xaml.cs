using System;
using System.Linq;
using System.Text;
using System.Windows;
using ADO.NET_ConnectedMode_Homework.ViewModels;


namespace ADO.NET_ConnectedMode_Homework.Views {
    public partial class MainView : Window {
        public MainView() {
            InitializeComponent();
            DataContext = new MainViewModel(AuthorsCB, CategoriesCB, BooksGrid);
        }
    }
}
