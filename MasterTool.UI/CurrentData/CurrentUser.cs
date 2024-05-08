using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.CurrentData
{
    public static class CurrentUser
    {
        public static Master CurrentMaster = new Master();
        public static Client CurrentClient = new Client();
        public static Admin CurrentAdmin = new Admin();
    }
}
