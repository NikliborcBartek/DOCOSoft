using Domain.Common;

namespace Domain.Entieties
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }

        public User(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public void UpdatePersonalInfo(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
