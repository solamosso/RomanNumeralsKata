using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralsKata
{
    public class ArabicRomanManager : IArabicRomanManager
    {
        public Dictionary<string, int> Symbols = new Dictionary<string, int>
        {
            ["M"] = 1000,
            ["D"] = 500,
            ["C"] = 100,
            ["L"] = 50,
            ["X"] = 10,
            ["V"] = 5,
            ["I"] = 1
        };

        public string ConvertArabicNumberToRomanNumber(int arabicNumber)
        {
            if (should_use_simple_method(arabicNumber))
                return ConvertArabicNumberToRomanNumberSimpleMethod(arabicNumber);
            return ConvertArabicNumberToRomanNumberComplexMethod(arabicNumber);
        }

        public int ConvertRomanNumberToArabicNumber(string romanNumber)
        {
            int arabicNumber = 0;
            int latestValue = 0;

            for (int i = 0; i < romanNumber.Length; i++)
            {
                var c = romanNumber[i];
                var currentValue = 0;
                if (Symbols.ContainsKey(c.ToString()))
                {
                    currentValue = Symbols[c.ToString()];
                }
                else
                {
                    throw new Exception("The roman number " + romanNumber + " contains invalid roman character '" + c + "'");
                }

                if (i == 0)
                {
                    latestValue = currentValue;
                }

                if (currentValue <= latestValue)
                {
                    arabicNumber += currentValue;
                }
                else
                {
                    arabicNumber += (currentValue - 2 * latestValue);
                }
                latestValue = currentValue;
            }
            return arabicNumber;
        }

        #region private methodes
        int? NearestSymbolValueGreaterThanInput(int input)
        {
            var greatersValues = Symbols.Values.OrderBy(x => x).Where(x => x > input);
            var enumerable = greatersValues as int[] ?? greatersValues.ToArray();
            if (!enumerable.Any())
                return null;

            return enumerable.First();
        }
        private string ConvertArabicNumberToRomanNumberSimpleMethod(int arabicNumber)
        {
            string romanNumber = string.Empty;

            foreach (var symbol in Symbols)
            {
                if (arabicNumber <= 0) break;
                while (arabicNumber >= symbol.Value)
                {
                    romanNumber += symbol.Key;
                    arabicNumber -= symbol.Value;
                }
            }
            return romanNumber;
        }

        private string ConvertArabicNumberToRomanNumberComplexMethod(int arabicNumber)
        {
            var greaterValue = NearestSymbolValueGreaterThanInput(arabicNumber);
            if (!greaterValue.HasValue) return string.Empty;
            return ConvertArabicNumberToRomanNumberSimpleMethod(greaterValue.Value - arabicNumber) + ConvertArabicNumberToRomanNumberSimpleMethod(greaterValue.Value);
        }

        bool should_use_simple_method(int arabicNumber)
        {
            if (Symbols.Values.Contains(arabicNumber))
                return true;

            var greaterValue = NearestSymbolValueGreaterThanInput(arabicNumber);
            if (!greaterValue.HasValue)
                return true;

            if (!Symbols.Values.Contains(greaterValue.Value - arabicNumber))
                return true;

            return false;
        }
        #endregion

    }
}
