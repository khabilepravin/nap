using GraphQL.Types;
using models;

namespace graphqlMiddleware.GraphTypes
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(t => t.Id, type: typeof(IdGraphType));
            Field(t => t.FirstName);
            Field(t => t.LastName);
            Field(t => t.Email);
            Field(t => t.UserName);
            Field(t => t.UserType);
            Field(t => t.Password);                        
            Field(t => t.CreatedAt);
            Field(t => t.ModifiedAt);
            Field(t => t.ParentUserId, type: typeof(IdGraphType));
            Field(t => t.Status);
            Field(t => t.SocialLoginId);
            Field(t => t.SocialProfilePicUrl);
        }
    }
}
