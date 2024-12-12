using Microsoft.AspNetCore.Mvc;
using TangoRoom.Server.models;

namespace TangoRoom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet(Name = "Inscription")]
        public IEnumerable<Inscription> getAllInscription()
        {
            List<Inscription> lists = new List<Inscription>();
            return lists;
        }
    }
}
