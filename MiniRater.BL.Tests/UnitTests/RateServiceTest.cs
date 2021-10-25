using MiniRater.BL.Dto;
using Xunit;

namespace MiniRater.BL.Tests.UnitTests
{
    public class RateServiceTest
    {
        [Theory]
        [InlineData(6000000, "TX", "Plumber", 11316)]
        public async void Test(double revenue, string stateCd, string business, double expectedPremium)
        {
            RateService _rateService = new RateService();

            // Arrange
            PremiumRequestDto premiumRequestDto = new PremiumRequestDto
            {
                Revenue = revenue,
                State = stateCd,
                Business = business
            };

            PremiumResponseDto expected = new PremiumResponseDto
            {
                Premium = expectedPremium
            };

            // Act
            PremiumResponseDto actual = await _rateService.GetTotalPremium(premiumRequestDto);

            // Assert
            Assert.IsType<PremiumResponseDto>(actual);
            Assert.Equal(expected.Premium, actual.Premium);
        }
    }
}
