using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace stajpro.Areas.Admin.Controllers
{
    public class PanelController
    {
        private readonly IServiceManager _manager;
        public PanelController(IServiceManager manager)
        {
            _manager = manager;
        }       
    }
}