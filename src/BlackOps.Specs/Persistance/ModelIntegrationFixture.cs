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
    using Persistance.Mappings;

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
                .Mappings(BlackOpsAutoMap.BuildMaps)
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
                    .CheckProperty(o => o.Key, "Requests/Second")
                    .CheckProperty(o => o.Description, "The requests per second")
                    .VerifyTheMappings();

                new PersistenceSpecification<Node>(session)
                    .CheckProperty(o => o.UniqueId, "CONNERY")
                    .VerifyTheMappings();


                new PersistenceSpecification<Observation>(session)
                    .CheckProperty(o=>o.Measurement, 23)
                    .CheckProperty(o=>o.Status, "OFF")
                    .VerifyTheMappings();

                new PersistenceSpecification<Feature>(session)
                    .CheckList(o => o.Nodes, new List<Node> {new Node()})
                    .VerifyTheMappings();
            }
        }
    }
}