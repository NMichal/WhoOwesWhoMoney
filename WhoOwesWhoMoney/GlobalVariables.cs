using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WhoOwesWhoMoney
{
    class GlobalVariables
    {
        public static StorageFile dataFile;


        public static async void Init()
        {
            Windows.Storage.StorageFolder storageFolder  = Windows.Storage.ApplicationData.Current.LocalFolder;
            dataFile = await storageFolder.CreateFileAsync("data.csv",                   
                Windows.Storage.CreationCollisionOption.OpenIfExists);  
        }


        public static async void ZapiszDoPliku(string tekst)
        {
            await Windows.Storage.FileIO.AppendTextAsync(dataFile, tekst);

            //string text = await Windows.Storage.FileIO.ReadTextAsync(dataFile);
            // Zczytanie całego pliku
        }
        
    }
}
