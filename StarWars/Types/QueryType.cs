using HotChocolate.Types;
using StarWars.Directives;
using StarWars.Models;

namespace StarWars.Types
{
    public class QueryType
        : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Directive<ArgumentValidation>();

            descriptor.Field(t => t.GetHero(default))
                .Type<CharacterType>()
                .Argument("episode", a => a.DefaultValue(Episode.NewHope));

            descriptor.Field(t => t.GetCharacter(default, default))
                .Type<NonNullType<ListType<NonNullType<CharacterType>>>>();

            descriptor.Field(t => t.Search(default))
                .Type<ListType<SearchResultType>>()
                .Argument("text", t => t.Type<NonNullType<StringType>>()
                    .Validate<string>(s => !string.IsNullOrEmpty(s)));
        }
    }

}
