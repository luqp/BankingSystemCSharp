namespace BankingSystem.BankLogic
{
    public class Local : IOwnerStrategy
    {
        public Local()
        {
            Origin = AccountOrigin.LOCAL;
        }
        public AccountOrigin Origin { get; }

        public int Fee()
        {
            return 0;
        }

        public override string ToString() => "local";
    }
}