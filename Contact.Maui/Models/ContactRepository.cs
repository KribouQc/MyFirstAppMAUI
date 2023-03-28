using System;
namespace Contact.Maui.Models
{
	public class ContactRepository
	{
		private static List<Contact> _contacts = new List<Contact>()
        {   new Contact(){ContactId = 0, Name = "John Doe", Email="john.doe@gmail.com"},
            new Contact(){ContactId = 1, Name = "Jane Doe", Email="jane.doe@gmail.com"},
            new Contact(){ContactId = 2, Name = "Francky Doe", Email="francky.doe@gmail.com"},
            new Contact(){ContactId = 3, Name = "Alex Doe", Email="Alex.doe@gmail.com"},
        };

        public static void AddContact(Contact contact) {
            

            if (_contacts.Count == 0)
            {
                contact.ContactId = 1;
            }
            else
            {
                var contactRecherche = _contacts.Max(x => x.ContactId);
                contact.ContactId = contactRecherche + 1;
            }
            
            _contacts.Add(contact);
        }

        public static List<Contact> SearchContact(string textSearch) {

            List<Contact> searchListContact = new List<Contact>();

            searchListContact = _contacts.Where(x => x.Name.Contains(textSearch,StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (searchListContact.Count > 0)
            {
                return searchListContact;
            }

            searchListContact = _contacts.Where(x => x.Email.Contains(textSearch, StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (searchListContact.Count > 0)
            {
                return searchListContact;
            }

            searchListContact = _contacts.Where(x => x.Phone.Contains(textSearch, StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (searchListContact.Count > 0)
            {
                return searchListContact;
            }

            searchListContact = _contacts.Where(x => x.Adress.Contains(textSearch, StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (searchListContact.Count > 0)
            {
                return searchListContact;
            }

            return searchListContact;
        }

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int contactId) {
            return _contacts.FirstOrDefault(x => x.ContactId == contactId);
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId)
            {
                return;
            }

            var contactUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId); ;

            if(contactUpdate != null) {
                contactUpdate.Name = contact.Name;
                contactUpdate.Adress = contact.Adress;
                contactUpdate.Phone = contact.Phone;
                contactUpdate.Email = contact.Email;
            }
        }

        public static void DeleteContact(int contactId) {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);

            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }
    }
}

