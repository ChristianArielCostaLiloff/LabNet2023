using Practica3_EF.Entities.BaseApi;
using Practica3_EF.Entities.Dtos;
using Practica3_EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Practica7.WebAPI.Controllers
{
    public class DigimonController : Controller
    {
        // GET: Digimon
        DigimonLogic logic = new DigimonLogic();

        // GET: Digimon
        public async Task<ActionResult> Index()
        {
            List<Digimon> digimonApi = await logic.GetAll();

            List<DtoDigimon> digimonDtos =
                digimonApi.Select(digimon => new DtoDigimon{
                    Name = digimon.Name,
                    Level = digimon.Level,
                    Image = digimon.Img
                }).ToList();

            return View(digimonDtos);

        }
    }
}