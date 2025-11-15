using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Infrastructure;
using BankApp.Shared;

namespace BankApp.Core
{
    public interface IAccount
    {
        public int Create(string accountName, int personId);
    }
}
