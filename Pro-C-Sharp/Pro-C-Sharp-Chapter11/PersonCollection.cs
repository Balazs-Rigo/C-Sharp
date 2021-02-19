using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pro_C_Sharp_Chapter11
{
    public class PersonCollection
    {
        private Dictionary<string, Person> listPeople = new Dictionary<string, Person>();
        // This indexer returns a person based on a string index.
        public Person this[string name]
        {
            get => (Person)listPeople[name];
            set => listPeople[name] = value;
        }
        public void ClearPeople()
        { listPeople.Clear(); }
        public int Count => listPeople.Count;
       // IEnumerator IEnumerable.GetEnumerator() => listPeople.GetEnumerator();
    }
}
