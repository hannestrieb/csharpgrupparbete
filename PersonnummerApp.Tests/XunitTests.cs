using Xunit;

namespace PersonnummerApp.Tests
{
    public class XunitTests
    {
        [Fact]
        public void PersonnummerValidation_InputIsTooLong_ReturnsFalse()
        {
            // given
            string input = "123456789012345";    // personnumret är för långt
            bool expected = false;

            // when
            bool result = Program.PersonnummerValidation(input);

            // then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PersonnummerValidation_InputContainsInvalidCharacters_ReturnsFalse()
        {
            // given
            string input = "123ABC!456?";    // personnumret innehåller bokstäver och andra tecken
            bool expected = false;

            // when
            bool result = Program.PersonnummerValidation(input);

            // then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PersonnummerValidation_InputContainsWhitespace_ReturnsFalse()
        {
            // given
            string input = "1234 5678 90";    // personnumret innehåller mellanslag
            bool expected = false;

            // when
            bool result = Program.PersonnummerValidation(input);

            // then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PersonnummerValidation_InputIsValidPersonnummer_ReturnsTrue()
        {
            // given
            string input = "900101-1239";
                        //  212121-212                  uträkning från wikipedia
                        // 1+8+0+0+1+0+1+2+2+6=21
                        // (10 - (21 % 10)) % 10 = 9
            bool expected = true;

            // when
            bool result = Program.IsValidPersonnummer(input); 

            // then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PersonnummerValidation_InputIsInvalidPersonnummer_ReturnsFalse()
        {
            // given
            string input = "900101-1234";
            bool expected = false;

            // when
            bool result = Program.IsValidPersonnummer(input); 

            // then
            Assert.Equal(expected, result);
        }

        // Kan fylla på med tester om vi lägger till fler metoder eller krav
    }
}