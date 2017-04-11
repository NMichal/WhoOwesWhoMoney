using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoOwesWhoMoney
{
    class ObjWpis
    {

        //The Id property is marked as the Primary Key  
        [SQLite.Net.Attributes.PrimaryKey, SQLite.Net.Attributes.AutoIncrement]
        public int ID { get; set; }
        public string Data { get; set; }
        public string DataOddania { get; set; }
        public string Kto { get; set; }
        public string Miejsce { get; set; }
        public string ZaCo { get; set; }
        public string Kwota { get; set; }
        public string Email { get; set; }
        public string DodatkoweInfo { get; set; }
        public string Aktywne { get; set; }

        public ObjWpis()
        {
            //empty constructor  
        }
        public ObjWpis(string name, string phone_no)
        {
            //Name = name;
            //PhoneNumber = phone_no;
            //CreationDate = DateTime.Now.ToString();
        }
    }

}
