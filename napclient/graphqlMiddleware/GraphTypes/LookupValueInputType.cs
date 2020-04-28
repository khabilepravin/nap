using GraphQL.Types;

namespace graphqlMiddleware.GraphTypes
{
    public class LookupValueInputType : InputObjectGraphType
    {
        public LookupValueInputType()
        {
            Name = "LookupValueInput";
            Field<NonNullGraphType<IdGraphType>>("groupId");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("code");
            Field<StringGraphType>("description");
            Field<IdGraphType>("id");
        }
    }
}
