using devopsapi.Models;
using devopsapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XUnitTests
{
    public class FakeInvoiceService : IInvoiceService
    {
        private readonly List<Invoice> _invoices;

        public FakeInvoiceService()
        {
            _invoices = new List<Invoice>()
            {
                new Invoice() {id = 1, InvoiceSender = "Matti", RecipientName="Jukka",
                    RecipientIBAN="FI219255683241", Reference="1234567", InvoiceNumber="INV-100001",
                BIC="OKOYFIHH", Total=10.20M, DueDay=new DateTime(2019, 12, 24), Date=DateTime.Today},
                new Invoice() {id = 2, InvoiceSender = "Esko", RecipientName="Arto",
                    RecipientIBAN="FI219255234241", Reference="1122334", InvoiceNumber="INV-100002",
                BIC="OKOYFIHH", Total=66.60M, DueDay=new DateTime(2020, 10, 30), Date=DateTime.Today},
                new Invoice() {id = 3, InvoiceSender = "Vesa", RecipientName="Keskinen",
                    RecipientIBAN="FI219255234651", Reference="5522334", InvoiceNumber="INV-103003",
                BIC="NDEAFIHH", Total=500.00M, DueDay=new DateTime(2019, 11, 28), Date=DateTime.Today}
            };
        }

        public List<Invoice> Read()
        {
            return _invoices;
        }

        public Invoice Create(Invoice newInvoice)
        {
            _invoices.Add(newInvoice);
            return newInvoice;
        }

        public Invoice Read(int id)
        {
            return _invoices.Where(a => a.id == id)
                .FirstOrDefault();
        }

        public void Delete(int id)
        {
            var existing = _invoices.First(a => a.id == id);
            _invoices.Remove(existing);
        }

        public Invoice Update(int id, Invoice invoice)
        {
            var existing = _invoices.First(i => i.id == id);
            if (existing == null)
            {
                throw new Exception(message: "Invoice does not exist.");
            }

            existing = invoice;

            return existing;
        }
    }
}
