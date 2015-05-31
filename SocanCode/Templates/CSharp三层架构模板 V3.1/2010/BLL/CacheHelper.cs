using System.Collections;
using System.Web.Caching;

namespace System.Web
{
    public class CacheHelper
    {
        /// <summary>
        /// 获取缓存
        /// </summary>
        public static object GetCache(string key)
        {
            return HttpRuntime.Cache[key];
        }

        /// <summary>
        /// 建立缓存
        /// </summary>
        public static object TryAddCache(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemovedCallback)
        {
            if (GetCache(key) == null && value != null)
                return HttpRuntime.Cache.Add(key, value, dependencies, absoluteExpiration, slidingExpiration, priority, onRemovedCallback);
            else
                return null;
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        public static object TryRemoveCache(string key)
        {
            if (GetCache(key) != null)
                return HttpRuntime.Cache.Remove(key);
            else
                return null;
        }

        /// <summary>
        /// 移除键中带某关键字的缓存
        /// </summary>
        public static void RemoveMultiCache(string keyInclude)
        {
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                if (string.IsNullOrEmpty(keyInclude))
                {
                    HttpRuntime.Cache.Remove(CacheEnum.Key.ToString());
                    continue;
                }

                if (CacheEnum.Key.ToString().IndexOf(keyInclude) >= 0)
                    HttpRuntime.Cache.Remove(CacheEnum.Key.ToString());
            }
        }

        /// <summary>
        /// 移除所有缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            RemoveMultiCache(null);
        }
    }
}
