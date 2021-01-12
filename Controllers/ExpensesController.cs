using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpanseTracker.Models;
using System.IO;
using Fingers10.ExcelExport.ActionResults;

namespace ExpanseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpenseContext _context;

        public ExpensesController(ExpenseContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public ActionResult Index()
        {
            List<Expense> expensesList = _context.Expenses.ToList();
            return View(expensesList);
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            var expense = _context.Expenses
                .Find(id);

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Create( Expense expense)
        {
            if (expense.AttchFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    expense.AttchFile.CopyTo(memoryStream);
                    expense.Attachment = memoryStream.ToArray();
                    expense.FileName = expense.AttchFile.FileName;

                }
            }
           _context.Add(expense);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            var expense = _context.Expenses.Find(id);

            return View(expense);
        }


        [HttpPost]

        public ActionResult Edit(int id, Expense expense)
        {
            using (var memoryStream = new MemoryStream())
            {
                expense.AttchFile.CopyTo(memoryStream);
                expense.Attachment = memoryStream.ToArray();
                expense.FileName = expense.AttchFile.FileName;
            }
            _context.Update(expense);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {


            var expense = _context.Expenses
                .Find(id);

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            var expense = _context.Expenses.Find(id);
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Export()
        {
            List<Expense> expensesList = await _context.Expenses.ToListAsync();

            return new ExcelResult<Expense>(expensesList, "Sheet1", "Expenses");
        }

        public async Task<IActionResult> DownLoadReceipt(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense.Attachment == null)
            {
                return NotFound(); 
            }
            return File(expense.Attachment, System.Net.Mime.MediaTypeNames.Application.Octet, expense.FileName);
        }
    }
}
