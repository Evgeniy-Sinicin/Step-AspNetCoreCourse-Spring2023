using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace Shop.DataAccess.Json.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly List<Link> _links;

        public LinkRepository(List<Link> links)
        {
            _links = links;
        }

        public Link Create(Link link)
        {
            _links.Add(link);

            return link;
        }

        public List<Link> GetAll()
        {
            return _links;
        }
    }
}
