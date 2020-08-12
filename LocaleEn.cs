using Bogus;

namespace FakeThat
{
    class LocaleEn : DefaultLocale
    {
        public LocaleEn(string l, LocaleDataLoader ldl) : base(l, ldl)
        {
            locale = l;
            faker = new Faker<Log>(locale: localeCode);
            base.ldl = ldl;
        }
    }
}
