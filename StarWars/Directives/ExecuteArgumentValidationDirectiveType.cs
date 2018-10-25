using HotChocolate.Types;

namespace StarWars.Directives
{
    public class ExecuteArgumentValidationDirectiveType
        : DirectiveType<ArgumentValidation>
    {
        protected override void Configure(IDirectiveTypeDescriptor<ArgumentValidation> descriptor)
        {
            descriptor.Name("executeValidation");
            descriptor.Location(DirectiveLocation.Object);
            descriptor.Middleware<ExecuteArgumentValidationMiddleware>(
                t => t.ValidateAsync(default));
        }
    }
}
