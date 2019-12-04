using devopsapi.Models;
using devopsapi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devopsapi.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public Invoice Create(Invoice invoice)
        {
            return _invoiceRepository.Create(invoice);
        }

        public void Delete(int id)
        {
            _invoiceRepository.Delete(id);
        }

        public List<Invoice> Read()
        {
            return _invoiceRepository.Read();
        }

        public Invoice Read(int id)
        {
            return _invoiceRepository.Read(id);
        }

        public Invoice Update(int id, Invoice invoice)
        {
            return _invoiceRepository.Update(invoice);
        }
    }
}
