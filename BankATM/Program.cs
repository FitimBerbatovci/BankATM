using System;
using System.Collections.Generic;

class ATM
{
    static Dictionary<int, int> accounts = new Dictionary<int, int>()
    {
        { 12345, 1000 },
        { 67890, 2000 },
        { 11111, 3000 },
    };

    public static void Main()
    {
        int accountNumber;
        int pin;
        int choice;
        int amount;

        Console.Write("Enter account number: ");
        accountNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter PIN: ");
        pin = int.Parse(Console.ReadLine());

        if (ValidateAccount(accountNumber, pin))
        {
            do
            {
                Console.WriteLine("1. Check balance");
                Console.WriteLine("2. Withdraw money");
                Console.WriteLine("3. Deposit money");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CheckBalance(accountNumber);
                        break;
                    case 2:
                        Console.Write("Enter amount: ");
                        amount = int.Parse(Console.ReadLine());
                        WithdrawMoney(accountNumber, amount);
                        break;
                    case 3:
                        Console.Write("Enter amount: ");
                        amount = int.Parse(Console.ReadLine());
                        DepositMoney(accountNumber, amount);
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using our ATM. Have a good day!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
            } while (choice != 4);
        }
        else
        {
            Console.WriteLine("Invalid account number or PIN.");
        }
    }

    static bool ValidateAccount(int accountNumber, int pin)
    {
        if (accounts.ContainsKey(accountNumber) && accounts[accountNumber] == pin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void CheckBalance(int accountNumber)
    {
        Console.WriteLine("Your balance is $" + accounts[accountNumber]);
    }

    static void WithdrawMoney(int accountNumber, int amount)
    {
        if (amount > accounts[accountNumber])
        {
            Console.WriteLine("Insufficient balance.");
        }
        else
        {
            accounts[accountNumber] -= amount;
            Console.WriteLine("$" + amount + " withdrawn.");
            Console.WriteLine("Your new balance is $" + accounts[accountNumber]);
        }
    }

    static void DepositMoney(int accountNumber, int amount)
    {
        accounts[accountNumber] += amount;
        Console.WriteLine("$" + amount + " deposited.");
        Console.WriteLine("Your new balance is $" + accounts[accountNumber]);
    }
}
