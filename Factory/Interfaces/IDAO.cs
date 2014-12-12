using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tables;

namespace Factory.Interfaces
{
    public interface IDAO
    {
        void Add(BaseEntity entity);
        void Update(BaseEntity entity);
        void Remove(int Id);
        void Remove(BaseEntity entity);
        List<BaseEntity> GetList(); 
    }
}
