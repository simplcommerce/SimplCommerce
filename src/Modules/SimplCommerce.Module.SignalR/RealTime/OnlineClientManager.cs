using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using SimplCommerce.Infrastructure.Extensions;

namespace SimplCommerce.Module.SignalR.RealTime
{
    public class OnlineClientManager<T> : OnlineClientManager, IOnlineClientManager<T>
    {

    }

    /// <summary>
    /// Implements <see cref="IOnlineClientManager"/>.
    /// </summary>
    public class OnlineClientManager : IOnlineClientManager
    {
        public event EventHandler<OnlineClientEventArgs> ClientConnected;
        public event EventHandler<OnlineClientEventArgs> ClientDisconnected;
        public event EventHandler<OnlineUserEventArgs> UserConnected;
        public event EventHandler<OnlineUserEventArgs> UserDisconnected;

        /// <summary>
        /// Online clients.
        /// </summary>
        protected ConcurrentDictionary<string, IOnlineClient> Clients { get; }

        protected readonly object SyncObj = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="OnlineClientManager"/> class.
        /// </summary>
        public OnlineClientManager()
        {
            Clients = new ConcurrentDictionary<string, IOnlineClient>();
        }

        /// <inheritdoc />
        public virtual void Add(IOnlineClient client)
        {
            lock (SyncObj)
            {
                var userWasAlreadyOnline = false;
                var userId = client.UserId;

                if (userId != null)
                {
                    userWasAlreadyOnline = this.IsOnline(userId.Value);
                }

                Clients[client.ConnectionId] = client;

                ClientConnected?.Invoke(this, new OnlineClientEventArgs(client));

                if (userId != null && !userWasAlreadyOnline)
                {
                    UserConnected?.Invoke(this, new OnlineUserEventArgs(userId.Value, client));
                }
            }
        }

        /// <inheritdoc />
        public virtual bool Remove(string connectionId)
        {
            lock (SyncObj)
            {
                var isRemoved = Clients.TryRemove(connectionId, out var client);

                if (isRemoved)
                {
                    var userId = client.UserId;

                    if (userId != null && !this.IsOnline(userId.Value))
                    {
                        UserDisconnected?.Invoke(this, new OnlineUserEventArgs(userId.Value, client));
                    }

                    ClientDisconnected?.Invoke(this, new OnlineClientEventArgs(client));
                }

                return isRemoved;
            }
        }

        /// <inheritdoc />
        public virtual bool Remove(IOnlineClient client)
        {
            return Remove(client.ConnectionId);
        }

        /// <inheritdoc />
        public virtual IOnlineClient GetByConnectionIdOrNull(string connectionId)
        {
            lock (SyncObj)
            {
                return Clients.GetOrDefault(connectionId);
            }
        }

        /// <inheritdoc />
        public virtual IReadOnlyList<IOnlineClient> GetAllClients()
        {
            lock (SyncObj)
            {
                return Clients.Values.ToImmutableList();
            }
        }

        /// <inheritdoc />
        public virtual IReadOnlyList<IOnlineClient> GetAllByUserId(long userId)
        {
            return GetAllClients().Where(c => c.UserId == userId).ToImmutableList();
        }

        /// <inheritdoc />
        public virtual bool IsOnline(long userId)
        {
            return GetAllByUserId(userId).Any();
        }
    }
}
