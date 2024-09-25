using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Abstract;

namespace Northwind.Entities.Concrete;

[Keyless]
public class Product : IEntity
{
    public int product_id { get; set; }
    public string product_name { get; set; }
    public int category_id { get; set; }
    public double unit_price { get; set; }
    public Int16 units_in_stock { get; set; }
    public string quantity_per_unit { get; set; }
}