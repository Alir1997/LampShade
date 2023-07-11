namespace DiscountManagement.Application.Contract.ColleagueDiscount;

public class ColleagueDiscountViewModel
{
    public long ProductId { get; set; }
    public long Id { get; set; }
    public string Product { get; set; }
    public int DiscountRate { get; set; }
    public string CreationDate { get; set; }
    public bool IsRemoved { get; set; }
}