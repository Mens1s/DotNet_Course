using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Abstract;

namespace Northwind.Entities.Concrete;

[Keyless]
public class Category:IEntity
{
    public int category_id { get; set; }
    public string category_name { get; set; }
    public string description { get; set; }
}