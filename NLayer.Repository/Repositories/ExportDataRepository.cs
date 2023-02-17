using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nlayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ExportDataRepository: IExportDataRepository
    {
        private IConfiguration _configuration;

        public ExportDataRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DataTable ExportCustomer()
        {
            DataTable Custdatatable = ExportCustomerDataTable().Tables[0];
            return Custdatatable;

        }
        public DataSet ExportCustomerDataTable()
        {
            DataSet ds = new DataSet();
            var sqlconn = _configuration.GetConnectionString("SqlConnection");

            string getcustomer = "SELECT saleId AS ID,saleDate AS 'SATIŞ TARİHİ',P.productName AS ÜRÜN ,S.salesQuantity AS ADET,P.salePrice AS 'ADET FİYAT', S.salesQuantity*P.salePrice AS TOPLAM  ,comment AS 'NOT' FROM Sales S INNER JOIN Products P ON S.productId=P.productId ORDER BY saleDate";
            using (SqlConnection scon = new SqlConnection(sqlconn))
            {
                using (SqlCommand cmd = new SqlCommand(getcustomer))
                {
                    cmd.Connection = scon;
                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlAdapter.Fill(ds);

                    }
                }
            }
            return ds;
        }
    }
}
