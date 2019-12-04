using devopsapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devopsapi.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DtbankdbContext _context;

        public InvoiceRepository(DtbankdbContext context)
        {
            _context = context;
        }

        public Invoice Create(Invoice invoice)
        {
            _context.Add(invoice);
            _context.SaveChanges();
            return invoice;
        }

        public StatusCodeResult Delete(int id)
        {
            var deletedInvoice = Read(id);
            _context.Remove(deletedInvoice);
            _context.SaveChanges();
            return new OkResult();
        }

        public List<Invoice> Read()
        {
            return _context.Invoice.ToList();
        }

        public Invoice Read(int id)
        {
            return _context.Invoice.AsNoTracking()
                   .FirstOrDefault(p => p.id == id);
        }

        public Invoice Update(Invoice invoice)
        {
            _context.Update(invoice);
            _context.SaveChanges();
            return invoice;
        }
    }
}
