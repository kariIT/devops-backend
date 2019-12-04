using devopsapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devopsapi.Services
{
    public interface IInvoiceService
    {
        Invoice Create(Invoice invoice);
        List<Invoice> Read();
        Invoice Read(int id);
        Invoice Update(int id, Invoice invoice);
        void Delete(int id);
    }
}
