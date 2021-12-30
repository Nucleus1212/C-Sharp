using System;

namespace MySuperBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Nucleus Shrestha", 1500);
            Console.WriteLine($"Account {account.Number} was created by {account.Owner} with balance of {account.Balance}."); 
            
            account.MakeWithdrawl(150, DateTime.Now, "Tablet");
           // Console.WriteLine($"Current Balance after the purchase is, {account.Balance}");

            account.MakeWithdrawl(500, DateTime.Now, "Purchase for PS5");
            //Console.WriteLine($"Last Balance is, {account.Balance}");

            account.MakeDeposit(1000, DateTime.Now, "Credit Money");

            Console.WriteLine(account.GetAccountHistory());








            /* //Test for negative balance.
            try
            {
                account.MakeWithdrawl(900, DateTime.Now, "Attempt to overdraw");
            } 
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }



            //Test that the initial balances must be positive
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            
            } */
        }

    }
}
