using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;


        public ProductsController(WebApplication3Context context, IWebHostEnvironment hostEnvironment, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }
        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Products
        public async Task<IActionResult> UserIndex(Product product)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // will give the user's userId

            product.PosterId = userId; //getting products posted by signed in user

            if (userId != null)
            {
                return View(await _context.Product.ToListAsync());
            }
            else
            {
                return NotFound();
            }

        }

        [Route("pay")]
        public async Task<dynamic> Pay(Models.Payment pm)
        {
            var databaseAdd = _context.Add(pm);
            await _context.SaveChangesAsync();
            var returnValue = RedirectToAction("Create", "Products");
            return await MakePayment.PayAsync(pm.CardNumber, pm.Month, pm.Year, pm.Cvc, pm.Value, returnValue, databaseAdd);
        }

        public IActionResult Purchase(Models.Payment pm)
        {
            var m = new Payment();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // will give the user's userId
            m.Value = 200;
            if (userId != null)
            {
                return View(m);
            }
            else
            {
                return NotFound();
            }
         }

        public async Task<IActionResult> UserItems(string id)
        {
            var list = await _context.Set<Product>().Where(m => m.PosterId == id).ToArrayAsync();

            return View(list);
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // will give the user's userId
            if (userId == null)
            {
                return NotFound();
            }
            else
            {
                return View();
            }

        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Color,Price,Category,Brand,ShippingMethod,ShippingPrice,SellEndDate,PosterName,Image1,ImageFile,Image2,ImageFile2,Image3,ImageFile3,Image4,ImageFile4,Image5,ImageFile5,Image6,ImageFile6,Image7,ImageFile7,Image8,ImageFile8,Image9,ImageFile9,Image10,ImageFile10")] Product product)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (product.ImageFile != null)
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

            if (product.ImageFile2 != null)
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
            if (product.ImageFile3 != null)
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
            if (product.ImageFile4 != null)
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
            if (product.ImageFile5 != null)
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
            if (product.ImageFile6 != null)
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
            if (product.ImageFile7 != null)
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
            if (product.ImageFile8 != null)
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
            if (product.ImageFile9 != null)
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
            if (product.ImageFile10 != null)
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // will give the user's userId
            product.PosterId = userId;
            


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
            var poster = product.PosterId;
            string strPoster = poster.ToString();
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            while (userName != strPoster)
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
            var posterId = product.PosterId;
            string strPosterId = posterId.ToString();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            while (userId != strPosterId)
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
                if(System.IO.File.Exists(p) && p != Path.Join(_hostEnvironment.WebRootPath, "image", "blankImage.jpg"))
                {
                    System.IO.File.Delete(p);
                }
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UserIndex));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
        
    }
}
