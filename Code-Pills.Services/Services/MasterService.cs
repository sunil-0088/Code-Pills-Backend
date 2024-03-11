
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;

namespace Code_Pills.Services.Services
{
    public class MasterService : IMasterService
    {
        private readonly IMasterRepo _masterRepo;

        public MasterService(IMasterRepo masterRepo)
        {
            _masterRepo = masterRepo;
        }
       public async Task<List<LanguageDTO>> GetLanguages()
        {
            List<Language> languages = await _masterRepo.GetLanguages();
            List<LanguageDTO> languageDTOs = new();

            foreach(var language in languages)
            {
                LanguageDTO languageDTO = new()
                {
                    LanguageId = language.LanguageId,
                    Name = language.Name,
                    Value = language.Value,

                };
                languageDTOs.Add(languageDTO);
            }
            return languageDTOs;
        }

      public async  Task<List<TagDTO>> GetTags()
        {
            List<Tag> tags = await _masterRepo.GetTags();
            List<TagDTO> tagDTOs = new();

            foreach (var tag in tags)
            {
                TagDTO tagDTO = new()
                {
                    Id = tag.Id,
                    IsCompany = tag.IsCompany,
                    TagName=tag.TagName,

                };
                tagDTOs.Add(tagDTO);
            }
            return tagDTOs;
        }
    }
}
