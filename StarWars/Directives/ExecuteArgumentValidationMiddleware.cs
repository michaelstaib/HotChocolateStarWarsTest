using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace StarWars.Directives
{
    public class ExecuteArgumentValidationMiddleware
    {
        public async Task ValidateAsync(IDirectiveContext context)
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

            // The middleware pipleine overwrites the default middleware pipeline.
            // In order to execute the default resolver pipeline resolve has to be trggerd.
            context.Result = await context.ResolveAsync<object>();
        }

        private IEnumerable<IDirective> GetArgumentDirectives(ObjectField field)
        {
            return field.Arguments.SelectMany(t => t.Directives);
        }
    }
}
