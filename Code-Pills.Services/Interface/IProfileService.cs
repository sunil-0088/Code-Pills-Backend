using Code_Pills.DataAccess.Models;
using Code_Pills.Services.DTOs;


namespace Code_Pills.Services.Interface
{
    public interface IProfileService
    {
        Task<string> SaveProfile(ProfileDTO profile);
        Task<ProfileDTO?> GetProfile();
        Task<string> SavePerformance(PerformanceDTO performance);
        Task<string> EditPerformance(PerformanceDTO performance);
        Task<bool> IsUserNameTaken(string userName);
        Task<IEnumerable<GlobalRank>> GetGlobalRanks();
        Task<PerformanceDTO> GetProfileStats();
        Task<UserReport> GetUserReport();
        Task<double> CalculateRating(double accuracy, int attempts, int solvedQuestions, int incompleteQuestions, int creditsCount, int contestPerformance);
    }
}
