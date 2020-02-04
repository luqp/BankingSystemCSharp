using System.Collections.Generic;

namespace BankingSystem.BankLogic
{
    public enum AccountOrigin
    {
        LOCAL,
        RURAL,
        FOREIGN  
    }

    static class GetOwnerByOrigin
    {
        private static Dictionary<AccountOrigin, IAccountOwner> owners = new Dictionary<AccountOrigin, IAccountOwner>()
        {
            {AccountOrigin.FOREIGN , new Owner(AccountOrigin.FOREIGN, 5) },
            {AccountOrigin.LOCAL , new Owner(AccountOrigin.LOCAL, 0) },
            {AccountOrigin.RURAL , new Owner(AccountOrigin.RURAL, 0) },
        };


        public static IAccountOwner GetOwner(this AccountOrigin origin) => owners[origin];
            
    }
}