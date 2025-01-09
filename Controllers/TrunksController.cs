using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CDRMS_Web_Application.Models;
using CDRMS_Web_Application.Data;

namespace CDRMS_Web_Application.Controllers
{
    public class TrunksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrunksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trunks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trunks.ToListAsync());
        }

        // GET: Trunks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trunksModel = await _context.Trunks
                .FirstOrDefaultAsync(m => m.TrunkId == id);
            if (trunksModel == null)
            {
                return NotFound();
            }

            return View(trunksModel);
        }

        // GET: Trunks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trunks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrunkId,DepartId,TrunkCode")] TrunksModel trunksModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trunksModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trunksModel);
        }

        // GET: Trunks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trunksModel = await _context.Trunks.FindAsync(id);
            if (trunksModel == null)
            {
                return NotFound();
            }
            return View(trunksModel);
        }

        // POST: Trunks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrunkId,DepartId,TrunkCode")] TrunksModel trunksModel)
        {
            if (id != trunksModel.TrunkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trunksModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrunksModelExists(trunksModel.TrunkId))
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
            return View(trunksModel);
        }

        // GET: Trunks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trunksModel = await _context.Trunks
                .FirstOrDefaultAsync(m => m.TrunkId == id);
            if (trunksModel == null)
            {
                return NotFound();
            }

            return View(trunksModel);
        }

        // POST: Trunks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trunksModel = await _context.Trunks.FindAsync(id);
            if (trunksModel != null)
            {
                _context.Trunks.Remove(trunksModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrunksModelExists(int id)
        {
            return _context.Trunks.Any(e => e.TrunkId == id);
        }
    }
}
