namespace BankingSystem.BankLogic
{
    public class Owner : IAccountOwner
    {
        private readonly int fee;

        public Owner(AccountOrigin origin, int fee)
        {
            Origin = origin;
            this.fee = fee;
        }

        public AccountOrigin Origin { get; }

        public int Fee()
        {
            //TODO: (New feature) Anualy request to maintaining of accounts
            return fee;
        }
    }
}