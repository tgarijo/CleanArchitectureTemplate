using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.DTOs;

public class ProductoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage= "Product name required")]
    public string Name { get; set; }

    public decimal Price { get; set; }
    public string Description { get; set; }

    public DateTime CreationDate { get; set; }

}
