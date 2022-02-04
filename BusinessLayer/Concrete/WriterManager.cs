using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        public Writer GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public Writer WriterAdd(Writer writer)
        {
            throw new NotImplementedException();
        }

        public Writer WriterDelete(Writer writer)
        {
            throw new NotImplementedException();
        }

        public Writer WriterUpdate(Writer writer)
        {
            throw new NotImplementedException();
        }
    }
}
