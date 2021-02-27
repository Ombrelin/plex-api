namespace Plex.Api
{
    using System;
    using System.Collections.Generic;
    using Api;
    using Automapper;
    using PlexModels.Server;

    public class Server
    {
        private readonly IApiService apiService;
        private readonly IPlexClient plexClient;

        public Server(IApiService apiService, IPlexClient plexClient, string authToken, string serverUrl)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new ArgumentNullException(nameof(authToken));
            }

            if (string.IsNullOrEmpty(serverUrl))
            {
                throw new ArgumentNullException(nameof(serverUrl));
            }

            this.apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            this.plexClient = plexClient ?? throw new ArgumentNullException(nameof(plexClient));

            //Connect to server and populate
            var server = plexClient.GetPlexServerInfo(authToken, serverUrl).Result;
            this.HostUrl = serverUrl;
            this.AccessToken = authToken;
            ObjectMapper.Mapper.Map(server, this);
        }

        private string HostUrl { get; }
        private string AccessToken { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// True if Server allows camera upload.
        /// </summary>
        public bool AllowCameraUpload { get; set; }

        /// <summary>
        /// True if Server allows channel access (iTunes?).
        /// </summary>
        public bool AllowChannelAccess { get; set; }

        /// <summary>
        /// True is Server allows sharing.
        /// </summary>
        public bool AllowSharing { get; set; }

        /// <summary>
        /// True is Server allows sync.
        /// </summary>
        public bool AllowSync { get; set; }

        /// <summary>
        /// True if Server allows TV Tuners
        /// </summary>
        public bool AllowTuners { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool BackgroundProcessing { get; set; }

        /// <summary>
        /// True if Server has an HTTPS certificate.
        /// </summary>
        public bool Certificate { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool CompanionProxy { get; set; }

        /// <summary>
        /// Country Code of Server
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public string Diagnostics { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool EventStream { get; set; }

        /// <summary>
        /// Human friendly name for this server.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// True if Hub Search https://www.plex.tv/blog/seek-plex-shall-find-leveling-web-app is enabled.
        /// I believe this is enabled for everyone
        /// </summary>
        public bool HubSearch { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool ItemClusters { get; set; }

        /// <summary>
        /// True if Server supports Live Tv
        /// </summary>
        public int Livetv { get; set; }

        /// <summary>
        /// Unique ID for this server (looks like an md5).
        /// </summary>
        public string MachineIdentifier { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool MediaProviders { get; set; }

        /// <summary>
        /// True if multiusers https://support.plex.tv/hc/en-us/articles/200250367-Multi-User-Support are enabled.
        /// </summary>
        public bool Multiuser { get; set; }

        /// <summary>
        /// Unknown (True if logged into myPlex?).
        /// </summary>
        public bool MyPlex { get; set; }

        /// <summary>
        /// Unknown (ex: mapped).
        /// </summary>
        public string MyPlexMappingState { get; set; }

        /// <summary>
        /// Unknown (ex: ok).
        /// </summary>
        public string MyPlexSigninState { get; set; }

        /// <summary>
        /// True if you have a myPlex subscription.
        /// </summary>
        public bool MyPlexSubscription { get; set; }

        /// <summary>
        /// Email address if signed into myPlex (user@example.com)
        /// </summary>
        public string MyPlexUsername { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public int OfflineTranscode { get; set; }

        /// <summary>
        /// List of features allowed by the server owner. This may be based
        /// on your PlexPass subscription. Features include: camera_upload, cloudsync,
        /// content_filter, dvr, hardware_transcoding, home, lyrics, music_videos, pass,
        /// photo_autotags, premium_music_metadata, session_bandwidth_restrictions, sync,
        /// trailers, webhooks (and maybe more).
        /// </summary>
        public string OwnerFeatures { get; set; }

        /// <summary>
        /// True if photo auto-tagging https://support.plex.tv/hc/en-us/articles/234976627-Auto-Tagging-of-Photos is enabled.
        /// </summary>
        public bool PhotoAutoTag { get; set; }

        /// <summary>
        /// Platform the server is hosted on (ex: Linux)
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Platform version (ex: '6.1 (Build 7601)', '4.4.0-59-generic').
        /// </summary>
        public string PlatformVersion { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool PluginHost { get; set; }

        /// <summary>
        /// True if Server Push Notifications are enabled
        /// </summary>
        public bool PushNotifications { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool ReadOnlyLibraries { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool RequestParametersInCookie { get; set; }

        /// <summary>
        /// Current Streaming Brain Abr https://www.plex.tv/blog/mcstreamy-brain-take-world-two-easy-steps version.
        /// </summary>
        public int StreamingBrainAbrVersion { get; set; }

        /// <summary>
        /// Current Streaming Brain https://www.plex.tv/blog/mcstreamy-brain-take-world-two-easy-steps version.
        /// </summary>
        public int StreamingBrainVersion { get; set; }

        /// <summary>
        /// True if syncing to a device https://support.plex.tv/hc/en-us/articles/201053678-Sync-Media-to-a-Device is enabled.
        /// </summary>
        public bool Sync { get; set; }

        /// <summary>
        /// Number of active video transcoding sessions.
        /// </summary>
        public int TranscoderActiveVideoSessions { get; set; }

        /// <summary>
        /// True if audio transcoding audio is available.
        /// </summary>
        public bool TranscoderAudio { get; set; }

        /// <summary>
        /// True if audio transcoding lyrics is available.
        /// </summary>
        public bool TranscoderLyrics { get; set; }

        /// <summary>
        /// True if audio transcoding photos is available.
        /// </summary>
        public bool TranscoderPhoto { get; set; }

        /// <summary>
        /// True if audio transcoding subtitles is available.
        /// </summary>
        public bool TranscoderSubtitles { get; set; }

        /// <summary>
        /// True if audio transcoding video is available.
        /// </summary>
        public bool TranscoderVideo { get; set; }

        /// <summary>
        /// List of video bitrates.
        /// </summary>
        public string TranscoderVideoBitrates { get; set; }

        /// <summary>
        /// List of video qualities.
        /// </summary>
        public string TranscoderVideoQualities { get; set; }

        /// <summary>
        /// List of video resolutions.
        /// </summary>
        public string TranscoderVideoResolutions { get; set; }

        /// <summary>
        /// Datetime the server was updated.
        /// </summary>
        public int UpdatedAt { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool Updater { get; set; }

        /// <summary>
        /// Current Plex version (ex: 1.3.2.3112-1751929)
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// True if voice search is enabled. (is this Google Voice search?)
        /// </summary>
        public bool VoiceSearch { get; set; }

        /// <summary>
        /// File Directories on Server
        /// </summary>
        public List<PlexServerDirectory> Directories { get; set; }

        /// <summary>
        /// Get Server Library
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object GetLibrary()
        {
            var library = this.plexClient.GetLibrarySectionsAsync(this.HostUrl, this.AccessToken);
            return library;
        }
    }
}