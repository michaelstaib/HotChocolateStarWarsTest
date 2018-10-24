using System;
using HotChocolate.Language;
using HotChocolate.Types;

namespace StarWars.Directives
{
    public class ArgumentValidationDirective
    {
        public Action<IDirective, FieldNode, object> Validator { get; set; }
    }
}
