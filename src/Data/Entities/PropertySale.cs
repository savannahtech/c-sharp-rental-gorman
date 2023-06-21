using System.ComponentModel.DataAnnotations;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

public class PropertySale : BaseEntity
{
    public int PropertySaleId { get; set; }
    [Precision(18, 2)]
    public decimal Amount { get; set; }
    public DateTime? AvailableDate { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; }
    public int PropertyTenureTypeId { get; set; }
    public PropertyTenureType PropertyTenureType { get; set; }
}