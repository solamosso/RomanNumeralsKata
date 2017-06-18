using System;
using NFluent;
using NUnit.Framework;

namespace RomanNumeralsKata
{
    public class RomanNumeralsTests
    {
        private RomanNumerals _romanNumerals;

        [SetUp]
        public void Setup()
        {
            _romanNumerals = new RomanNumerals(new ArabicRomanManager());
        }
        [Test]
        public void should_return_roman_number_1_when_arabic_number_is_1()
        {
            Check.That(_romanNumerals.ConvertToRoman(1)).IsEqualTo("I");
        }

        [Test]
        public void should_return_roman_number_2_when_arabic_number_is_2()
        {
            var actual = _romanNumerals.ConvertToRoman(2);
            Check.That(actual).IsEqualTo("II");
        }

        [Test]
        public void should_return_roman_number_3_when_arabic_number_is_3()
        {
            Check.That(_romanNumerals.ConvertToRoman(3)).IsEqualTo("III");
        }

        [Test]
        public void should_return_roman_number_4_when_arabic_number_is_4()
        {
            Check.That(_romanNumerals.ConvertToRoman(4)).IsEqualTo("IV");
        }

        [Test]
        public void should_return_roman_number_5_when_arabic_number_is_5()
        {
            Check.That(_romanNumerals.ConvertToRoman(5)).IsEqualTo("V");
        }

        [Test]
        public void should_return_roman_number_6_when_arabic_number_is_6()
        {
            Check.That(_romanNumerals.ConvertToRoman(6)).IsEqualTo("VI");
        }

        [Test]
        public void should_return_roman_number_8_when_arabic_number_is_8()
        {
            var computed = _romanNumerals.ConvertToRoman(8);
            Check.That(computed).IsEqualTo("VIII");
        }

        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(30, "XXX")]
        [TestCase(40, "XL")]
        [TestCase(55, "LV")]
        [TestCase(90, "XC")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(599, "DLXXXXVIIII")]
        [TestCase(900, "CM")]
        [TestCase(990, "XM")]
        [TestCase(999, "IM")]
        [TestCase(3000, "MMM")]
        public void should_return_roman_number_when_input_is_arabic_number(int arabicNumber, string romanNumber)
        {
            var computed = _romanNumerals.ConvertToRoman(arabicNumber);
            Check.That(computed).IsEqualTo(romanNumber);
            Check.That(computed).IsInstanceOf<string>();
            Check.ThatCode(() => _romanNumerals.ConvertToRoman(arabicNumber)).LastsLessThan(1, TimeUnit.Milliseconds);
        }

        [TestCase(3500, "Arabic nnumber must be greater than 0 and less than 3000")]
        [TestCase(-1, "Arabic nnumber must be greater than 0 and less than 3000")]
        public void should_return_exception_when_input_is_arabic_number_is_inferior_to_0_or_superior_to_3000(int arabicNumber, string expected)
        {
            Check.ThatCode(() => _romanNumerals.ConvertToRoman(arabicNumber)).Throws<Exception>().WithMessage(expected);
            Check.ThatCode(() => _romanNumerals.ConvertToRoman(arabicNumber)).LastsLessThan(1, TimeUnit.Milliseconds);
        }
    }
}
