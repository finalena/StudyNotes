using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_01_03_03
{
    class Program
    {
        //Factory工廠
        static void Main(string[] args)
        {
            var member1 = Member.MemberFactory.CreateByEmail(id: 1, email: "test@gmail.com");
            var member2 = Member.MemberFactory.CreateByName(id: 1, name: "Tom");
        }
    }

    public class Member 
    {
        private int Id;
        private string Name;
        private string Email;

        //私有建構子，外界無法new Member()建立物件
        private Member() { }

        //巢狀類別- MemberFactory(能製造出 Member 的工廠)
        public static class MemberFactory
        {
            public static Member CreateByName(int id, string name)
            {
                return new Member { Id = id, Name = name };

            }

            public static Member CreateByEmail(int id, string email) 
            {
                return new Member { Id = id, Email = email };
            }
        }
    }
}
