using MiniRater.BL.Dto;
using System;
using System.Threading.Tasks;

namespace MiniRater.BL
{
    public class RateService : IRateService
    {
        public async Task<PremiumResponseDto> GetTotalPremium(PremiumRequestDto premiumRequestDto)
        {
            double stateFactor;
            switch (premiumRequestDto.State)
            {
                case "OH":
                    stateFactor = 1;
                    break;
                case "FL":
                    stateFactor = 1.2;
                    break;
                case "TX":
                    stateFactor = 0.943;
                    break;
                default:
                    throw new Exception("Unable to find State Factor for the given State Code provided");
            };

            double businessFactor;
            switch (premiumRequestDto.Business)
            {
                case "Architect":
                    businessFactor = 1;
                    break;
                case "Plumber":
                    businessFactor = 0.5;
                    break;
                case "Programmer":
                    businessFactor = 1.25;
                    break;
                default:
                    throw new Exception("Unable to find Business Factor for the given State Code provided");
            };

            double basePremium = GetBasePremium(premiumRequestDto.Revenue);

            PremiumResponseDto premiumResponseDto = new PremiumResponseDto
            {
                Premium = stateFactor * businessFactor * basePremium * Resources.HazardFactor
            };

            return await Task.FromResult(premiumResponseDto);
        }

        internal double GetBasePremium(double revenue, double basePremiumDiviser = Resources.BasePremiumDiviser)
        {
            return Math.Ceiling(revenue / basePremiumDiviser);
        }
    }
}
