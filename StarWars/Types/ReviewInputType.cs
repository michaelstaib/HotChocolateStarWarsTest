using HotChocolate.Types;
using StarWars.Models;

namespace StarWars.Types
{
    public class ReviewInputType
        : InputObjectType<Review>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Review> descriptor)
        {
            descriptor.Name("ReviewInput");
        }
    }
}
