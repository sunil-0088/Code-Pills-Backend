using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Migrations.ApplicationDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Interface
{
    public interface IHomeRepo
    {
        Task<IEnumerable<Feature>> GetAllFeatures();
    }
}
