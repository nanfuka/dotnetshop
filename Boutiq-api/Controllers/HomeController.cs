
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoreUploadAndDisplayImage_Demo.Data;
using Boutiq_api.Models;
using Boutiq_api.ViewModels;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MvcCoreUploadAndDisplayImage_Demo.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View("~/Views/Home/Home.cshtml");
        }


        public async Task<IActionResult> Index()
        {
            var employee = await dbContext.Boutiq.ToListAsync();
            return View(employee);
        }
        [Authorize]
        public async Task<IActionResult> GetCurrentStalk()
        {
            var products = dbContext.Boutiq.Where(p => p.status == "inShop");

            return View(products);
        }
        [Authorize]
        public async Task<IActionResult> GetSoldStalk()
        {
            var products = dbContext.Boutiq.Where(p => p.status == "sold");

            return View(products);
        }

                [Authorize]
        public async Task<IActionResult> GetAllTshirtsSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "tshirt" && p.status == "sold");
            return View(products);
        }


                        [Authorize]
        public async Task<IActionResult> GetAllDeposited()
        {
            var products = dbContext.Boutiq.Where(p => p.status == "deposited");
            return View(products);
        }


                [Authorize]
        public async Task<IActionResult> GetAllPantsSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "pants" && p.status == "sold");
            return View(products);
        }

                [Authorize]
        public async Task<IActionResult> GetAllPantsInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "pants" && p.status == "inShop");
            return View(products);
        }


                        [Authorize]
        public async Task<IActionResult> GetAllJeansSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "Jean" && p.status == "sold");
            return View(products);
        }

                [Authorize]
        public async Task<IActionResult> GetAllJeansInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "Jean" && p.status == "inShop");
            return View(products);
        }


                        [Authorize]
        public async Task<IActionResult> GetAllLeggingsSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "leggings" && p.status == "sold");
            return View(products);
        }

        

                [Authorize]
        public async Task<IActionResult> GetAllLeggingsInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "leggings" && p.status == "inShop");
            return View(products);
        }

                        [Authorize]
        public async Task<IActionResult> GetAllTopsSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "top" && p.status == "sold");
            return View(products);
        }

                [Authorize]
        public async Task<IActionResult> GetAllTopsInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "top" && p.status == "inShop");
            return View(products);
        }

                                [Authorize]
        public async Task<IActionResult> GetAllJUmpSuitsSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "jumpsuit" && p.status == "sold");
            return View(products);
        }

                [Authorize]
        public async Task<IActionResult> GetAllJumpSuitsInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "jumpsuit" && p.status == "inShop");
            return View(products);
        }


                                        [Authorize]
        public async Task<IActionResult> GetAllTwoPieceSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "twopiece" && p.status == "sold");
            return View(products);
        }

                [Authorize]
        public async Task<IActionResult> GetAllTwoPieceInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "twopiece" && p.status == "inShop");
            return View(products);
        }

                                [Authorize]
        public async Task<IActionResult> GetAllDressesSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "dress" && p.status == "sold");
            return View(products);
        }

                [Authorize]
        public async Task<IActionResult> GetAllDressesInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "dress" && p.status == "inShop");
            return View(products);
        }

        


        

        [Authorize]
        public async Task<IActionResult> GetAllTshirtsInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "tshirt" && p.status == "inShop");
            return View(products);
        }

        public async Task<IActionResult> Indexs()
        {
            var employee = await dbContext.Boutiq.ToListAsync();
            return View(employee);
        }

                public async Task<IActionResult> FinancialReports()
        {
            return View();
        }

        

                public async Task<IActionResult> Sorted()
        {
            var employee = await dbContext.Boutiq.ToListAsync();
            return View(employee);
        }
        [Authorize]
        public IActionResult New()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(BoutiqViewModel model)
        {
            DateTime localDat = DateTime.Now;
            var localDate = localDat.ToString("dd-MMM-yyyy hh:mm:ss");

            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

               Boutiq botiq = new Boutiq
                {
                    Type = model.Type,
                    Description = model.Description,
                    Cost = model.Cost,
                    itemImage = uniqueFileName,
                    status = model.status,
                    DateOfEntry = localDate,
                    SalePrice = model.SalePrice,
                    DateOfSale = model.DateOfSale

                };
                dbContext.Add(botiq);
                await dbContext.SaveChangesAsync();
                                if(botiq.status =="deposited"){
                    return RedirectToAction(nameof(GetAllDeposited));
                }

                else if(botiq.status =="sold"){
                return RedirectToAction(nameof(GetSoldStalk));
                }
                return RedirectToAction(nameof(GetCurrentStalk));
            }
            return View();
        }

        private string UploadedFile(BoutiqViewModel model)
        {
            string uniqueFileName = null;

            if (model.itemImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.itemImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.itemImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        [Authorize]
        // GET: Stalk/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stalk = await dbContext.Boutiq
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stalk == null)
            {
                return NotFound();
            }

            return View(stalk);
        }

        [Authorize]
        // POST: Stalk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stalk = await dbContext.Boutiq.FindAsync(id);
            dbContext.Boutiq.Remove(stalk);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(GetCurrentStalk));
        }
        [Authorize]
        // GET: Stalk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stalk = await dbContext.Boutiq
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stalk == null)
            {
                return NotFound();
            }

            return View(stalk);
        }

        // GET: Stalk/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stalk = await dbContext.Boutiq.FindAsync(id);
            if (stalk == null)
            {
                return NotFound();
            }
            return View(stalk);
        }


        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(Boutiq stalk)

        {
            DateTime localDate = DateTime.Now;
            Boutiq botiq = new Boutiq
            {
                Id = stalk.Id,

                Type = stalk.Type,
                Description = stalk.Description,
                Cost = stalk.Cost,
                DateOfEntry = stalk.DateOfEntry,
                itemImage = stalk.itemImage,
                status = stalk.status,
                SalePrice = stalk.SalePrice,
                DateOfSale = stalk.DateOfSale
            };


            dbContext.Update(botiq);

            await dbContext.SaveChangesAsync();


            return RedirectToAction(nameof(GetCurrentStalk));

        }

                                [Authorize]
        public async Task<IActionResult> GetWeeklyProfits()
        {
            var products = dbContext.Boutiq.Where(p => p.status == "sold");
            
            return View(products);
        }
    }
}

