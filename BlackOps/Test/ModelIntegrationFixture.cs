using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.AutoMap;
using FluentNHibernate.Cfg;
using FluentNHibernate.Framework;
using FluentNHibernate.Metadata;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using FluentNHibernate;
using Pulse.OpsDB.Model.Observations;

namespace Pulse.OpsDB.Test
{
    
    public class PersistentTestFixtureBase
    {
        protected ISessionFactory _factory;

        [TestFixtureSetUp]
        public void BeforeFixureStarts()
        {
            var autoMappings =
                AutoPersistenceModel
                    .MapEntitiesFromAssemblyOf<ObservationType>()
                    .MergeWithAutoMapsFromAssemblyOf<Entity>()
                    .Where(t => t.Name == "Entity" || t.Namespace.StartsWith("Pulse.OpsDB.Model") && t.Name != "Observation")
                    ;
            
            var conf = new Configuration();

            MsSqlConfiguration
                .MsSql2005
                .ConnectionString.Is("Server=127.0.0.1;Initial Catalog=OpsDB_Test;Integrated Security=True")
                .ShowSql()
                .ConfigureProperties(conf)
                .AddAutoMappings(autoMappings);
            
            _factory = conf.BuildSessionFactory();

            new SchemaExport(conf).Drop(false,true);
            new SchemaExport(conf).Create(false,true);
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
                    .CheckList(o => o.Nodes, new List<Node> { new Node() })
                    .VerifyTheMappings();
            }
        }
    }
}
