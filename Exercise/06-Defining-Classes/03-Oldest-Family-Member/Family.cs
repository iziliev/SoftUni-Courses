using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> peoples;
        public Family()
        {
            this.Peoples = new List<Person>();
        }
        public List<Person> Peoples { get { return this.peoples; } set { this.peoples = value; } }

        public void AddMember(Person member)
        {
            this.Peoples.Add(member);
        }
        public Person GetOldestMember()
        {
            return this.Peoples.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
