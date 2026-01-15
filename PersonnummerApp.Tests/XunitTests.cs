using Xunit;

namespace PersonnummerApp.Tests
{
    public class XunitTests
    {
        // Först 5 tester med olika ogilitga personnummer
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
        public void PersonnummerValidation_DateIsInvalid_ReturnsFalse()
        {
            // given
            string input = "999999-1234";    // datumet är ogiltigt
            bool expected = false;

            // when
            bool result = Program.PersonnummerValidation(input);

            // then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PersonnummerValidation_InputIsInvalidPersonnummer_ReturnsFalse()
        {
            // given
            string input = "900101-1234";       // kontrollsiffran 4 är ogiltig enligt uträkning (wikipedia)
            bool expected = false;

            // when
            bool result = Program.IsValidPersonnummer(input); 

            // then
            Assert.Equal(expected, result);
        }

        // Sist 1 test med ett giltigt personnummer
        [Fact]
        public void PersonnummerValidation_InputIsValidPersonnummer_ReturnsTrue()
        {
            // given
            string input = "900101-1239";       // kontrollsiffran 9 är korrekt enligt uträkning (wikipedia)
            bool expected = true;

            // when
            bool result = Program.IsValidPersonnummer(input); 

            // then
            Assert.Equal(expected, result);
        }
    }
}