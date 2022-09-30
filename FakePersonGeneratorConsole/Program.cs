using Newtonsoft.Json;

namespace FakePersonGeneratorConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            for (int i = 0; i < 1000; i++)
            {
                Person p = new();

                p.FirstName = Faker.Name.First();
                p.LastName = Faker.Name.Last();
                p.Age = Faker.RandomNumber.Next(1, 100);

                for (int j = 0; j < Faker.RandomNumber.Next(1, 5); j++)
                {
                    var street = Faker.Address.StreetName();
                    var city = Faker.Address.City();
                    var state = Faker.Address.UsState();
                    var zip = Faker.Address.ZipCode();

                    p.StreetAddresses.Add(new Address(street, city, state, zip));
                }

                for (int j = 0; j < Faker.RandomNumber.Next(1, 5); j++)
                {
                    p.EmailAddresses.Add(new Email(Faker.Internet.Email()));
                }

                people.Add(p);
            }

            var something = JsonConvert.SerializeObject(people, Formatting.Indented);

            if (!File.Exists("generated.json"))
            {
                File.Create("generated.json").Close();
            }

            File.WriteAllText("generated.json", something);
        }
    }
}