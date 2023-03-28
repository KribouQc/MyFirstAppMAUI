namespace Contact.Maui.Views.Controls;

public partial class ContactCtrl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;

	public ContactCtrl()
	{
		InitializeComponent();
	}

	public string Name {
		get {
			return entryName.Text;
			}
		set {
			entryName.Text = value;
		}
	}

    public string Email
    {
        get
        {
            return entryEmail.Text;
        }
        set
        {
            entryEmail.Text = value;
        }
    }

    public string Phone
    {
        get
        {
            return entryPhone.Text;
        }
        set
        {
            entryPhone.Text = value;
        }
    }

    public string Adress
    {
        get
        {
            return entryAdress.Text;
        }
        set
        {
            entryAdress.Text = value;
        }
    }

    void btnSave_Clicked(System.Object sender, System.EventArgs e)
    {
        if (nameValidator.IsNotValid) {
            OnError?.Invoke(sender, "The name is required");
            return;
        }

        if (emailValidator.IsNotValid) {
            foreach (var error in emailValidator.Errors)
            {
                OnError?.Invoke(sender, error.ToString());
                return;
            }
        }

        OnSave?.Invoke(sender, e);
    }

    void btnCancel_Clicked(System.Object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}
