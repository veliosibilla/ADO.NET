using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind2
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
    }

    public class Category
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Product
    {
        public Guid CategoryID { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
        public int SupplierID { get; set; }

    }
}