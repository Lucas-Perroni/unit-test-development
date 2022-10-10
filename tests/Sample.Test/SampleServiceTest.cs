using Sample.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace Sample.Test
{

    public class SampleServiceTest
    {
        private readonly SampleService _sampleService;

        public SampleServiceTest()
        {
            //arrange (qualquer tipo de variavel necessaria para montar o teste)
            _sampleService = new SampleService();
        }

        [Fact]
        public void IsSum_Values ()
        {
            //arrange
            var value1 = 5;
            var value2 = 5;
            var value3 = 5;
            var total = 15;

            var result1 = 30;

            //act
            var result = _sampleService.Sum(total, value1, value2, value3);

            //assert
            Assert.Equal(result1, result);
        }
        //-------------------------------------------------------------------------------
        [Theory]
        [InlineData(-3)]
        [InlineData(-1)]
        [InlineData(1)]
        public void IsEven_ValuesLessThan2_ReturnFalse(int value)
        {
            //act (ação =  chamda do metodo a ser testado, logo a unidade)
            var result = _sampleService.IsEven(value);


            //assert (o cenário proposto no resultado do teste)
            Assert.False(result);
        }

        [Theory]
        [InlineData(-4)]
        [InlineData(-2)]
        [InlineData(0)]
        [InlineData(2)]
        public void IsEven_ValuesLessThan2_ReturnTrue(int value)
        {
            //act (ação =  chamda do metodo a ser testado, logo a unidade)
            var result = _sampleService.IsEven(value);


            //assert (o cenário proposto no resultado do teste)
            Assert.True(result);
        }
        //-------------------------------------------------------------------------------
        [Theory]
        [InlineData(-4)]
        [InlineData(-2)]
        [InlineData(0)]
        [InlineData(2)]
        public void IsOdd_ValuesLessThan2_ReturnFalse(int value)
        {
            //act (ação =  chamda do metodo a ser testado, logo a unidade)
            var result = _sampleService.IsOdd(value);


            //assert (o cenário proposto no resultado do teste)
            Assert.False(result);
        }

        [Theory]
        [InlineData(-3)]
        [InlineData(-1)]
        [InlineData(1)]
        public void IsOdd_ValuesLessThan2_ReturnTrue(int value)
        {
            //act (ação =  chamda do metodo a ser testado, logo a unidade)
            var result = _sampleService.IsOdd(value);


            //assert (o cenário proposto no resultado do teste)
            Assert.True(result);
        }
       // --------------------------------------------------------------------------------

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var result = _sampleService.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void IsPrime_PrimesLessThan10_ReturnTrue(int value)
        {
            var result = _sampleService.IsPrime(value);

            Assert.True(result, $"{value} should be prime");
        }

        //---------------------------------------------------------------------------
        [Fact]
        public void IsMailValid_ReturnTrue()
        {
            //arrange
            var mail = "lucasperroni@gmail.com";

            //act
            var result = mail.IsValidMail();

            //assert 
            Assert.True(result); 
        }

        [Fact]
        public void IsMailValid_ReturnFalse()
        {
            //arrange
            var mail = "@lucasperroni@gmail.com";

            //act
            var result = mail.IsValidMail();

            //assert 
            Assert.False(result);
        }
       // ---------------------------------------------------------------------------------------------

        [Fact]
        public void IsDateValid_ReturnTrue()
        {
            var date = DateTime.Now;

            var result = date.ToStringShortPtBR();

            Regex validateDateRegex = new Regex("^[0-9]{1,2}\\/[0-9]{1,2}\\/[0-9]{4}$");
            Match match = validateDateRegex.Match(result);

              Assert.True(match.Success);
           //   Assert.Throws(match.Success);
        }

        //---------------------------------------------------------------------------------------
        [Theory]
        [InlineData(45258421.050)]
        [InlineData(45.455)]
        [InlineData(10000.45)]
        [InlineData(4.5)]
        public void IsToStringMoneyPtBR_True(decimal value)
        {
            //var money = "100000";

            var result = value.ToString().ToStringMoneyPtBR() ;

            Assert.True(result);
        }

        [Fact]
        public void IsToStringMoneyPtBR_False() 
        {
            var money = "100000000000000000000000000000000000000000000000000000000.45";

            Assert.Throws<OverflowException>(()=> money.ToStringMoneyPtBR());
            //esse assert.throws é usado para fazer um teste onde você está esperando um erro já
        }
    }
}
