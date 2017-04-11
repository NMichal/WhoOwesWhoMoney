using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

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

            string text = await Windows.Storage.FileIO.ReadTextAsync(dataFile);
            // Zczytanie całego pliku
            foreach (var item in text.Split('\n'))
            {
                Debug.WriteLine(item); // tutaj dostajemy jeden wiersz
                Debug.WriteLine(item.Split(';').Count());
            }
        }



        public static async void PodniesID()
        {
            ID++;
            await Windows.Storage.FileIO.WriteTextAsync(dataID, ID.ToString());
        }

    }
}
