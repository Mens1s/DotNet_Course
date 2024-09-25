using Microsoft.EntityFrameworkCore;

namespace RecapProject1.Entities;


[Keyless]
public class Categories
{
    public int category_id { get; set; }
    public string category_name { get; set; }
    public string description { get; set; }
}