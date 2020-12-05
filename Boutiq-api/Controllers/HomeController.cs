
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoreUploadAndDisplayImage_Demo.Data;
using Boutiq_api.Models;
using Boutiq_api.ViewModels;
using System.Collections;
using System.Collections.Generic;
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

        public async Task<IActionResult> BoutiqWorth()
        {
            var employee = await dbContext.Boutiq.ToListAsync();
            return View(employee);
        }
        [Authorize]
        public async Task<IActionResult> GetCurrentStalk()
        {
            var products = dbContext.Boutiq.Where(p => p.status == "inShop");
            ViewBag.drw = products.Count();

            return View(products);
        }
        [Authorize]
        public async Task<IActionResult> GetSoldStalk()
        {
            var products = dbContext.Boutiq.Where(p => p.status == "sold");
            ViewBag.sold = products.Count();
            return View(products);
        }

                [Authorize]
        public async Task<IActionResult> GetAllTshirtsSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "tshirt" && p.status == "sold");
            ViewBag.tshirtsSold = products.Count();
            return View(products);
        }


                        [Authorize]
        public async Task<IActionResult> GetAllDeposited()
        {
            var products = dbContext.Boutiq.Where(p => p.status == "deposited");
            ViewBag.depositedOn = products.Count();
            return View(products);
        }


                [Authorize]
        public async Task<IActionResult> GetAllPantsSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "pants" && p.status == "sold");
            ViewBag.pantsSold = products.Count();
            return View(products);
        }

                [Authorize]
        public async Task<IActionResult> GetAllPantsInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "pants" && p.status == "inShop");
            ViewBag.pantsInShop = products.Count();
            return View(products);
        }


                        [Authorize]
        public async Task<IActionResult> GetAllJeansSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "Jean" && p.status == "sold");
            ViewBag.jeansSold = products.Count();
            return View(products);
        }

                [Authorize]
        public async Task<IActionResult> GetAllJeansInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "Jean" && p.status == "inShop");
            ViewBag.jeansInShop = products.Count();

            return View(products);
        }


                        [Authorize]
        public async Task<IActionResult> GetAllLeggingsSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "Legging" && p.status == "sold");
            ViewBag.leggingsSold = products.Count();

            return View(products);
        }

        

                [Authorize]
        public async Task<IActionResult> GetAllLeggingsInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "Legging" && p.status == "inShop");
            ViewBag.leggingsinShop = products.Count();
            return View(products);
        }

                        [Authorize]
        public async Task<IActionResult> GetAllTopsSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "top" && p.status == "sold");
            ViewBag.tops = products.Count();
            return View(products);
        }

                [Authorize]
        public async Task<IActionResult> GetAllTopsInShop()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "top" && p.status == "inShop");
            ViewBag.topsInShop = products.Count();
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
            ViewBag.jumpsuitsInShop = products.Count();
            return View(products);
        }


                                        [Authorize]
        public async Task<IActionResult> GetAllTwoPieceSold()
        {
            var products = dbContext.Boutiq.Where(p => p.Type == "twopiece" && p.status == "sold");
            ViewBag.twoPieceInShop = products.Count(); 
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
            ViewBag.tshirtsInShop = products.Count();
            return View(products);
        }

        public async Task<IActionResult> Indexs()
        {
            var employee = await dbContext.Boutiq.ToListAsync();
            return View(employee);
        }

                public async Task<IActionResult> FinancialReports()
        {
            DateTime date = DateTime.Now.AddDays(-7);
            Console.Write(date);
            var products = dbContext.Boutiq.Where(p =>p.status == "sold" && p.DateOfSale >= date );
            ViewBag.weeklysales = products.Count();
            //DateTime mondayOfLastWeek = date.AddDays(-(int)date.DayOfWeek - 6);
            return View(products);
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
        List<int> totalValue = new List<int>();
        int BoutiqWorths = 0;
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(BoutiqViewModel model)
        {
            DateTime localDat = DateTime.Now;
           
            totalValue.Add(model.SalePrice);

            BoutiqWorths = totalValue.Sum();
            ViewBag.Title = "Put your page title here";

            var localDate = localDat.ToString("dd-MMM-yyyy hh:mm:ss");

            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                string iDate = model.DateOfSale;
                DateTime oDate = Convert.ToDateTime(iDate);
                Boutiq botiq = new Boutiq
                {
                    Type = model.Type,
                    Description = model.Description,
                    Cost = model.Cost,
                    itemImage = uniqueFileName,
                    status = model.status,
                    DateOfEntry = localDate,
                    SalePrice = model.SalePrice,
                   DateOfSale = oDate,
                    BoutiqWorth = BoutiqWorths

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
            string returnPage = null;
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



            if (botiq.Type == "pants" && botiq.status == "sold")
            {
                returnPage = "GetAllPantsSold";
            }
            if (botiq.Type == "pants" && botiq.status == "inShop")
            {
                returnPage = "GetAllPantsInShop";
            }

            if (botiq.Type == "Legging" && botiq.status == "sold")
            {
                returnPage = "GetAllLeggingsSold";
            }
            if (botiq.Type == "Legging" && botiq.status == "inShop")
            {
                returnPage = "GetAllLeggingsInShop";
            }


            if (botiq.Type == "top" && botiq.status == "sold")
            {
                returnPage = "GetAllTopsSold";
            }
            if (botiq.Type == "top" && botiq.status == "inShop")
            {
                returnPage = "getalltopsinshop";
            }


            if (botiq.Type == "tshirt" && botiq.status == "inShop")
            {

                returnPage = nameof(GetAllTshirtsInShop);

               }
            if (botiq.Type == "tshirt" && botiq.status == "sold")
            {
                returnPage = "GetAllTshirtsSold";
            }


            if (botiq.Type == "twopiece" && botiq.status == "sold")
            {
                returnPage = "GetAllTwoPieceSold";
            }
            if (botiq.Type == "twopiece" && botiq.status == "inShop")
            {
                returnPage = "GetAllTwoPieceInShop";
            }

            if (botiq.Type == "Jumpsuit" && botiq.status == "sold")
            {
                returnPage = "GetAllJumpSuitsSold";
            }
            if (botiq.Type == "Jumpsuit" && botiq.status == "inShop")
            {
                returnPage = "GetAllJumpSuitsInShop";
            }


            dbContext.Update(botiq);

            await dbContext.SaveChangesAsync();

            return RedirectToAction(returnPage);
        }

                                [Authorize]
        public async Task<IActionResult> GetWeeklyProfits()
        {
            var products = dbContext.Boutiq.Where(p => p.status == "sold");
            ViewBag.weeklySales = products.Count();

            return View(products);
        }

        public async Task<IActionResult> MonthlyReports()
        {
            DateTime date = DateTime.Now.AddDays(-30);
            Console.Write(date);
            var products = dbContext.Boutiq.Where(p => p.status == "sold" && p.DateOfSale >= date);
            ViewBag.monthlysales = products.Count();
            //DateTime mondayOfLastWeek = date.AddDays(-(int)date.DayOfWeek - 6);
            return View(products);
        }

    }
}

