using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNT1_ProyectoFinal_Cine.Context;
using PNT1_ProyectoFinal_Cine.Models;
using PNT1_ProyectoFinal_Cine.Repositories;
using System.IO;

namespace PNT1_ProyectoFinal_Cine.Controllers
{
    public class PeliculaController : Controller
    {
        private IPeliculaRepository _repository;
        private IWebHostEnvironment _environment;
        private readonly CineDatabaseContext _context;

        public PeliculaController(IPeliculaRepository repository, IWebHostEnvironment environment, CineDatabaseContext context)
        {
            _repository = repository;
            _environment = environment;
            _context = context;
        }

        // GET: Pelicula
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peliculas.ToListAsync());
        }

        // GET: Pelicula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // GET: Pelicula/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pelicula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PeliculaId,titulo")] Pelicula pelicula)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(pelicula);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            if (ModelState.IsValid)
            {
                _repository.CreatePelicula(pelicula);
                return RedirectToAction(nameof(Index));
            }

            return View(pelicula);
        }




        // GET: Pelicula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }

        // POST: Pelicula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PeliculaId,titulo")] Pelicula pelicula)
        {
            if (id != pelicula.PeliculaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelicula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.PeliculaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pelicula);
        }

        // GET: Pelicula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Peliculas
                .FirstOrDefaultAsync(m => m.PeliculaId == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // POST: Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            _context.Peliculas.Remove(pelicula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaExists(int id)
        {
            return _context.Peliculas.Any(e => e.PeliculaId == id);
        }


        public IActionResult GetImage(int id)
        {
            Pelicula requestedPelicula = _repository.GetPeliculaById(id);
            if (requestedPelicula != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\img\\";
                string fullPath = webRootpath + folderPath + requestedPelicula.titulo;
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
                    if (requestedPelicula.PhotoFile.Length > 0)
                    {
                        return File(requestedPelicula.PhotoFile, requestedPelicula.ImageMimeType);
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
