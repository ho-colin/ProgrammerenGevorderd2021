# WPF Command Pattern: een inleiding

## Maak een class die interface ICommand implementeert

```c#
using KlantBestellingen.WPF.ViewModels;
using Serilog;
using System;
using System.Windows.Input;

namespace KlantBestellingen.WPF.Commands
{
    public class NieuwProductCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ProductenViewModel _source;

        public NieuwProductCommand(ProductenViewModel source)
        {
            _source = source;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Log.Information("-> NieuwProductCommand::Execute");
            Log.Information("<- NieuwProductCommand::Execute");
        }
    }
}

```

- Plaats class in een subdirectory "Commands" en pas namespace naam aan
  - Betere leesbaarheid

  ## ViewModel

  ```c#
  public class ProductenViewModel : INotifyPropertyChanged
  {
          public ICommand BtnNieuwProductCommand { get; set; }
  
          public event PropertyChangedEventHandler PropertyChanged;
  
          public ProductenViewModel()
          {
              BtnNieuwProductCommand = new NieuwProductCommand(this);
          }
  }
  ```

  

## Specificeer Command in xaml

```xml
<Button x:Name="BtnNieuwProduct" Command="{Binding Path=BtnNieuwProductCommand}"/>
```