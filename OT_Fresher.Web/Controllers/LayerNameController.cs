using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OT_Fresher.Core.Entities;
using OT_Fresher.Core.Interfaces.Repository;
using OT_Fresher.Core.Interfaces.Service;
using OT_Fresher.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OT_Fresher.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class LayerNameController:BaseEntityController<LayerName>
    {
        public LayerNameController(IBaseService<LayerName> service, IBaseRepository<LayerName> repository):base(service,repository)
        {

        }
    }
}
