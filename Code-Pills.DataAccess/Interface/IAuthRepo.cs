
namespace Code_Pills.DataAccess.Interface
{
    public interface IAuthRepo
    {
        Task<bool> AddPersonalInformation(string userId, string email);
    }
}
