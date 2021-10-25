using MiniRater.BL.Dto;
using System.Threading.Tasks;

namespace MiniRater.BL
{
    public interface IRateService
    {
        Task<PremiumResponseDto> GetTotalPremium(PremiumRequestDto premiumRequestDto);
    }
}
