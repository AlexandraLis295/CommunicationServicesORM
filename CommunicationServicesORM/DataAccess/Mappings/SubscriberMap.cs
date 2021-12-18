namespace DataAccess.Mappings
{
    using FluentNHibernate.Mapping;
    using Domain;

    internal class SubscriberMap : ClassMap<Subscriber>
    {
        public SubscriberMap()
        {
            this.Table("Subscribers");

            this.Id(x => x.ID);

            this.Map(x => x.LastName)
                .Not.Nullable();

            this.Map(x => x.FirstName)
                .Not.Nullable();

            this.Map(x => x.Patronymic)
                .Nullable();

            this.HasManyToMany(x => x.Tariffs)
                .Cascade.Delete();
        }
    }
}
