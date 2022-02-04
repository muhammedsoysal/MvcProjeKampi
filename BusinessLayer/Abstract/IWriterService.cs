using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        Writer WriterAdd(Writer writer);
        Writer WriterDelete(Writer writer);
        Writer WriterUpdate(Writer writer);
        Writer GetByID(int id); 
    }
}
