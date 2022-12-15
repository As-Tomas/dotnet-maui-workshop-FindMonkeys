namespace MonkeyFinder.ViewModel;

public class BaseViewModel : INotifyPropertyChanged
{
    bool isBusy;
    string title;


    public bool IsBusy
    {
        get => isBusy; 
        set
        {
            if (isBusy == value) {
                return;
            }
            isBusy = value;

            OnPropertyChanged();
            OnPropertyChanged(nameof(IsNotBusy));
            // OnPropertyChanged("isBusy"); // simple way
            // OnPropertyChanged(nameof(isBusy)); // returns name in the way of string of this property or method
            
        }
    }
    public string Title
    {
        get => title;
        set
        { 
            if (title == value) 
                return;
             
            title = value;

            OnPropertyChanged();
        }
    }

    public bool IsNotBusy => !IsBusy;

    public event PropertyChangedEventHandler PropertyChanged;


    // public void OnPropertyChanged(string propertyName)
    // Get a caller member name wich is isBusy then no need OnPropertyChanged(pass a string)
    public void OnPropertyChanged([CallerMemberName]string propertyName =null) // run time copiler name
    {
        // does null check and if anything is subscribed to this event if so then invoke it
        // it pass this it self what the view model is and pass in that specific property name
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
