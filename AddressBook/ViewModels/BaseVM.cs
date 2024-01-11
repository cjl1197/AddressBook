using CommunityToolkit.Mvvm.ComponentModel;

namespace AddressBook;

public partial class BaseVM : ObservableObject
{
    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    string title;
    public bool IsNotBusy => !IsBusy;
}
