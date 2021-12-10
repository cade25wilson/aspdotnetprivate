using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Products
        public async Task<IActionResult> UserIndex()
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
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Color,Price,Category,Brand,ShippingMethod,ShippingPrice,SellEndDate,PosterName,Image1,ImageFile,Image2,ImageFile2,Image3,ImageFile3,Image4,ImageFile4,Image5,ImageFile5,Image6,ImageFile6,Image7,ImageFile7,Image8,ImageFile8,Image9,ImageFile9,Image10,ImageFile10")] Product product)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (ModelState.IsValid && product.ImageFile != null)
            {
                //Save image to wwwroot/image
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                product.Image1 = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }
            }

            if (ModelState.IsValid && product.ImageFile2 != null)
            {
                //Save image to wwwroot/image
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile2.FileName);
                string extension = Path.GetExtension(product.ImageFile2.FileName);
                product.Image2 = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile2.CopyToAsync(fileStream);
                }
            }
            if (ModelState.IsValid && product.ImageFile3 != null)
            {
                //Save image to wwwroot/image
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile3.FileName);
                string extension = Path.GetExtension(product.ImageFile3.FileName);
                product.Image3 = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile3.CopyToAsync(fileStream);
                }
            }
            if (ModelState.IsValid && product.ImageFile4 != null)
            {
                //Save image to wwwroot/image
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile4.FileName);
                string extension = Path.GetExtension(product.ImageFile4.FileName);
                product.Image4 = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile4.CopyToAsync(fileStream);
                }
            }
            if (ModelState.IsValid && product.ImageFile5 != null)
            {
                //Save image to wwwroot/image
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile5.FileName);
                string extension = Path.GetExtension(product.ImageFile5.FileName);
                product.Image5 = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile5.CopyToAsync(fileStream);
                }
            }
            if (ModelState.IsValid && product.ImageFile6 != null)
            {
                //Save image to wwwroot/image
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile6.FileName);
                string extension = Path.GetExtension(product.ImageFile6.FileName);
                product.Image6 = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile6.CopyToAsync(fileStream);
                }
            }
            if (ModelState.IsValid && product.ImageFile7 != null)
            {
                //Save image to wwwroot/image
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile7.FileName);
                string extension = Path.GetExtension(product.ImageFile7.FileName);
                product.Image7 = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile7.CopyToAsync(fileStream);
                }
            }
            if (ModelState.IsValid && product.ImageFile8 != null)
            {
                //Save image to wwwroot/image
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile8.FileName);
                string extension = Path.GetExtension(product.ImageFile8.FileName);
                product.Image8 = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile8.CopyToAsync(fileStream);
                }
            }
            if (ModelState.IsValid && product.ImageFile9 != null)
            {
                //Save image to wwwroot/image
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile9.FileName);
                string extension = Path.GetExtension(product.ImageFile9.FileName);
                product.Image9 = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile9.CopyToAsync(fileStream);
                }
            }
            if (ModelState.IsValid && product.ImageFile10 != null)
            {
                //Save image to wwwroot/image
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile10.FileName);
                string extension = Path.GetExtension(product.ImageFile10.FileName);
                product.Image10 = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile10.CopyToAsync(fileStream);
                }
            }

            // Insert record
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);
            var poster = product.PosterName;
            string strPoster = poster.ToString();

            while (User.Identity.Name != strPoster)
            {
                return NotFound();
            }
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
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            var poster = product.PosterName;
            string strPoster = poster.ToString();

            while (User.Identity.Name != strPoster)
            {
                return NotFound();
            }
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
             
            // creating an array for array
            string[] imagePaths = { imagePath, imagePath2, imagePath3, imagePath4, imagePath5, imagePath6, imagePath7, imagePath8, imagePath9, imagePath10 };
            foreach (var p in imagePaths)
            {
                if(System.IO.File.Exists(p) && p != Path.Join(_hostEnvironment.WebRootPath, "image", "blankimage.jpg"))
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
