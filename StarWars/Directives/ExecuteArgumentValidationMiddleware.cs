using System.Collections.Generic;
using System.Linq;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace StarWars.Directives
{
    public class ExecuteArgumentValidationMiddleware
    {
        public void Validate(IResolverContext context)
        {
            foreach (var argument in context.Field.Arguments)
            {
                foreach (var directive in argument.Directives)
                {
                    var argumentValue =
                        context.Argument<object>(argument.Name);

                    var argumentValidator =
                        directive.ToObject<ArgumentValidationDirective>();

                    argumentValidator.Validator(
                        directive, context.FieldSelection, argumentValue);
                }
            }
        }

        private IEnumerable<IDirective> GetArgumentDirectives(ObjectField field)
        {
            return field.Arguments.SelectMany(t => t.Directives);
        }
    }
}
