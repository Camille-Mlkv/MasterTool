using System.Text.RegularExpressions;

namespace MasterTool.UI.Services
{
    public class BankCardTypeRegexService
    {
        public static Regex MasterCard
            = new(@"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$");

        public static Regex Visa
            = new(@"^4[0-9]{12}(?:[0-9]{3})?$");
    }
}
