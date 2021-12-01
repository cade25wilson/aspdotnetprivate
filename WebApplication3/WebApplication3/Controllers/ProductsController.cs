using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductsController : Controller
    {
        private readonly WebApplication3Context _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(WebApplication3Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Color,Price,Category,Brand,ShippingMethod,ShippingPrice,SellEndDate,PosterName,ImageFile,ImageFile2,ImageFile3,ImageFile4,ImageFile5,ImageFile6,ImageFile7,ImageFile8,ImageFile9,ImageFile10")] Product product)
        {
            if (ModelState.IsValid && product.ImageFile != null)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string fileName2 = Path.GetFileNameWithoutExtension(product.ImageFile2.FileName);
                string fileName3 = Path.GetFileNameWithoutExtension(product.ImageFile3.FileName);
                string fileName4 = Path.GetFileNameWithoutExtension(product.ImageFile4.FileName);
                string fileName5 = Path.GetFileNameWithoutExtension(product.ImageFile5.FileName);
                string fileName6 = Path.GetFileNameWithoutExtension(product.ImageFile6.FileName);
                string fileName7 = Path.GetFileNameWithoutExtension(product.ImageFile7.FileName);
                string fileName8 = Path.GetFileNameWithoutExtension(product.ImageFile8.FileName);
                string fileName9 = Path.GetFileNameWithoutExtension(product.ImageFile9.FileName);
                string fileName10 = Path.GetFileNameWithoutExtension(product.ImageFile10.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                string extension2 = Path.GetExtension(product.ImageFile2.FileName);
                string extension3 = Path.GetExtension(product.ImageFile3.FileName);
                string extension4 = Path.GetExtension(product.ImageFile4.FileName);
                string extension5 = Path.GetExtension(product.ImageFile5.FileName);
                string extension6 = Path.GetExtension(product.ImageFile6.FileName);
                string extension7 = Path.GetExtension(product.ImageFile7.FileName);
                string extension8 = Path.GetExtension(product.ImageFile8.FileName);
                string extension9 = Path.GetExtension(product.ImageFile9.FileName);
                string extension10 = Path.GetExtension(product.ImageFile10.FileName);
                product.Image1 = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                product.Image2 = fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
                product.Image3 = fileName3 = fileName3 + DateTime.Now.ToString("yymmssfff") + extension3;
                product.Image4 = fileName4 = fileName4 + DateTime.Now.ToString("yymmssfff") + extension4;
                product.Image5 = fileName5 = fileName5 + DateTime.Now.ToString("yymmssfff") + extension5;
                product.Image6 = fileName6 = fileName6 + DateTime.Now.ToString("yymmssfff") + extension6;
                product.Image7 = fileName7 = fileName7 + DateTime.Now.ToString("yymmssfff") + extension7;
                product.Image8 = fileName8 = fileName8 + DateTime.Now.ToString("yymmssfff") + extension8;
                product.Image9 = fileName9 = fileName9 + DateTime.Now.ToString("yymmssfff") + extension9;
                product.Image10 = fileName10 = fileName10 + DateTime.Now.ToString("yymmssfff") + extension10;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                string path2 = Path.Combine(wwwRootPath + "/Image/", fileName2);
                string path3 = Path.Combine(wwwRootPath + "/Image/", fileName3);
                string path4 = Path.Combine(wwwRootPath + "/Image/", fileName4);
                string path5 = Path.Combine(wwwRootPath + "/Image/", fileName5);
                string path6 = Path.Combine(wwwRootPath + "/Image/", fileName6);
                string path7 = Path.Combine(wwwRootPath + "/Image/", fileName7);
                string path8 = Path.Combine(wwwRootPath + "/Image/", fileName8);
                string path9 = Path.Combine(wwwRootPath + "/Image/", fileName9);
                string path10 = Path.Combine(wwwRootPath + "/Image/", fileName10);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path2, FileMode.Create))
                {
                    await product.ImageFile2.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path3, FileMode.Create))
                {
                    await product.ImageFile3.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path4, FileMode.Create))
                {
                    await product.ImageFile4.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path5, FileMode.Create))
                {
                    await product.ImageFile5.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path6, FileMode.Create))
                {
                    await product.ImageFile6.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path7, FileMode.Create))
                {
                    await product.ImageFile7.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path8, FileMode.Create))
                {
                    await product.ImageFile8.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path9, FileMode.Create))
                {
                    await product.ImageFile9.CopyToAsync(fileStream);
                }
                using (var fileStream = new FileStream(path10, FileMode.Create))
                {
                    await product.ImageFile10.CopyToAsync(fileStream);
                }
                // Insert record
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else if (ModelState.IsValid && product.ImageFile == null && product.ImageFile2 == null && product.ImageFile3 == null && product.ImageFile4 == null && product.ImageFile5 == null && product.ImageFile6 == null && product.ImageFile7 == null && product.ImageFile8 == null && product.ImageFile9 == null && product.ImageFile10 == null)
            {
                // Insert record
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Color,Price,Category,Brand,ShippingMethod,ShippingPrice,SellEndDate,PosterName,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Image9,Image10")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id, string poster)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);

            // delete image from wwwroot/image
            var imagePath = Path.Join(_hostEnvironment.WebRootPath, "image", product.Image1);
            var imagePath2 = Path.Join(_hostEnvironment.WebRootPath, "image", product.Image2);
            var imagePath3 = Path.Join(_hostEnvironment.WebRootPath, "image", product.Image3);
            var imagePath4 = Path.Join(_hostEnvironment.WebRootPath, "image", product.Image4);
            var imagePath5 = Path.Join(_hostEnvironment.WebRootPath, "image", product.Image5);
            var imagePath6 = Path.Join(_hostEnvironment.WebRootPath, "image", product.Image6);
            var imagePath7 = Path.Join(_hostEnvironment.WebRootPath, "image", product.Image7);
            var imagePath8 = Path.Join(_hostEnvironment.WebRootPath, "image", product.Image8);
            var imagePath9 = Path.Join(_hostEnvironment.WebRootPath, "image", product.Image9);
            var imagePath10 = Path.Join(_hostEnvironment.WebRootPath, "image", product.Image10);

            string[] imagePaths = { imagePath, imagePath2, imagePath3, imagePath4, imagePath5, imagePath6, imagePath7, imagePath8, imagePath9, imagePath10 };
            foreach (var p in imagePaths)
            {
                if (System.IO.File.Exists(p))
                {
                    System.IO.File.Delete(p);
                }
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
        
    }
}
