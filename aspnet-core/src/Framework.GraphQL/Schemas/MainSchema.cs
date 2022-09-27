using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using Framework.Queries.Container;
using System;

namespace Framework.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}