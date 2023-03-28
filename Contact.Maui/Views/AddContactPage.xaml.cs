using Contact.Maui.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using Contacte = Contact.Maui.Models.Contact;


namespace Contact.Maui.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

   

    async void contactCtrl_OnCancel(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    void contactCtrl_OnError(System.Object sender, System.String e)
    {
        DisplayAlert("Erreur", e, "OK");
    }

    async void contactCtrl_OnSave(System.Object sender, System.EventArgs e)
    {
        var contact = new Contacte();
        contact.Adress = contactCtrl.Adress;
        contact.Phone = contactCtrl.Phone;
        contact.Email = contactCtrl.Email;
        contact.Name = contactCtrl.Name;

        ContactRepository.AddContact(contact);

        await Shell.Current.GoToAsync("..");

    }
}
