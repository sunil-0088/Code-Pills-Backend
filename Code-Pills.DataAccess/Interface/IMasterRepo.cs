using Code_Pills.DataAccess.EntityModels;

namespace Code_Pills.DataAccess.Interface
{
    public interface IMasterRepo
    {
       Task<List<Language>> GetLanguages();
       Task<List<Tag>> GetTags();


    }
}
