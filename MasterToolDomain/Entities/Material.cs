using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Material
    {
        private int Id {  get; set; }
        private string? Name { get; set; }
        private double Tarif {  get; set; }
        private double Weight { get; set; }

    }
}
