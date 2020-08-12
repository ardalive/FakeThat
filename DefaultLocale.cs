using Bogus;

namespace FakeThat
{
    class DefaultLocale
    {
        private protected string locale, localeCode;
        private protected Faker<Log> faker;
        private protected LocaleDataLoader ldl;
        public DefaultLocale(string l, LocaleDataLoader ldl)
        {
            locale = l;
            localeCode = locale.Substring(0, 2);
            faker = new Faker<Log>();
            this.ldl = ldl;
        }
        public string GenerateLog()
        {
            Assemble();
            var f = faker.Generate();
            return $"{f.FirstName} {f.MiddleName} {f.LastName}; {f.PostCode}, {f.Address}; {f.Phone}";
        }
        private void Assemble()
        {
            GenerateFirstName();
            GenerateMiddleName();
            GenerateLastName();
            GenerateAddress();
            GeneratePhone();
            GeneratePostCode();
        }
        private protected virtual void GenerateFirstName()
        {
            faker.RuleFor(x => x.FirstName, x => x.Person.FirstName);
        }
        private protected virtual void GenerateMiddleName()
        {
            faker.RuleFor(x => x.MiddleName, x => x.Name.FirstName(x.Person.Gender));
        }
        private protected virtual void GenerateLastName()
        {
            faker.RuleFor(x => x.LastName, x => x.Person.LastName);
        }
        private protected virtual void GenerateAddress()
        {
            faker.RuleFor(x => x.Address, x =>
            $"{ldl.data.Country}, {x.Address.City()}, {x.Address.StreetName()} {x.Address.BuildingNumber()}, {x.Address.SecondaryAddress()}");
        }
        private protected virtual void GeneratePhone()
        {
            faker.RuleFor(x => x.Phone, x => x.Person.Phone);
        }
        private protected virtual void GeneratePostCode()
        {
            faker.RuleFor(x => x.PostCode, x => x.Address.ZipCode());
        }

    }
}
