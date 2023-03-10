using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetTopGamesParams : Rest.QueryMap
    {
        public Optional<int> First { get; set; }
        public Optional<Utf8String> After { get; set; }
        public Optional<Utf8String> Before { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (First.IsSpecified)
                dict["first"] = First.Value;
            if (After.IsSpecified)
                dict["after"] = After.Value;
            if (Before.IsSpecified)
                dict["before"] = Before.Value;
            return dict;
        }

        public void Validate()
        {
            if (First.IsSpecified)
            {
                Preconditions.AtLeast(First, 1, nameof(First));
                Preconditions.AtMost(First, 100, nameof(First));
            }
            if (After.IsSpecified)
                Preconditions.NotNullOrWhitespace(After.ToString(), nameof(After));
            if (Before.IsSpecified)
                Preconditions.NotNullOrWhitespace(Before.ToString(), nameof(Before));
        }
    }
}
