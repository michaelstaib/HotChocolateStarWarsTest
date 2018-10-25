using System;
using HotChocolate.Execution;
using HotChocolate.Language;
using HotChocolate.Types;

namespace StarWars.Directives
{
    public static class ValidationExtensions
    {
        public static IArgumentDescriptor Validate<T>(
            this IArgumentDescriptor argumentDescriptor,
            Func<T, bool> func)
        {
            void Validator(IDirective d, FieldNode n, object o)
            {
                var isValid = false;
                if (o is T t)
                {
                    isValid = func(t);
                }

                if (!isValid)
                {
                    throw new QueryException(new ArgumentError(
                        "Argument is not valid.",
                        ((InputField)d.Source).Name, n));
                }
            }

            return argumentDescriptor.Directive(
                new ArgumentValidationDirective { Validator = Validator });
        }
    }
}
