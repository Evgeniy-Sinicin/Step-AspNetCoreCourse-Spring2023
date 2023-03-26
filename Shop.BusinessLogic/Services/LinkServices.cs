using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Models;
using Shop.BusinessLogic.Services.Interfaces;
using System.Collections.Generic;

namespace Shop.BusinessLogic.Services
{
    public class LinkServices : ILinkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILinkRepository _linkRepository;

        public LinkServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _linkRepository = unitOfWork.LinkRepository;
        }

        public List<Link> GetAll()
        {
            return _linkRepository.GetAll();
        }
    }
}
