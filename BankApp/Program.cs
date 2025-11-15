using BankApp.Console;
using BankApp.Core;
using BankApp.Infrastructure;
using BankApp.Services;
using BankApp.Shared;

// See https://aka.ms/new-console-template for more information
//var start = new CheckingAccount();

//start.Create("AccName1", 1);
//start.Remove(2);

//var run = new UserInteraction();
UserInteraction.Run();

//LoginServices.Test();

//using (var context = new BankDbConnection())
//{
//    var account = new AccountsTable
//    {
//        AccountName = "NewAccount",
//        AccountTypeId = 2,
//        PersonId = 2,
//        TimeOfCreation = DateTime.Now,
//        IBAN = EnteringData.CreateUniqueIBAN()
//    };
//    context.Accounts.Add(account);
//    context.SaveChanges();

//    var balance = new AccountBalanceTable
//    {
//        AccountId = account.AccountId
//    };
//    context.AccountBalance.Add(balance);
//    context.SaveChanges();
//}