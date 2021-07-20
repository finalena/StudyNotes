using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex_11_035_10
{
    class Program
    {
        /* 低耦合力的好處:晚期繫結
         */
        static void Main(string[] args)
        {
            string className = "Ex_11_035_10.MemberJsonRepository";
            Assembly assembly = Assembly.GetExecutingAssembly();
            IMemberRepository memberRepo = assembly.CreateInstance(className) as IMemberRepository;

            memberRepo.Delete(100);

            Console.ReadLine();
        }
    }

    public interface IMemberRepository 
    {
        void Delete(int memberId);
    }

    public class MemberSqlRepository : IMemberRepository
    {
        public void Delete(int memberId)
        {
            Console.WriteLine(memberId);
        }
    }

    public class MemberJsonRepository : IMemberRepository
    {
        public void Delete(int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
