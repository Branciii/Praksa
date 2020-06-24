using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Praksa.Common
{
    public class StudentFilter : QueryStringParameter
    {
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public bool StudentHasName()
        {
            return ((StudentName != "") && (StudentName != null));
        }
        public bool StudentHasSurname()
        {
            return ((StudentSurname != "") && (StudentSurname != null));
        }
    }
}
