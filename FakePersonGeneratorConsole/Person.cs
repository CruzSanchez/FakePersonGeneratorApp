namespace FakePersonGeneratorConsole
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Address> StreetAddresses { get; set; } = new();
        public List<Email> EmailAddresses { get; set; } = new();
    }
}