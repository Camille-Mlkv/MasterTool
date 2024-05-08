using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Notification
    {
        private int Id {  get; set; }
        private string? Message { get; set; }
        private int RequestId { get; set; }
    }
}
