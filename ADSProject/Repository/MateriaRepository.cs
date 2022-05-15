using ADSProject.Models;
using ADSProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class MateriaRepository : IMateriaRepository
    {
        //private readonly List<MateriaViewModel> lstMaterias;

        private readonly ApplicationDbContext applicationDbContext;

        public MateriaRepository(ApplicationDbContext applicationDbContext)
        {
            /*lstMaterias = new List<MateriaViewModel>
            {
                new MateriaViewModel{ idmateria =1 , nombreMateria = "Analisia de Sistemas"}
            };*/

            this.applicationDbContext = applicationDbContext;
        }

        public int agregarMaterias(MateriaViewModel materiaViewModel)
        {
            try
            {

                /*if(lstMaterias.Count > 0)
                {
                    materiaViewModel.idmateria = lstMaterias.Last().idmateria + 1;
                }
                else
                {
                    materiaViewModel.idmateria = 1;

                }
                lstMaterias.Add(materiaViewModel);
                return materiaViewModel.idmateria;*/

                applicationDbContext.Materias.Add(materiaViewModel);
                applicationDbContext.SaveChanges();

                return materiaViewModel.idmateria;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int actualizarMateria(int idMateria, MateriaViewModel materiaViewModel)
        {
            try
            {
                // lstMaterias[lstMaterias.FindIndex(x => x.idmateria == idMateria)] = materiaViewModel;

                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idmateria == idMateria);

                applicationDbContext.Entry(item).CurrentValues.SetValues(materiaViewModel);

                applicationDbContext.SaveChanges();

                return materiaViewModel.idmateria;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool eliminarMateria(int idMateria)
        {
            try
            {
                //lstMaterias.RemoveAt(lstMaterias.FindIndex(x => x.idmateria == idMateria));

                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idmateria == idMateria);

                //Borrar registro por completo
                /*applicationDbContext.Materias.Remove(item);*/

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

        public MateriaViewModel obtenerMateriaPorID(int idMateria)
        {
            try
            {
                //var item = lstMaterias.Find(x => x.idmateria == idMateria);

                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idmateria == idMateria);

                return item;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MateriaViewModel> obtenerMaterias()
        {
            try
            {
                // Obtener todos las Materias sin filtro
                // return applicationDbContext.Estudiantes.ToList();

                // Obtener todos las Materias con filtro(estado = 1)
                return applicationDbContext.Materias.Where(x => x.estado == true).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
