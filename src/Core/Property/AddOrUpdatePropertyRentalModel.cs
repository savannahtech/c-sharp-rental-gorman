namespace Core.Property
{
    public class AddOrUpdatePropertyRentalModel
    {
        public decimal Deposit { get; set; }
        public int LetType { get; set; }
        public int MinimumTenancy { get; set; }
        public DateTime? AvailableDate { get; set; }
        public decimal Rent { get; set; }
    }
}
