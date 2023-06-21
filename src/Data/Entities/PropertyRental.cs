using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

public class PropertyRental : BaseEntity
{
    public int PropertyRentalId { get; set; }
    [Precision(18, 2)]
    public decimal Deposit { get; set; }
    public int MinimumTenancy { get; set; }
    public DateTime? AvailableDate { get; set; }
    [Precision(18, 2)]
    public decimal Amount { get; set; }
    public int PropertyLetTypeId { get; set; }
    public PropertyLetType PropertyLetType { get; set; }
    public Property Property { get; set; }
    public int PropertyId { get; set; }
}