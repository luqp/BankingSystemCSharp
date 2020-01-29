using System;

namespace BankingSystem.BankLogic
{
    public class Owner : IOwnerStrategy
    {
        private readonly int fee;

        private Owner(AccountOrigin origin, int fee)
        {
            Origin = origin;
            this.fee = fee;
        }

        // Is it good in this way?
        public static IOwnerStrategy GetOriginOwner(AccountOrigin origin) =>
            origin switch
            {
                AccountOrigin.FOREIGN => new Owner(origin, 5),
                AccountOrigin.LOCAL => new Owner(origin, 0),
                AccountOrigin.RURAL => new Owner(origin, 0),
                _ => throw new ArgumentException(message: "Invalid enum value", paramName: nameof(origin))
            };

        public AccountOrigin Origin { get; }

        public int Fee()
        {
            //TODO: (New feature) Anualy request to maintaining of accounts
            return fee;
        }
    }
}