using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace PZ10p4 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            // var view = (CollectionView)CollectionViewSource.GetDefaultView(ListView.ItemsSource);
            // var groupDescription = new PropertyGroupDescription(nameof(Note.IsCompleted));
            // view.GroupDescriptions.Add(groupDescription);
            _viewModel = (MainWindowViewModel)DataContext;
        }

        private MainWindowViewModel _viewModel;
        private void Lbox_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
            if (_viewModel.SelectedNote is null) {
                return;
            }
            _viewModel.SelectedNote.IsCompleted = true;
            _viewModel.CompletedNotes.Add(_viewModel.SelectedNote);
            _viewModel.Notes.Remove(_viewModel.SelectedNote);
        }

        private void AddNote(object sender, RoutedEventArgs e) => _viewModel.AddNote();
        private void RemoveSelectedNote(object sender, RoutedEventArgs e) => _viewModel.RemoveSelectedNote();
    }
}