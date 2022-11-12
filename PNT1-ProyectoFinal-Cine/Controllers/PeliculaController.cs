using PNT1_ProyectoFinal_Cine.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNT1_ProyectoFinal_Cine.Context;
using PNT1_ProyectoFinal_Cine.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace PNT1_ProyectoFinal_Cine.Controllers
{
    public class PeliculaController : Controller
    {
        private IPeliculaRepository _repository;
        private IWebHostEnvironment _environment;
        //private readonly CineDatabaseContext _context;

        public PeliculaController(CineDatabaseContext context, IPeliculaRepository repository, IWebHostEnvironment environment)
        {
            _repository = repository;
            _environment = environment;
            //_context = context;
        }

        // GET: Pelicula
        public IActionResult Index()
        {
            return View(_repository.GetPeliculas());
        }

        // GET: Pelicula/Details/5
        public IActionResult Details(int id)
        {
            var pelicula = _repository.GetPeliculaById(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // GET: Pelicula/Create
        public IActionResult Create()
        {
            PopulatePeliculasDropDownList();
            return View();
        }

        // POST: Pelicula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PeliculaId,titulo")] Pelicula pelicula)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pelicula);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pelicula);
        //}
        public IActionResult CreatePost(Pelicula peliculas)
        {
            if (ModelState.IsValid)
            {
                _repository.CreatePelicula(peliculas);
                return RedirectToAction(nameof(Index));
            }
            PopulatePeliculasDropDownList(peliculas.PeliculaId);
            return View(peliculas);
        }

        // GET: Pelicula/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pelicula = await _context.Peliculas.FindAsync(id);
        //    if (pelicula == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(pelicula);
        //}
        public IActionResult Edit(int id)
        {
            Pelicula pelicula = _repository.GetPeliculaById(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            PopulatePeliculasDropDownList(pelicula.PeliculaId);
            return View(pelicula);
        }
        // POST: Pelicula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PeliculaId,titulo")] Pelicula pelicula)
        //{
        //    if (id != pelicula.PeliculaId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(pelicula);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PeliculaExists(pelicula.PeliculaId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pelicula);
        //}
        public async Task<IActionResult> EditPost(int id)
        {
            var peliculaToUpdate = _repository.GetPeliculaById(id);
            bool isUpdated = await TryUpdateModelAsync<Pelicula>(
                                peliculaToUpdate,
                                "",
                                c => c.PeliculaId,
                                c => c.titulo,
                                c => c.ImageName,
                                c => c.PhotoAvaImg,
                                c => c.PhotoPelicula);
            if (isUpdated)
            {
                _repository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            PopulatePeliculasDropDownList(peliculaToUpdate.PeliculaId);
            return View(peliculaToUpdate);
        }

        // GET: Pelicula/Delete/5
        public IActionResult Delete(int id)
        {
            var pelicula = _repository.GetPeliculaById(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }
        private void PopulatePeliculasDropDownList(int? selectedPelicula = null)
        {
            var bakeries = _repository.PopulatePeliculasDropDownList();
            ViewBag.BakeryID = new SelectList(bakeries.AsNoTracking(), "BakeryId", "BakeryName", selectedPelicula);
        }

        // POST: Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var pelicula = await _context.Peliculas.FindAsync(id);
        //    _context.Peliculas.Remove(pelicula);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeletePelicula(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetImage(int id)
        {
            Pelicula requestedPelicula = _repository.GetPeliculaById(id);
            if (requestedPelicula != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedPelicula.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, requestedPelicula.ImageMimeType);
                }
                else
                {
                    if (requestedPelicula.PhotoPelicula.Length > 0)
                    {
                        return File(requestedPelicula.PhotoPelicula, requestedPelicula.ImageMimeType);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }


    }
}
