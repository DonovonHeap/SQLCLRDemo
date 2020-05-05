using System;
using System.Collections.Generic;
using System.Text;

namespace UserGroupDemo
{
    public class Person : IJob
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public void EarnMoney()
        {
            return;
        }
    }
}