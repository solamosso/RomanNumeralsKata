using System;
using NFluent;
using NUnit.Framework;

namespace RomanNumeralsKata
{
    public class ArabicNumeralsTests
    {
        private ArabicNumerals _arabicNumerals;

        [SetUp]
        public void Setup()
        {
            _arabicNumerals = new ArabicNumerals(new ArabicRomanManager());
        }

        [Test]
        public void should_return_arabic_number_1_when_roman_number_is_1()
        {

            var actual = _arabicNumerals.ConvertToArabic("I");
            Check.That(actual).IsEqualTo(1);
        }

        [Test]
        public void should_return_arbic_number_2_when_roman_number_is_2()
        {
            var actual = _arabicNumerals.ConvertToArabic("II");
            Check.That(actual).IsEqualTo(2);
        }

        [Test]
        public void should_return_arabic_number_3_when_roman_number_is_3()
        {
            var actual = _arabicNumerals.ConvertToArabic("III");
            Check.That(actual).IsEqualTo(3);
        }

        [Test]
        public void should_return_arabic_number_4_when_roman_number_is_4()
        {
            var actual = _arabicNumerals.ConvertToArabic("IV");
            Check.That(actual).IsEqualTo(4);
        }

        [Test]
        public void should_return_arabic_number_6_when_roman_number_is_6()
        {
            var actual = _arabicNumerals.ConvertToArabic("VI");
            Check.That(actual).IsEqualTo(6);
        }

        [TestCase("V", 5)]
        [TestCase("VIII", 8)]
        [TestCase("IX", 9)]
        [TestCase("X", 10)]
        [TestCase("XII", 12)]
        [TestCase("XIV", 14)]
        [TestCase("XVI", 16)]
        [TestCase("L", 50)]
        [TestCase("XC", 90)]
        [TestCase("CXL", 140)]
        [TestCase("CXC", 190)]
        [TestCase("IM", 999)]
        [TestCase("M", 1000)]
        [TestCase("MCXL", 1140)]
        [TestCase("MCL", 1150)]
        public void should_retun_arabic_number_when_input_is_roman_number(string romanNumber, int arabicNumber)
        {
            var computed = _arabicNumerals.ConvertToArabic(romanNumber);
            Check.That(computed).IsEqualTo(arabicNumber);
            Check.That(computed).IsInstanceOf<int>();
            Check.ThatCode(() => _arabicNumerals.ConvertToArabic(romanNumber)).LastsLessThan(1, TimeUnit.Milliseconds);
        }

        [TestCase("MSX", "The roman number MSX contains invalid roman character 'S'")]
        [TestCase("MLW", "The roman number MLW contains invalid roman character 'W'")]
        public void should_return_return_exception_when_invalid_input(string romanNumber, string exceptionMassage)
        {
            Check.ThatCode(() => _arabicNumerals.ConvertToArabic(romanNumber)).Throws<Exception>().WithMessage(exceptionMassage);
            Check.ThatCode(() => _arabicNumerals.ConvertToArabic(romanNumber)).LastsLessThan(1, TimeUnit.Milliseconds);
        }
    }

}
