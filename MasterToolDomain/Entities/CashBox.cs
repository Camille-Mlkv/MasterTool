
namespace MasterToolDomain.Entities
{
    struct CashNote
    {
        public bool IsIncome { get; set; }
        public string Info { get; set; }
        public double Sum { get; set; }
    }

    public class CashBox
    {
        private List<CashNote>? Notes {  get; set; }

        private static CashBox? instance;
        private CashBox() { }
        public static CashBox GetInstance()
        {
            if(instance == null)
            {
                instance = new CashBox();
            }
            return instance;
        }
    }

    
}
