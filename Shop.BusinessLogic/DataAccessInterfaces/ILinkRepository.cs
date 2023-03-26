using Shop.BusinessLogic.Models;
using System.Collections.Generic;

namespace Shop.BusinessLogic.DataAccessInterfaces
{
    public interface ILinkRepository
    {
        public List<Link> GetAll();

        public Link Create(Link link);
    }
}
