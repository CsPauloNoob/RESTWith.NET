using RESTWithDotNet.Models.Services.Implementation;

namespace RESTWithDotNet.Models.Services
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int Count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for(var i =0; i<8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }


        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Paulo",
                LastName = "cesar",
                Address = "Manaus-AM",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int v)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Paulo"+ v,
                LastName = "cesar"+v,
                Address = "Manaus-AM",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref Count);
        }
    }
}