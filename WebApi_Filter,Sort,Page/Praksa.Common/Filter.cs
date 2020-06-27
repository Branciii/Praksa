using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Praksa.Common
{
    public class StudentFilter : IFilter
    {
        public string FilterString { get; set; } = "";

        public List<String> StudentNames = new List<String>();

        public void StringToNameAndSurname()
        {
            StudentNames = FilterString.Split(new Char[] { '-', ' '}).ToList();
            StudentNames = StudentNames.Union(FilterString.Split(' ').ToList()).ToList();
        }

        //ako nam nisu dani nikakvi parametri po kojima ćemo tražiti
        //ova funkcija vraća False i ćemo tada vraćati sve studente
        public bool EmptyFilterString()
        {
            return (FilterString == "");
        }
    }
}
