namespace DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using Domain;

    internal class TariffMap : ClassMap<Tariff>
    {
        public TariffMap()
        {
            this.Table("Tariffs");

            this.Id(x => x.ID);

            this.Map(x => x.TariffName)
                .Not.Nullable();

            this.HasManyToMany(x => x.Subscribers)
                .Cascade.Delete()
                .Inverse();
        }
    }
}
