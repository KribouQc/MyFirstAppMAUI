using System.Collections.ObjectModel;
using Contact.Maui.Models;
using Contacte = Contact.Maui.Models.Contact;
using System;


namespace Contact.Maui.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage()
	{
		InitializeComponent();
        

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadList();

    }

    async void listContact_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        if (listContact.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contacte)listContact.SelectedItem).ContactId}");
        }
    }

    void listContact_ItemTapped(System.Object sender, Microsoft.Maui.Controls.ItemTappedEventArgs e)
    {
        listContact.SelectedItem = null;
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(AddContactPage)}");
    }

    void MenuItem_Clicked(System.Object sender, System.EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contacte;

        ContactRepository.DeleteContact(contact.ContactId);
        LoadList();
        
    }
    
    void LoadList() {
        var listContacts = new ObservableCollection<Contacte>(ContactRepository.GetContacts());
        listContact.ItemsSource = listContacts;
    }

    void searchBarContact_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        string textSearch = ((SearchBar)sender).Text;

        if (!string.IsNullOrEmpty(textSearch))
        {
            var listContacts = new ObservableCollection<Contacte>(ContactRepository.SearchContact(textSearch));
            listContact.ItemsSource = listContacts;
        }
        else {
            LoadList();
        }

    }
}


