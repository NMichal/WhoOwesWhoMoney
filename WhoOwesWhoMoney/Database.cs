using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoOwesWhoMoney
{
    class Database
    {
        public static SQLite.Net.SQLiteConnection connectionObjWpis;

        public static void Init()
        {
            PodlaczLubStworzBaze();
        }

        private static void PodlaczLubStworzBaze()
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
                Current.LocalFolder.Path, "db.sqlite");

            connectionObjWpis = new SQLite.Net.SQLiteConnection(new
               SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            connectionObjWpis.CreateTable<ObjWpis>();
        }


        public static bool Insert(ObjWpis wpis)
        {
            try
            {
                connectionObjWpis.Insert(wpis);
                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }



        public static List<ObjWpis> ListaAkrywnychWpisow()
        {
            List<ObjWpis> aktywneWpisy = connectionObjWpis.Table<ObjWpis>().Where(c => c.Aktywne == "1").ToList<ObjWpis>();
            return aktywneWpisy;
        }


        public static ObjWpis ZwrocWpis(int id)
        {
            ObjWpis wpis = connectionObjWpis.Table<ObjWpis>().Where(c => c.ID == id).FirstOrDefault();
            return wpis;
        }




        public void CreateDatabase(string DB_PATH)
        {
            if (!CheckFileExists(DB_PATH).Result)
            {
                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
                {
                    conn.CreateTable<ObjWpis>();

                }
            }
        }
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
