using System;
using System.Collections.Generic;
using SimplCommerce.Infrastructure.Extensions;

namespace SimplCommerce.Module.SignalR.RealTime
{
    /// <summary>
    /// Implements <see cref="IOnlineClient"/>.
    /// </summary>
    [Serializable]
    public class OnlineClient : IOnlineClient
    {
        /// <summary>
        /// Unique connection Id for this client.
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// User Id.
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// Connection establishment time for this client.
        /// </summary>
        public DateTime ConnectTime { get; set; }

        /// <summary>
        /// Shortcut to set/get <see cref="Properties"/>.
        /// </summary>
        public object this[string key]
        {
            get => Properties[key];
            set => Properties[key] = value;
        }

        /// <summary>
        /// Can be used to add custom properties for this client.
        /// </summary>
        public Dictionary<string, object> Properties
        {
            get => _properties;
            set => _properties = value ?? throw new ArgumentNullException(nameof(value));
        }
        private Dictionary<string, object> _properties;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineClient"/> class.
        /// </summary>
        public OnlineClient()
        {
            ConnectTime = DateTime.Now;
            Properties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineClient"/> class.
        /// </summary>
        public OnlineClient(string connectionId, long? userId)
            : this()
        {
            ConnectionId = connectionId;
            UserId = userId;
        }

        public override string ToString()
        {
            return this.ToJsonString();
        }
    }
}
