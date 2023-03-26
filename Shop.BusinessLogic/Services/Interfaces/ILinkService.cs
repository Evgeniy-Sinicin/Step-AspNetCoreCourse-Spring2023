using Shop.BusinessLogic.Models;
using System.Collections.Generic;

namespace Shop.BusinessLogic.Services.Interfaces
{
    public interface ILinkService
    {
        public List<Link> GetAll();
    }
}
