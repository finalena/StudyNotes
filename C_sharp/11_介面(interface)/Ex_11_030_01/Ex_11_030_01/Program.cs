using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_11_030_01
{
    class Program
    {
        /* 自訂集合、列舉集合中的值
         * IEnumerable 是所有可列舉之非泛型集合的基底介面。有 GetEnumerator()方法，並傳回實作IEnumerator的成員。
         * IEnumerator 介面，有 Current、MoveNext、Reset成員。
         * 
         * IEnumerable<T> 繼承 IEnumerable
         * LINQ 可以針對集合, XML, 資料庫提供一致的查詢方式, 其中集合指的就是有實作 IEnumerable<T> 的類別
         */
        static void Main(string[] args)
        {
            Member[] items = new Member[]
            {
                new Member{ Id = 1, Name = "A"},
                new Member {Id = 2, Name = "B"},
                new Member {Id = 3, Name = "C"}
            };

            var memberCollection = new MemberCollection(items);
            foreach (object memberObj in memberCollection)
            {
                Member member = memberObj as Member;
                Console.WriteLine(member.ToString());
            }
           
            Console.ReadLine();
        }
    }

    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Id={Id}, Name={Name}";
        }
    }

    public class MemberCollection : IEnumerable<Member>
    {
        private MemberEnum _memberEnum;
        public MemberCollection(Member[] members)
        {
            _memberEnum = new MemberEnum(members);
        }

        public IEnumerator<Member>  GetEnumerator()
        {
            return this._memberEnum;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MemberEnum : IEnumerator<Member>
    {
        private readonly Member[] _members;
        private int _index;
        public Member Current { get { return _members[_index]; } }

        object IEnumerator.Current => Current;

        public MemberEnum(Member[] members)
        {
            if (members == null) throw new ArgumentNullException();

            _members = members;
            _index = -1;
        }
        public bool MoveNext()
        {
            if(_index < _members.Length-1)
            {
                _index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _index = -1;
        }

        public void Dispose()
        {
        }
    }

}
