using devopsapi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devopsapi.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice Create(Invoice invoice);
        List<Invoice> Read();
        Invoice Read(int id);
        Invoice Update(Invoice invoice);
        StatusCodeResult Delete(int id);
    }
}
