using GraphQL.Types;

namespace graphqlMiddleware.GraphTypes
{
    public class LookupGroupInputType : InputObjectGraphType
    {
        public LookupGroupInputType()
        {
            Name = "LookupGroupInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("code");
            Field<IdGraphType>("id");
        }
    }
}
