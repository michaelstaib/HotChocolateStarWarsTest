using HotChocolate.Types;

namespace StarWars.Types
{
    public class SubscriptionType
        : ObjectType<Subscription>
    {
        protected override void Configure(IObjectTypeDescriptor<Subscription> descriptor)
        {
            descriptor.Field(t => t.OnReview(default))
                .Type<ListType<NonNullType<ReviewType>>>();
        }
    }
}
