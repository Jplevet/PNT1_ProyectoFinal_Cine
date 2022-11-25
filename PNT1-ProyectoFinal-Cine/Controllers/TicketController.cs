using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PNT1_ProyectoFinal_Cine.Context;
using PNT1_ProyectoFinal_Cine.Models;

namespace PNT1_ProyectoFinal_Cine.Controllers
{
    public class TicketController : Controller
    {
        private readonly CineDatabaseContext _context;
        //private readonly CineDatabaseContext context2;

        public TicketController(CineDatabaseContext context)
        {
            _context = context;
            //context2 = context2;
        }

        // GET: Ticket
        public async Task<IActionResult> Index()
        {
            var cineDatabaseContext = _context.Ticket.Include(t => t.Pelicula).Include(t => t.usuario);
            return View(await cineDatabaseContext.ToListAsync());
        }

        // GET: Ticket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.Pelicula)
                .Include(t => t.usuario)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Ticket/Create
        public IActionResult Create()
        {
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "PeliculaId", "titulo");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Contrasenia");
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,asiento,fecha,PeliculaId,UsuarioId,sala")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "PeliculaId", "titulo", ticket.PeliculaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Contrasenia", ticket.UsuarioId);
            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "PeliculaId", "titulo", ticket.PeliculaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Contrasenia", ticket.UsuarioId);
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,asiento,fecha,PeliculaId,UsuarioId,sala")] Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketId))
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
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "PeliculaId", "titulo", ticket.PeliculaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Contrasenia", ticket.UsuarioId);
            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.Pelicula)
                .Include(t => t.usuario)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.TicketId == id);
        }

        private void PopulatePeliculasDropDownList()
        {
            var pelis = _context.Peliculas;
            ViewBag.PeliculaID = new SelectList(pelis.AsNoTracking(), "PeliculaId", "titulo");
        }


        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var tickets = from m in context2.Tickets
        //                 select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        tickets = tickets.Where(s => s.usuario.NombreUsuario!.Contains(searchString));
        //    }

        //    return View(await tickets.ToListAsync());
        //}

        //public ActionResult ReservasDeHoy()
        //{
        //    List<Ticket> reservas = (from t in context2.Tickets
        //                          where t.fecha == DateTime.Today
        //                          select t).ToList();
        //    return View("Index", reservas);
        //}



        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var tickets = from m in _context.Tickets
        //                  select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        tickets = tickets.Where(s => s.usuario.NombreUsuario!.Contains(searchString));
        //    }

        //    return View(await tickets.ToListAsync());
        //}

        public ActionResult ReservasDeHoy()
        {
            List<Ticket> reservas = (from t in _context.Tickets
                                     where t.fecha == DateTime.Today
                                     select t).ToList();
            return View("Index", reservas);
        }

    }
}
