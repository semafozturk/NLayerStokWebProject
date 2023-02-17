using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.Repositories
{
    public interface IExportDataRepository
    {
        DataSet ExportCustomerDataTable();
        DataTable ExportCustomer();
    }
}
