using ADSProject.Data;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class ProfesorRepository : IProfesorRepository
    {
        //private readonly List<ProfesoresViewModel> lstProfesores;

        private readonly ApplicationDbContext applicationDbContext;

        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            /* lstProfesores = new List<ProfesoresViewModel>
             {
                 new ProfesoresViewModel{ idProfesor = 1, nombreProfesor = "Juan", apellidoProfesor = "Perez",
                      correoProfesor = "Juan@usonsonate.edu.sv"}
             };*/

            this.applicationDbContext = applicationDbContext;
        }

        public int agregarProfesor(ProfesoresViewModel profesoresViewModel)
        {
            try
            {
                /*if (lstProfesores.Count > 0)
                {
                    profesoresViewModel.idProfesor = lstProfesores.Last().idProfesor + 1;
                }
                else
                {
                    profesoresViewModel.idProfesor = 1;
                }
                lstProfesores.Add(profesoresViewModel);
                return profesoresViewModel.idProfesor;*/

                applicationDbContext.Profesores.Add(profesoresViewModel);
                applicationDbContext.SaveChanges();

                return profesoresViewModel.idProfesor;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int actualizarProfesor(int idProfesor, ProfesoresViewModel profesoresViewModel)
        {
            try
            {
                //lstProfesores[lstProfesores.FindIndex(x => x.idProfesor == idProfesor)] = profesoresViewModel;


                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);

                applicationDbContext.Entry(item).CurrentValues.SetValues(profesoresViewModel);

                applicationDbContext.SaveChanges();
                
                return profesoresViewModel.idProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool eliminarProfesor(int idProfesor)
        {
            try
            {
                //lstProfesores.RemoveAt(lstProfesores.FindIndex(x => x.idProfesor == idProfesor));

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);

                //Borrar registro por completo
                /*applicationDbContext.Profesores.Remove(item);*/

                item.estado = false;

                applicationDbContext.Attach(item);

                applicationDbContext.Entry(item).Property(x => x.estado).IsModified = true;

                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ProfesoresViewModel obtenerProfesorPorID(int idProfesor)
        {
            try
            {
                // var item = lstProfesores.Find(x => x.idProfesor == idProfesor);

                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.idProfesor == idProfesor);

                return item;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ProfesoresViewModel> obtenerProfesores()
        {
            {
                try
                {
                    // Obtener todos los Profesores sin filtro
                    // return applicationDbContext.Profesores.ToList();

                    // Obtener todos los estudiantes con filtro(estado = 1)
                    return applicationDbContext.Profesores.Where(x => x.estado == true).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

    }
}
