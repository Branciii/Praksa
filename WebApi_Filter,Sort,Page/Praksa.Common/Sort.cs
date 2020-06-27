using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praksa.Common
{
    public class StudentSort : ISort
    {
        public string _OrderBy { get; set; } = "prezime";
        public string _Order { get; set; } = "asc";

		public string Order
		{
			get
			{
				return _Order;
			}
			set
			{
				_Order = ((value !="asc")&&(value!="desc")) ? "asc" : value;
			}
		}

		public string OrderBy
		{
			get
			{
				return _OrderBy;
			}
			set
			{
				_OrderBy = ((value != "ime") && (value != "prezime")) ? "prezime" : value;
			}
		}



	}
}
