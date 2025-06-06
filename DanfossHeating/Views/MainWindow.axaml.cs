using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;
using DanfossHeating.ViewModels;
using Avalonia.Markup.Xaml;

namespace DanfossHeating.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel? _viewModel;
    private ContentControl? _mainContent;
    private Grid? _loginPanel;

    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WindowState = WindowState.Maximized;
        
        Loaded += MainWindow_Loaded;
        DataContextChanged += MainWindow_DataContextChanged;
    }
    
    private void MainWindow_Loaded(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine("MainWindow loaded");
        
        // Find controls after window is loaded
        _mainContent = this.FindControl<ContentControl>("MainContent");
        _loginPanel = this.FindControl<Grid>("LoginPanel");
        
        if (_mainContent == null)
            Console.WriteLine("ERROR: MainContent control not found!");
        else
            Console.WriteLine("MainContent control found successfully");
            
        if (_loginPanel == null)
            Console.WriteLine("ERROR: LoginPanel control not found!");
        else
            Console.WriteLine("LoginPanel control found successfully");
    }

    private void MainWindow_DataContextChanged(object? sender, EventArgs e)
    {
        if (_viewModel != null)
        {
            _viewModel.NavigateToPage -= ViewModel_NavigateToPage;
        }

        _viewModel = DataContext as MainWindowViewModel;
        
        if (_viewModel != null)
        {
            _viewModel.NavigateToPage += ViewModel_NavigateToPage;
            Console.WriteLine("MainWindow DataContext set up and ready");
        }
        else
        {
            Console.WriteLine("WARNING: DataContext is not MainWindowViewModel");
        }
    }

    private void ViewModel_NavigateToPage(object? sender, NavigationEventArgs e)
    {
        try
        {
            // Updating UI on the thread
            if (Dispatcher.UIThread.CheckAccess())
            {
                PerformNavigation(e);
            }
            else
            {
                Dispatcher.UIThread.InvokeAsync(() => PerformNavigation(e));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Navigation error: {ex.Message}\n{ex.StackTrace}");
        }
    }
    
    private void PerformNavigation(NavigationEventArgs e)
    {
        Console.WriteLine($"Navigation event received for {e.ViewModel.GetType().Name}");
        
        if (_mainContent == null)
        {
            Console.WriteLine("Finding MainContent control again...");
            _mainContent = this.FindControl<ContentControl>("MainContent");
        }
        
        if (_mainContent == null)
        {
            Console.WriteLine("ERROR: MainContent is still null!");
            return;
        }
            
        // Cast the ViewModel to ViewModelBase to access PageType
        var viewModel = e.ViewModel as ViewModelBase;
        if (viewModel == null)
        {
            Console.WriteLine($"ERROR: ViewModel is not of type ViewModelBase: {e.ViewModel.GetType().Name}");
            return;
        }
        
        UserControl? page = null;
        
        // Pass the main view model to page view models for navigation
        if (viewModel is HomePageViewModel homeViewModel && _viewModel != null)
        {
            homeViewModel.SetMainViewModel(_viewModel);
        }
        
        switch (viewModel.PageType)
        {
            case PageType.Home:
                page = new HomePage() { DataContext = viewModel };
                break;
            case PageType.Optimizer:
                page = new OptimizerPage() { DataContext = viewModel };
                break;
            case PageType.Machinery:
                page = new MachineryPage() { DataContext = viewModel };
                break;
            case PageType.AboutUs:
                page = new AboutUsPage() { DataContext = viewModel };
                break;
            default:
                Console.WriteLine($"ERROR: Unknown page type: {viewModel.PageType}");
                return;
        }
        
        if (page != null)
        {
            _mainContent.Content = page;
            Console.WriteLine($"Navigation to {viewModel.PageType} successful");
        }
    }
}