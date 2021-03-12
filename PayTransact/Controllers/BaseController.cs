using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PayTransact.Persistence.Data.Repositories.Interfaces;

namespace PayTransact.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public BaseController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
    }
}
