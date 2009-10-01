namespace BlackOps.Test
{
    using System.Collections.Generic;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Testing;
    using Model.Observations;
    using NHibernate;
    using NHibernate.Tool.hbm2ddl;
    using NUnit.Framework;

    public class PersistentTestFixtureBase
    {
        protected ISessionFactory _factory;

        [TestFixtureSetUp]
        public void BeforeFixureStarts()
        {
            _factory = Fluently.Configure()
                .Database(() => MsSqlConfiguration
                                    .MsSql2005
                                    .ConnectionString(s => s.Database("BlackOps_Test")
                                                               .Server(".")
                                                               .TrustedConnection())
                                    .ShowSql())
                .Mappings(mc => mc.AutoMappings.Add(() => AutoMap.AssemblyOf<ObservationType>()
                                                              .Where(t => t.Name == "Entity" || t.Namespace.StartsWith("BlackOps.Model") && t.Name != "Observation")))
                .ExposeConfiguration(cfg =>
                {
                    new SchemaExport(cfg).Drop(false, true);
                    new SchemaExport(cfg).Create(false, true);
                })
                .BuildSessionFactory();
        }
    }

    [TestFixture]
    public class ModelIntegrationFixture : PersistentTestFixtureBase
    {
        [Test]
        public void Observation_Mappings()
        {
            using (var session = _factory.OpenSession())
            {
                new PersistenceSpecification<ObservationType>(session)
                    .CheckProperty(o => o.Name, "Requests/Second")
                    .VerifyTheMappings();

                new PersistenceSpecification<Node>(session)
                    .CheckProperty(o => o.UniqueId, "CONNERY")
                    .VerifyTheMappings();

                new PersistenceSpecification<Measurement>(session)
                    .CheckProperty(o => o.Value, 100l)
                    .VerifyTheMappings();

                new PersistenceSpecification<Event>(session)
                    .VerifyTheMappings();

                new PersistenceSpecification<Status>(session)
                    .VerifyTheMappings();

                new PersistenceSpecification<Feature>(session)
                    .CheckList(o => o.Nodes, new List<Node> {new Node()})
                    .VerifyTheMappings();
            }
        }
    }
}