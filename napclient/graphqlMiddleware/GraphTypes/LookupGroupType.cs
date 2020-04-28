using dataAccess.Repositories;
using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class LookupGroupType : ObjectGraphType<LookupGroup>
    {
        public LookupGroupType(ILookupRepository lookupRepository)
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.Name);
            Field(t => t.Code);
            Field<ListGraphType<LookupValueType>>("lookupValues",
                resolve: context => lookupRepository.GetValuesByGroupAsync(context.Source.Id));
        }
    }
}
