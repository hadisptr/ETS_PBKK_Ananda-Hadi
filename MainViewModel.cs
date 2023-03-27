using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Evaluasi_Tengah_Semester
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ContactRepository contactRepository;
        private List<Contact> contacts;

        public MainViewModel(string dbPath)
        {
            contactRepository = new ContactRepository(dbPath);
            LoadContacts();
            AddContactCommand = new Command(async () => await AddContact());
            DeleteContactCommand = new Command<Contact>(async (contact) => await DeleteContact(contact));
        }

        public List<Contact> Contacts
        {
            get { return contacts; }
            set
            {
                contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        private Contact selectedContact;

        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public ICommand AddContactCommand { get; }
        public ICommand DeleteContactCommand { get; }

        private async Task AddContact()
        {
        }

        private async Task DeleteContact(Contact contact)
        {
        }

        private async void LoadContacts()
        {
            Contacts = await contactRepository.GetContactsAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
 }
