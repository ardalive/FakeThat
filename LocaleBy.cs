using Bogus;

namespace FakeThat
{
    class LocaleBy : DefaultLocale
    {
        public LocaleBy(string l, LocaleDataLoader ldl) : base(l, ldl)
        {
            locale = l;
            faker = new Faker<Log>(locale: "ru");
            base.ldl = ldl;
        }

        private protected override void GenerateFirstName()
        {
            faker.RuleFor(x => x.FirstName, x =>
            x.Person.Gender.ToString() == "Male" ? x.PickRandom(ldl.data.MaleFirstName) : x.PickRandom(ldl.data.FemaleFirstName));
        }
        private protected override void GenerateMiddleName()
        {
            faker.RuleFor(x => x.MiddleName, x =>
            x.Person.Gender.ToString() == "Male" ? x.PickRandom(ldl.data.MaleMiddleName) : x.PickRandom(ldl.data.FemaleMiddleName));
        }
        private protected override void GenerateLastName()
        {
            faker.RuleFor(x => x.LastName, x =>
            x.Person.Gender.ToString() == "Male" ? x.PickRandom(ldl.data.MaleLastName) : x.PickRandom(ldl.data.FemaleLastName));
        }
        private protected string GenerateCity()
        {
            return new Bogus.Randomizer().ArrayElement(ldl.data.City);
        }
        private protected string GenerateStreet()
        {
            return new Bogus.Randomizer().ArrayElement(ldl.data.Street);
        }
        private protected override void GenerateAddress()
        {
            faker.RuleFor(x => x.Address, x =>
            $"{ldl.data.Country}, {GenerateCity()}, {GenerateStreet()} {x.Address.BuildingNumber()}, {x.Address.SecondaryAddress()}");
        }
        private protected override void GeneratePhone()
        {
            var phoneNumber = new Randomizer().Replace("###-##-##").ToString();
            faker.RuleFor(x => x.Phone, x => $"{ldl.data.PhoneCode}-{x.PickRandom(ldl.data.LocalCode)}-{phoneNumber}");
        }
        private protected override void GeneratePostCode()
        {
            var post = new Randomizer().Replace("###").ToString();
            faker.RuleFor(x => x.PostCode, x => x.PickRandom(ldl.data.PostalCode) + post);
        }
    }
}
