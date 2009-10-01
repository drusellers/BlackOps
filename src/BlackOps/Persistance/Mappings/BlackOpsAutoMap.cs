namespace BlackOps.Persistance.Mappings
{
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using Model.Observations;

    public class BlackOpsAutoMap
    {
        public static void BuildMaps(MappingConfiguration mc)
        {
            mc.AutoMappings.Add(() => AutoMap.AssemblyOf<ObservationType>()
                                          .Where(t => t.Name == "Entity" || t.Namespace.StartsWith("BlackOps.Model") && t.Name != "Observation"));
        }
    }
}