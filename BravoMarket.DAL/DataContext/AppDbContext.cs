using BravoMarket.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BravoMarket.DAL.DataContext
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<SliderDot> SliderDots { get; set; }
        public DbSet<IndexSlider> IndexSliders { get; set; }
        public DbSet<Special> Special { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }
        public DbSet<MarketType> MarketTypes { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<İndicator> İndicators { get; set; }
        public DbSet<AdvantageThree> AdvantagesThree { get; set; }
        public DbSet<Career> Career { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<CardImage> CardImages { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Vision> Visions { get; set; }
        public DbSet<Standart> Standart { get; set; }
        public DbSet<StandartThree> StandartThrees { get; set; }
        public DbSet<CorporativeValue> CorporativeValues { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<CommentType> CommentTypes { get; set; }
        public DbSet<ClientFAQ> ClientFAQ { get; set; }
        public DbSet<ClientFAQTitle> ClientFAQTitles { get; set; }
        public DbSet<ClientFAQAnswer> ClientFAQAnswers { get; set; }
        public DbSet<ConsumerProtection> ConsumerProtection { get; set; }
        public DbSet<ConsumerProtectionInfo> ConsumerProtectionInfos { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<Preference> Preference { get; set; }
        public DbSet<PreferenceParagraph> PreferenceParagraphs { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyType> VacancyTypes { get; set; }
        public DbSet<Promise> Promises { get; set; }
        public DbSet<CareerBanner> CareerBanner { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<KSMActivity> KSMActivities { get; set; }
        public DbSet<Exibition> Exibitions { get; set; }
        public DbSet<Refusal> Refusals { get; set; }
        public DbSet<Refusalİnfo> Refusalİnfos { get; set; }
        public DbSet<TermOfUse> TermsOfUse { get; set; }
        public DbSet<Corporative> Corporative { get; set; }
        public DbSet<CorporativeBanner> CorporativeBanner { get; set; }
        public DbSet<CorporativeClientService> CorporativeClientService { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Header> Header { get; set; }
        public DbSet<LeftNavigation> LeftNavigations { get; set; }
        public DbSet<RightNavigation> RightNavigations { get; set; }
        public DbSet<Footer> Footer { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Law> Laws { get; set; }
        public DbSet<Other> Others { get; set; }
        public DbSet<FooterAbout> FooterAbouts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
    }
}
