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
        private static SQLite.Net.SQLiteConnection connectionObjWpis;

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

        public static bool Update(ObjWpis wpis)
        {
            try
            {
                connectionObjWpis.Update(wpis);
                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Zmienia status podanego wpisu na nieaktualny
        /// </summary>
        public static bool UsunWpis(ObjWpis wpis)
        {
            try
            {
                wpis.Aktywne = "0";
                connectionObjWpis.Update(wpis);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }



        public static List<ObjWpis> ListaWszystkichWpisow()
        {
            List<ObjWpis> aktywneWpisy = connectionObjWpis.Table<ObjWpis>().ToList<ObjWpis>();
            return aktywneWpisy;
        }

        public static List<ObjWpis> ListaAkrywnychWpisowOdKogos()
        {
            List<ObjWpis> aktywneWpisyOdKogos = connectionObjWpis.Table<ObjWpis>().Where(c => c.Aktywne == "1" && c.PokzyczamKomus == "False").ToList<ObjWpis>();
            return aktywneWpisyOdKogos;
        }

        public static List<ObjWpis> ListaAkrywnychWpisowPozyczonychKomus()
        {
            List<ObjWpis> aktywneWpisyPozyczoneKomus = connectionObjWpis.Table<ObjWpis>().Where(c => c.Aktywne == "1" && c.PokzyczamKomus == "True").ToList<ObjWpis>();
            return aktywneWpisyPozyczoneKomus;
        }

        public static ObjWpis ZwrocWpis(int id)
        {
            ObjWpis wpis = connectionObjWpis.Table<ObjWpis>().Where(c => c.ID == id).FirstOrDefault();
            return wpis;
        }
    }
}
