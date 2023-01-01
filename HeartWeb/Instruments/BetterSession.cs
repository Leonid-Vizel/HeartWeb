using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using System.Reflection;
using System.Text;

namespace HeartWeb.Instruments
{
    public static class BetterSession
    {
        public static void SetBoolean(this ISession session, string key, bool value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }
        public static bool? GetBoolean(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToBoolean(data, 0);
        }
        public static void SetDateTime(this ISession session, string key, DateTime value)
        {
            session.Set(key, BitConverter.GetBytes(value.ToBinary()));
        }
        public static DateTime? GetDateTime(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            long binaryValue = BitConverter.ToInt64(data, 0);
            return DateTime.FromBinary(binaryValue);
        }

        private static Func<bool> _trueFunc = () => true;
        private static BindingFlags _flags = BindingFlags.NonPublic | BindingFlags.Instance;
        private static TimeSpan _span0 = TimeSpan.Zero;
        private static TimeSpan _span6 = TimeSpan.FromHours(6);
        private static FieldInfo? _cacheGetter = typeof(DistributedSession).GetField("_cache", _flags);
        private static FieldInfo? _memoryCacheGetter = typeof(MemoryDistributedCache).GetField("_memCache", _flags);
        private static FieldInfo? _coherentStateGetter = typeof(MemoryCache).GetField("_coherentState", _flags);

        public static async Task EndSessionsByLogin(this ISession userSession, string userLogin, CancellationToken token = default)
        {
            if (_cacheGetter == null || _memoryCacheGetter == null || _coherentStateGetter == null)
            {
                return;
            }
            MemoryDistributedCache? cache = _cacheGetter.GetValue(userSession) as MemoryDistributedCache;
            if (cache == null)
            {
                return;
            }
            MemoryCache? memCache = _memoryCacheGetter.GetValue(cache) as MemoryCache;
            if (memCache == null)
            {
                return;
            }
            var coherentState = _coherentStateGetter.GetValue(memCache);
            if (coherentState == null)
            {
                return;
            }
            IDictionary? keyCollection = coherentState.GetType().GetProperty("EntriesCollection", _flags)?.GetValue(coherentState) as IDictionary;
            if (keyCollection == null)
            {
                return;
            }
            using (LoggerFactory factory = new LoggerFactory())
            {
                foreach (var key in keyCollection.Keys)
                {
                    string? keyValue = key?.ToString();
                    if (keyValue == null)
                    {
                        continue;
                    }
                    DistributedSessionStore store = new DistributedSessionStore(cache, factory);
                    ISession session = store.Create(keyValue, _span6, _span0, _trueFunc, false);
                    string? login = session.GetString("login");
                    if (login != null && login.Equals(userLogin))
                    {
                        session.Remove("login");
                        await session.CommitAsync(token);
                    }
                }
            }
        }
    }
}
