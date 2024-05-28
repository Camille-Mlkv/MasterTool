using MasterTool.UI.Services;
using System.Globalization;

namespace MasterTool.UI.Pages.ClientPages;

public partial class CardView : Frame
{
    public static readonly BindableProperty CardNumberProperty
        = BindableProperty.Create(nameof(CardNumber),
            typeof(string), typeof(CardView), null,
            propertyChanged: OnCardNumberChanged);

    public string CardNumber
    {
        get => (string)GetValue(CardNumberProperty);
        set => SetValue(CardNumberProperty, value);
    }

    public static readonly BindableProperty ExpirationDateProperty
        = BindableProperty.Create(nameof(ExpirationDate),
            typeof(DateTime), typeof(CardView), DateTime.Now,
            propertyChanged: OnExpirationDateChanged);

    public DateTime ExpirationDate
    {
        get => (DateTime)GetValue(ExpirationDateProperty);
        set => SetValue(ExpirationDateProperty, value);
    }

    public static readonly BindableProperty CardValidationCodeProperty
    = BindableProperty.Create(nameof(CardValidationCode),
        typeof(string), typeof(CardView), "-",
        propertyChanged: OnCardValidationCodeChanged);

    public string CardValidationCode
    {
        get => (string)GetValue(CardValidationCodeProperty);
        set => SetValue(CardValidationCodeProperty, value);
    }

    private static void OnCardNumberChanged(BindableObject bindable,
        object oldValue, object newValue)
    {
        if (bindable is not CardView creditCardView)
            return;

        creditCardView.SetCreditCardNumber();
    }

    private static void OnExpirationDateChanged(BindableObject bindable,
        object oldValue, object newValue)
    {
        if (bindable is not CardView creditCardView)
            return;

        creditCardView.SetExpirationDate();
    }

    private static void OnCardValidationCodeChanged(BindableObject bindable,
        object oldValue, object newValue)
    {
        if (bindable is not CardView creditCardView)
            return;

        creditCardView.SetCardValidationCode();
    }
    public CardView()
	{
		InitializeComponent();
        BackgroundColor = "Default".ToColorFromResourceKey();

        CreditCardImageLabel.Text = "\uf09d";
        CreditCardImageLabel.FontFamily = "FA6Regular";

        ExpirationDateLabel.Text = "-";

        CardValidationCodeLabel.Text = "-";
    }

    private void SetCreditCardNumber()
    {
        if (string.IsNullOrEmpty(CardNumber))
        {
            BackgroundColor = (Color)Application.Current.Resources["Default"];
            CreditCardImageLabel.Text = "\uf09d";
            CreditCardImageLabel.FontFamily = "FA6Regular";
        }

        if (long.TryParse(CardNumber, out long cardNumberAsLong))
        {
            CreditCardNumber.Text =
                string.Format("{0:0000  0000  0000  0000}", cardNumberAsLong);
        }
        else
        {
            CreditCardNumber.Text = "-";
        }

        var normalizedCardNumber = CardNumber.Replace("-", string.Empty);

        if (BankCardTypeRegexService.MasterCard.IsMatch(normalizedCardNumber))
        {
            BackgroundColor = "MasterCard".ToColorFromResourceKey();
            CreditCardImageLabel.Text = "\uf1f1";
            CreditCardImageLabel.FontFamily = "FA6Brands";
        }
        else if (BankCardTypeRegexService.Visa.IsMatch(normalizedCardNumber))
        {
            BackgroundColor = "Visa".ToColorFromResourceKey();
            CreditCardImageLabel.Text = "\uf1f0";
            CreditCardImageLabel.FontFamily = "FA6Brands";
        }
        else
        {
            BackgroundColor = "Default".ToColorFromResourceKey();
            CreditCardImageLabel.Text = "\uf09d";
            CreditCardImageLabel.FontFamily = "FA6Regular";
        }
    }

    private void SetExpirationDate()
    {
        ExpirationDateLabel.Text = ExpirationDate.ToString("MM/yy",
            CultureInfo.InvariantCulture);
    }

    private void SetCardValidationCode()
    {
        CardValidationCodeLabel.Text = CardValidationCode;
    }
}