namespace BankingSystem.BankLogic
{
    public interface IAccountOwner
    {
        AccountOrigin Origin { get; }
        int Fee();
    }
}
