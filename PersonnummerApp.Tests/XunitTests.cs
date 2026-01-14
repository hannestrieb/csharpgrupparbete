using xunit;

namespace PersonnummerApp.Tests
{
    public class XunitTests
    {
        [Fact]
        public void InputIsValidPersonnummer_ReturnsTrue()
        {
            // given
            string input = "900101-1239";
                          //212121-212                  uträkning från wikipedia
                        // 1+8+0+0+1+0+1+2+2+6=21
                        // (10 - (21 % 10)) % 10 = 9
            bool expected = true;

            // when
            bool result = PersonnummerApp.IsValidPersonnummer(input); 

            // then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void InputIsInvalidPersonnummer_ReturnsFalse()
        {
            // given
            string input = "900101-1234";
            bool expected = false;

            // when
            bool result = PersonnummerApp.IsValidPersonnummer(input); 

            // then
            Assert.Equal(expected, result);
        }

        // Ska fylla på med tester när metoderna är klara
    }
}