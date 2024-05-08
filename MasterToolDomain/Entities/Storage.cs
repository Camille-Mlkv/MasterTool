using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Storage
    {
        private List<Detail>? Details {  get; set; }
        private List<Material>? Materials { get; set; }


        private static Storage? instance;
        private Storage(){ }

        public static Storage GetInstance()
        {
            if (instance == null)
                instance = new Storage();
            return instance;
        }
    }
}
