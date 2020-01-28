namespace BankingSystem.BankLogic
{
    public interface IOwnerStrategy
    {
        AccountOrigin Origin { get; }
        int Fee();
    }
}
