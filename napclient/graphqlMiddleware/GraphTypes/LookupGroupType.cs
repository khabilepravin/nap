using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class LookupGroupType : ObjectGraphType<LookupGroup>
    {
        public LookupGroupType()
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.Name);
            Field(t => t.Code);
        }
    }
}
