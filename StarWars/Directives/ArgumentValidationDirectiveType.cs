using HotChocolate.Types;

namespace StarWars.Directives
{
    public class ArgumentValidationDirectiveType
        : DirectiveType<ArgumentValidationDirective>
    {
        protected override void Configure(
            IDirectiveTypeDescriptor<ArgumentValidationDirective> descriptor)
        {
            descriptor.Name("validate");
            descriptor.Location(DirectiveLocation.ArgumentDefinition);
            descriptor.BindArguments(BindingBehavior.Explicit);
        }
    }
}
