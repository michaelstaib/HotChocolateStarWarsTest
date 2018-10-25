using HotChocolate.Types;

namespace StarWars.Directives
{
    public class ExecuteArgumentValidationDirectiveType
        : DirectiveType
    {
        protected override void Configure(IDirectiveTypeDescriptor descriptor)
        {
            descriptor.Name("executeValidation");
            descriptor.Location(DirectiveLocation.Object);
            descriptor.Middleware<ExecuteArgumentValidationMiddleware>(
                t => t.ValidateAsync(default));
        }
    }
}
