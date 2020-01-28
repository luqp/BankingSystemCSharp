namespace BankingSystem.BankLogic
{
    public class Foreign : IOwnerStrategy
    {
        public Foreign()
        {
            Origin = AccountOrigin.FOREIGN;
        }
        public AccountOrigin Origin { get; }

        public int Fee()
        {
            return 5;
        }

        public override string ToString() => "foreign";
    }
}
