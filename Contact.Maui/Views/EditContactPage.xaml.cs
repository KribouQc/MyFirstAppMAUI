using Contact.Maui.Models;
using Contacte = Contact.Maui.Models.Contact;

namespace Contact.Maui.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private Contacte contact;
	
	public EditContactPage()
	{
		InitializeComponent();
	}

    /*void btnCancel_Clicked(System.Object sender, System.EventArgs e)
    {
		
    }*/

	public string ContactId {
		set {
			contact = ContactRepository.GetContactById(int.Parse(value));
            contactCtrl.Adress = contact.Adress;
            contactCtrl.Phone = contact.Phone;
            contactCtrl.Email = contact.Email;
            contactCtrl.Name = contact.Name;
        }
	}

    void contactCtrl_OnCancel(System.Object sender, System.EventArgs e)
    {
        
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }

    void contactCtrl_OnError(System.Object sender, System.String e)
    {
        DisplayAlert("Error", e, "Ok");
    }  

    void contactCtrl_OnSave(System.Object sender, System.EventArgs e)
    {
        contact.Adress = contactCtrl.Adress;
        contact.Phone = contactCtrl.Phone;
        contact.Email = contactCtrl.Email;
        contact.Name = contactCtrl.Name;

        ContactRepository.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync($"//{nameof(ContactPage)}");
    }
}
