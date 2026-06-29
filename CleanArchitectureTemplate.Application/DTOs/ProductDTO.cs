using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage= "Product name required")]
    [StringLength(100, ErrorMessage ="Product name exceed 100 characters")]
    public string Name { get; set; }

    [Range(0.01, 10000.00, ErrorMessage = "The price must 0.01 to 10000.00 range")]
    public decimal Price { get; set; }
    public string Description { get; set; }

    public DateTime CreationDate { get; set; }

}
