using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praksa.Common
{
    public interface IPage
    {
		int PageNumber { get; set; }

		int PageSize
		{ get; set; }
	}
}
