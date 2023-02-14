namespace RESTWithDotNet.Models.Services.Implementation
{
    public interface IPersonService
    {
        Person Create (Person person);

        Person FindById(long id);

        Person Update (Person person);

        List<Person> FindAll();

        void Delete (long id);
    }
}