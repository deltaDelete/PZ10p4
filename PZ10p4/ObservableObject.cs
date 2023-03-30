using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PZ10p4;

public class ObservableObject : INotifyPropertyChanged, INotifyPropertyChanging {
    public event PropertyChangedEventHandler? PropertyChanged;
    public event PropertyChangingEventHandler? PropertyChanging;

    public void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "") {
        RaisePropertyChanging(propertyName);
        field = value;
        RaisePropertyChanged(propertyName);
    }

    public void SetPropertyIfChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = "") {
        if (!Equals(field, value)) {
            SetProperty(ref field, value);
        }
    }

    public void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void RaisePropertyChanging([CallerMemberName] string propertyName = "") {
        PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }
}