using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager:IAuthorService
    {
        IAutorDal _autordal;
        Repository<Autor> repoauthor=new Repository<Autor>() ;

        public AuthorManager(IAutorDal autordal)
        {
            _autordal = autordal;
        }
        public List<Autor> GetList()
        {
            return _autordal.List();
        }


        public Autor GetById(int id)
        {
            return _autordal.GetById(id);
        }

        public void AuthorDelete(Autor autor)
        {
            throw new NotImplementedException();
        }
        public void TAdd(Autor t)
        {
            _autordal.Insert(t);
        }

        public void TDelete(Autor t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Autor t)
        {
            _autordal.Update(t);
        }
    }
}
