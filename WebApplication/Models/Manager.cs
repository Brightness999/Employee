namespace WebApplication.Models;

public class Manager
{
    public int ManagerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address1 { get; set; }
    public decimal AnnualSalary { get; set; }
    public decimal MaxExpenseAmount { get; set; }
}