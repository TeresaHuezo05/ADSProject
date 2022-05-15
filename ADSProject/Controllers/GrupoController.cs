using ADSProject.Utils;
using ADSProject.Models;
using ADSProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Controllers
{
    public class GrupoController : Controller
    {
        private readonly IGrupoRepository grupoRepository;

        public GrupoController(IGrupoRepository grupoRepository)
        {
            this.grupoRepository = grupoRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = grupoRepository.obtenerGrupos();

                return View(item);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Form(int? idGrupo, Operaciones operaciones)
        {
            try
            {
                var Grupo = new GruposViewModel();

                if (idGrupo.HasValue)
                {
                    Grupo = grupoRepository.obtenerGruposPorID(idGrupo.Value);
                }
                // Indica el tipo de operacion que es esta realizando
                ViewData["Operaciones"] = operaciones;

                return View(Grupo);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(GruposViewModel gruposViewModel)
        {
            try
            {
                if (gruposViewModel.idGrupo == 0) // En caso de insertar
                {
                    grupoRepository.agregarGrupo(gruposViewModel);
                }
                else // En caso de actualizar
                {
                    grupoRepository.actualizarGrupo
                        (gruposViewModel.idGrupo, gruposViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(int idGrupo)
        {
            try
            {
                grupoRepository.eliminarGrupo(idGrupo);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
