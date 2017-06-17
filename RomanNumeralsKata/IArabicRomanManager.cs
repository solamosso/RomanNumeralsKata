namespace RomanNumeralsKata
{
    public interface IArabicRomanManager
    {
        string ConvertArabicNumberToRomanNumber(int arabicNumber);
        int ConvertRomanNumberToArabicNumber(string romanNumber);
    }
}