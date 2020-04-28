using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class LookupValueType : ObjectGraphType<LookupValue>
    {
        public LookupValueType()
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.GroupId, type: typeof(IdGraphType));
            Field(t => t.Name);
            Field(t => t.Code);
            Field(t => t.Description);
        }
    }
}
