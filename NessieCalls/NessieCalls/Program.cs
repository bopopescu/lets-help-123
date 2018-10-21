using System;

namespace NessieCalls
{
    class Program
    {
        static void Main(string[] args)
        {
            Nessie n = new Nessie();

            Deposit d = new Deposit();
            d.idInput = "5bcb8c20322fa06b67793e29";
            d.mediumInput = "balance";
            d.amountInput = 100.0;
            d.transactionDate = "1-2";

            if(!n.makeDeposit(d)){
                Console.WriteLine("Cannot deposit");
            }

            Withdrawal w = new Withdrawal();
            w.idInput = "5bcb8c20322fa06b67793e29";
            w.mediumInput = "balance";
            w.amountInput = 100.0;
            w.transactionDate = "1-2";

            if (!n.makeWithdrawal(w))
            {
                Console.WriteLine("Cannot withdraw");
            }
        }
    }
}
