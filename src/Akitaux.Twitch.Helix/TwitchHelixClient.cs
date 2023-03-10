using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Akitaux.Twitch.Helix.Entities;
using Akitaux.Twitch.Helix.Requests;
using Akitaux.Twitch.Rest;
using RestEase;
using Voltaic;

namespace Akitaux.Twitch.Helix
{
    public class TwitchHelixClient : IHelixRestApi, IDisposable
    {
        public static string Version { get; } =
            typeof(TwitchHelixClient).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(TwitchHelixClient).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";

        private readonly IHelixRestApi _api;
        
        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public Utf8String ClientId { get => _api.ClientId; set => _api.ClientId = value; }

        public TwitchJsonSerializer JsonSerializer { get; }

        public TwitchHelixClient(TwitchJsonSerializer serializer = null, IRateLimiter rateLimiter = null)
            : this("https://api.twitch.tv/helix", serializer, rateLimiter) { }
        public TwitchHelixClient(string url, TwitchJsonSerializer serializer = null, IRateLimiter rateLimiter = null)
        {
            JsonSerializer = serializer ?? new TwitchJsonSerializer();
            rateLimiter = rateLimiter ?? new DefaultRateLimiter();

            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"Akitaux/v{Version} (https://github.com/Akitaux/Twitch)");

            _api = RestClient.For<IHelixRestApi>(new WumpusRequester(httpClient, JsonSerializer, rateLimiter));
        }
        public virtual void Dispose() => _api.Dispose();

        //  Analytics

        public Task<TwitchResponse<ExtensionAnalyticReport>> GetExtensionAnalyticsAsync(GetExtensionAnalyticsParams args)
        {
            args.Validate();
            return _api.GetExtensionAnalyticsAsync(args);
        }
        public Task<TwitchResponse<GameAnalyticReport>> GetGameAnalyticsAsync(GetGameAnalyticsParams args)
        {
            args.Validate();
            return _api.GetGameAnalyticsAsync(args);
        }
        
        // Bits

        public Task<TwitchResponse<BitsLeader>> GetBitsLeaderboardAsync(GetBitsLeaderboardParams args)
        {
            args.Validate();
            return _api.GetBitsLeaderboardAsync(args);
        }

        // Clips

        public Task<TwitchResponse<Clip>> CreateClipAsync(CreateClipParams args)
        {
            return _api.CreateClipAsync(args);
        }
        public Task<TwitchResponse<Clip>> GetClipsAsync(GetClipsParams args)
        {
            args.Validate();
            return _api.GetClipsAsync(args);
        }

        // Entitlements

        public Task<TwitchResponse<GrantsUploadUrl>> CreateGrantsUploadUrlAsync(CreateGrantsUploadUrlParams args)
        {
            args.Validate();
            return _api.CreateGrantsUploadUrlAsync(args);
        }

        public Task<EntitlementsResponse<EntitlementCodeStatus>> GetCodeStatusAsync(CodeStatusParams args)
        {
            args.Validate();
            return _api.GetCodeStatusAsync(args);
        }

        public Task<EntitlementsResponse<EntitlementCodeStatus>> RedeemCodeAsync(CodeStatusParams args)
        {
            args.Validate();
            return _api.RedeemCodeAsync(args);
        }
        
        // Games

        public Task<TwitchResponse<Game>> GetTopGamesAsync(GetTopGamesParams args = null)
        {
            args?.Validate();
            return _api.GetTopGamesAsync(args);
        }
        public Task<TwitchResponse<Game>> GetGamesAsync(GetGamesParams args)
        {
            args.Validate();
            return _api.GetGamesAsync(args);
        }

        // Streams

        public Task<TwitchResponse<Stream>> GetStreamsAsync(GetStreamsParams args = null)
        {
            args?.Validate();
            return _api.GetStreamsAsync(args);
        }

        public Task<TwitchResponse<StreamMarker>> CreateStreamMarkerAsync(CreateStreamMarkerParams args)
        {
            args.Validate();
            return _api.CreateStreamMarkerAsync(args);
        }

        public Task<TwitchResponse<Stream>> GetStreamMarkersAsync(GetStreamMarkersParams args)
        {
            args.Validate();
            return _api.GetStreamMarkersAsync(args);
        }

        // Subscriptions

        public Task<TwitchResponse<Subscription>> GetSubscriptionsAsync(GetSubscriptionsParams args)
        {
            args.Validate();
            return _api.GetSubscriptionsAsync(args);
        }

        // Tags

        public Task<TwitchResponse<Tag>> GetTagsAsync(GetTagsParams args)
        {
            args.Validate();
            return _api.GetTagsAsync(args);
        }

        public Task<TwitchResponse<Tag>> GetStreamTagsAsync(ulong broadcasterId)
        {
            return _api.GetStreamTagsAsync(broadcasterId);
        }

        public Task<TwitchResponse<Tag>> PutStreamTagsAsync(ulong broadcasterId, params Utf8String[] tagIds)
        {
            return _api.PutStreamTagsAsync(broadcasterId, tagIds);
        }

        // Users

        public Task<TwitchResponse<User>> GetUsersAsync(GetUsersParams args)
        {
            args.Validate();
            return _api.GetUsersAsync(args);
        }

        public Task<TwitchResponse<User>> PutUserAsync(Utf8String description)
        {
            return _api.PutUserAsync(description);
        }

        public Task<TwitchResponse<Follow>> GetFollowsAsync(GetFollowsParams args)
        {
            args.Validate();
            return _api.GetFollowsAsync(args);
        }

        public Task<TwitchResponse<Extension>> GetMyExtensionsAsync()
        {
            return _api.GetMyExtensionsAsync();
        }

        public Task<TwitchResponse<ExtensionLocation>> GetUserActiveExtensionsAsync(ulong userId)
        {
            return _api.GetUserActiveExtensionsAsync(userId);
        }

        public Task<TwitchResponse<ExtensionLocation>> PutUserExtensionsAsync()
        {
            return _api.PutUserExtensionsAsync();
        }

        // Videos

        public Task<TwitchResponse<Video>> GetVideosAsync(GetVideoParams args)
        {
            args.Validate();
            return _api.GetVideosAsync(args);
        }

        // Webhooks

        public Task<TwitchResponse<WebhookSubscription>> GetWebhookSubscriptionsAsync(GetWebhookSubscriptionsAsync args)
        {
            args.Validate();
            return _api.GetWebhookSubscriptionsAsync(args);
        }

        public Task PostWebhookAsync(PostWebhookParams args)
        {
            args.Validate();
            return _api.PostWebhookAsync(args);
        }
    }
}
