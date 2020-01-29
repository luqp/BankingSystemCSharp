namespace BankingSystem.BankLogic
{
    public class Rural : IOwnerStrategy
    {
        public Rural()
        {
            Origin = AccountOrigin.RURAL;
        }
        public AccountOrigin Origin { get; }

        public int Fee()
        {
            return 0;
        }

        public override string ToString() => "rural";
    }
}
