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
    }
}
