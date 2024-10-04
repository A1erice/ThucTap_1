using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThucTap_1.Data;
using ThucTap_1.Models;
using IronPdf.Extensions.Mvc.Core;

namespace ThucTap_1.Controllers
{
    public class BkKtccsController : Controller
    {
        private readonly HisContext _context;
        private readonly IRazorViewRenderer _viewRenderService;
        public BkKtccsController(HisContext context, IRazorViewRenderer viewRenderService)
        {
            _context = context;
            _viewRenderService = viewRenderService;
        }

        // GET: BkKtccs
        public async Task<IActionResult> Index()
        {
              return _context.BkKtccs != null ? 
                          View(await _context.BkKtccs.ToListAsync()) :
                          Problem("Entity set 'HisContext.BkKtccs'  is null.");
        }

        // GET: BkKtccs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BkKtccs == null)
            {
                return NotFound();
            }

            var bkKtcc = await _context.BkKtccs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bkKtcc == null)
            {
                return NotFound();
            }

            return View(bkKtcc);
        }

        // GET: BkKtccs/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            return View(await _context.BkKtccs.ToListAsync());
        }

        public async Task<IActionResult> Print(int? id)
        {
            if (id == null || _context.BkKtccs == null)
            {
                return NotFound();
            }

            var bkKtcc = await _context.BkKtccs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bkKtcc == null)
            {
                return NotFound();
            }

            ChromePdfRenderer renderer = new ChromePdfRenderer();
            PdfDocument pdf = renderer.RenderRazorViewToPdf(_viewRenderService, "./Views/BkKtccs/Print.cshtml", bkKtcc);
            return File(pdf.BinaryData, "application/pdf", "BKKTCC.pdf");
            //return View(bkKtcc);
        }

        // POST: BkKtccs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NgayKt,NguoiKt,NguoiDuocKt,KhoaKt,SoHs,A11,A12,A13,A21,A22,A23,B3,B4,B5,B6a,B6b,B7,C81,C82,C9,C10,C11,TongDiem,XepLoai,NhanXet")] BkKtcc bkKtcc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bkKtcc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bkKtcc);
        }

        // GET: BkKtccs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BkKtccs == null)
            {
                return NotFound();
            }

            var bkKtcc = await _context.BkKtccs.FindAsync(id);
            if (bkKtcc == null)
            {
                return NotFound();
            }
            return View(bkKtcc);
        }

        // POST: BkKtccs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NgayKt,NguoiKt,NguoiDuocKt,KhoaKt,SoHs,A11,A12,A13,A21,A22,A23,B3,B4,B5,B6a,B6b,B7,C81,C82,C9,C10,C11,TongDiem,XepLoai,NhanXet")] BkKtcc bkKtcc)
        {
            if (id != bkKtcc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bkKtcc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BkKtccExists(bkKtcc.Id))
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
            return View(bkKtcc);
        }

        // GET: BkKtccs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BkKtccs == null)
            {
                return NotFound();
            }

            var bkKtcc = await _context.BkKtccs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bkKtcc == null)
            {
                return NotFound();
            }

            return View(bkKtcc);
        }

        // POST: BkKtccs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BkKtccs == null)
            {
                return Problem("Entity set 'HisContext.BkKtccs'  is null.");
            }
            var bkKtcc = await _context.BkKtccs.FindAsync(id);
            if (bkKtcc != null)
            {
                _context.BkKtccs.Remove(bkKtcc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BkKtccExists(int id)
        {
          return (_context.BkKtccs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
