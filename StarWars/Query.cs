using System;
using System.Collections.Generic;
using HotChocolate.Execution;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Http;
using StarWars.Data;
using StarWars.Models;

namespace StarWars
{
    public class Query
    {
        private readonly CharacterRepository _repository;

        public Query(CharacterRepository repository)
        {
            _repository = repository
                ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public ICharacter GetHero(
            IResolverContext resolverContext,
            Episode episode)
        {
            var context = resolverContext.Service<HttpContext>();

            if (context == null)
            {
                throw new QueryException(new QueryError("Can't inject HttpContext!"));
            }

            return _repository.GetHero(episode);
        }

        public Human GetHuman(
            IResolverContext resolverContext,
            string id)
        {
            try
            {
                var scoped = resolverContext.Service<ScopedService>();
            }
            catch (Exception ex)
            {
                throw new QueryException(new QueryError(ex.Message));
            }

            return _repository.GetHuman(id);
        }

        public Droid GetDroid(string id)
        {
            return _repository.GetDroid(id);
        }

        public IEnumerable<object> Search(string text)
        {
            return _repository.Search(text);
        }
    }
}
