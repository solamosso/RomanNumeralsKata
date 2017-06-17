using System;

namespace RomanNumeralsKata
{
    public class RomanNumerals
    {
        private readonly IArabicRomanManager _arabicRomanManager;

        public RomanNumerals(IArabicRomanManager arabicRomanManager)
        {
            _arabicRomanManager = arabicRomanManager;
        }
        public string ConvertToRoman(int arabicNumber)
        {
            if (arabicNumber <= 0 || arabicNumber > 3000)
                throw new Exception("Arabic nnumber must be greater than 0 and less than 3000");
            return _arabicRomanManager.ConvertArabicNumberToRomanNumber(arabicNumber);
        }
    }
}
