namespace RomanNumeralsKata
{
    public class ArabicNumerals
    {
        private readonly IArabicRomanManager _arabicRomanManager;

        public ArabicNumerals(IArabicRomanManager arabicRomanManager)
        {
            _arabicRomanManager = arabicRomanManager;
        }
        public int ConvertToArabic(string romanNumber)
        {
            return _arabicRomanManager.ConvertRomanNumberToArabicNumber(romanNumber);
        }
    }
}
