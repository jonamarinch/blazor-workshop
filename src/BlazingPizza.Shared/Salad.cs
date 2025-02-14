using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizza;

public class Salad
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = "img/salads/default.jpg";

    public string GetFormattedBasePrice() => BasePrice.ToString("0.00");
}

