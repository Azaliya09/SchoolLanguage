using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLanguage.Base
{
    public partial class ClientService
    {
        public string TimeStart
        {
            get
            {
                var time = StartTime - DateTime.Now;
                return $"{time.Hours} : {time.Minutes}";
            }
        }
    }
}
