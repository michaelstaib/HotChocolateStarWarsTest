using System;
using System.Collections.Generic;
using StarWars.Data;
using StarWars.Models;

namespace StarWars
{
    public class Subscription
    {
        private readonly ReviewRepository _repository;

        public Subscription(ReviewRepository repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<Review> OnReview(Episode episode)
        {
            return _repository.GetReviews(episode);
        }
    }
}
