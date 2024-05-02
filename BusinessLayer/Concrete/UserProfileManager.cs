using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Autor> repouser= new Repository<Autor>();
        Repository<Blog> repouserblog= new Repository<Blog>();
        public List<Autor> GetAuthorByMail(string p)
        {
            return repouser.List(x => x.AutorMail == p);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repouserblog.List(x=>x.AutorId == id);
        }
        public void EditAuthor(Autor p)
        {
            Autor autor = repouser.Find(x => x.AutorId == p.AutorId);
            autor.AutorName = p.AutorName;
            autor.AutorImage = p.AutorImage;
            autor.AutorDescription = p.AutorDescription;
            autor.AutorTitle = p.AutorTitle;
            autor.AutorAboutShort = p.AutorAboutShort;
            autor.AutorMail = p.AutorMail;
            autor.AutorPassword = p.AutorPassword;
            autor.AutorPhoneNumber = p.AutorPhoneNumber;
            repouser.Update(autor);
        }
    }
}
