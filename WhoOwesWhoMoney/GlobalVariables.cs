using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.Storage;
using Windows.UI.Popups;

namespace WhoOwesWhoMoney
{
    class GlobalVariables
    {
        public static StorageFile dataFile;
        public static StorageFile dataID;
        public static int ID;

        public static async void Init()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            dataFile = await storageFolder.CreateFileAsync("data.csv",
                Windows.Storage.CreationCollisionOption.OpenIfExists);

            dataID = await storageFolder.CreateFileAsync("dataID",
                Windows.Storage.CreationCollisionOption.OpenIfExists);

            string text = await Windows.Storage.FileIO.ReadTextAsync(dataID);
            try
            {
                ID = Int32.Parse(text);
            }
            catch
            {
                ID = -1;
                PodniesID();
            }
        }


        public static async void ZapiszDoPliku(string tekst)
        {
            await Windows.Storage.FileIO.AppendTextAsync(dataFile, tekst);

            //-------------TEST-------TEST------------TEST---------TEST---------//
            string text = await Windows.Storage.FileIO.ReadTextAsync(dataFile);
            // Zczytanie całego pliku
            foreach (var item in text.Split('\n'))
            {
                Debug.WriteLine(item); // tutaj dostajemy jeden wiersz
                Debug.WriteLine(item.Split(';').Count());
            }
            //-------------TEST-------TEST------------TEST---------TEST---------//
        }

        /// <summary>
        /// Funkcja eksportuje wszystkie dane z bazy do pliku
        /// </summary>
        public static async void EksportDoPliku()
        {
            StorageFile plikEksport;

            Windows.Storage.StorageFolder FolderEksport = Windows.Storage.ApplicationData.Current.LocalFolder;
            plikEksport = await FolderEksport.CreateFileAsync("DaneEksport.csv",
                Windows.Storage.CreationCollisionOption.ReplaceExisting);

            List<ObjWpis> listaWpisow = Database.ListaWszystkichWpisow();
            foreach (ObjWpis wpis in listaWpisow)
            {
                StringBuilder dane = new StringBuilder();
                dane.Append(wpis.ID);
                dane.Append(';');
                dane.Append(wpis.Data);
                dane.Append(';');
                dane.Append(wpis.DataOddania);
                dane.Append(';');
                dane.Append(wpis.Kto);
                dane.Append(';');
                dane.Append(wpis.Miejsce);
                dane.Append(';');
                dane.Append(wpis.ZaCo);
                dane.Append(';');
                dane.Append(wpis.Kwota);
                dane.Append(';');
                dane.Append(wpis.Email);
                dane.Append(';');
                dane.Append(wpis.DodatkoweInfo);
                dane.Append(';');
                dane.Append(wpis.Aktywne);
                dane.Append(';');
                dane.Append(wpis.PokzyczamKomus);
                dane.Append('\n');

                await Windows.Storage.FileIO.AppendTextAsync(plikEksport, dane.ToString());
            }

            // DOROBIĆ ŻE W USTAWIENIACH PODAJEMY EMAIL I KOPIA JEST NA NIEGO WYSYŁANA, NA RAZIE EMAIL NA SZTYWNO
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.To.Add(new EmailRecipient("michal.niewolik@smcebi.edu.pl"));
            string messageBody = "Kopia wpisów z dnia: " + DateTime.Now.ToString();
            emailMessage.Body = messageBody;
            emailMessage.Subject = "Kopia wpisów";
            StorageFile attachmentFile = await FolderEksport.GetFileAsync("DaneEksport.csv");
            if (attachmentFile != null)
            {
                var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);
                var attachment = new Windows.ApplicationModel.Email.EmailAttachment(
                         attachmentFile.Name,
                         stream);
                emailMessage.Attachments.Add(attachment);
            }
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }


        public static async void ImportZPliku()//Co w parametrze ? jak podać wybrany plik, czy tylko nazwa ??? 
        {
            //-------------TEST-------TEST------------TEST---------TEST---------//
            string text = await Windows.Storage.FileIO.ReadTextAsync(dataFile);
            // Zczytanie całego pliku
            foreach (var item in text.Split('\n'))
            {
                Debug.WriteLine(item); // tutaj dostajemy jeden wiersz
                Debug.WriteLine(item.Split(';').Count());
            }
            //-------------TEST-------TEST------------TEST---------TEST---------//
        }



        //Po przejściu na SQLite ta funkcja ni jest potrzebna
        public static async void PodniesID()
        {
            ID++;
            await Windows.Storage.FileIO.WriteTextAsync(dataID, ID.ToString());
        }

    }
}
