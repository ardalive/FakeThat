using Bogus;

namespace FakeThat
{
    class LocaleRu : DefaultLocale
    {
        public LocaleRu(string l, LocaleDataLoader ldl) : base(l, ldl)
        {
            locale = l;
            faker = new Faker<Log>(locale: localeCode);
            base.ldl = ldl;
        }
        private protected override void GenerateMiddleName()
        {
            faker.RuleFor(x => x.MiddleName, x =>
            x.Person.Gender.ToString() == "Male" ? x.PickRandom(ldl.data.MaleMiddleName) : x.PickRandom(ldl.data.FemaleMiddleName));
        }
    }
}
