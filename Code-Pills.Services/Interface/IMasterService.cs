using Code_Pills.DataAccess.EntityModels;
using Code_Pills.Services.DTOs;

namespace Code_Pills.Services.Interface
{
    public interface IMasterService
    {
        Task<List<LanguageDTO>> GetLanguages();
        Task<List<TagDTO>> GetTags();
    }
}
