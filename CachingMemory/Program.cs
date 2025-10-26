using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;


namespace CachingMemory
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cache = new MemoryCache(new MemoryCacheOptions());
            string key = "currentTime";
            Console.WriteLine(GetTimeFromCache(cache,key));
            Console.WriteLine(GetTimeFromCache(cache, key));
            Console.WriteLine("5 saniye bekleniyor...");
            Thread.Sleep(5000);
            Console.WriteLine(GetTimeFromCache(cache, key));
        }
        static string GetTimeFromCache(IMemoryCache cache ,string key)
        {
            if(!cache.TryGetValue(key,out string cachedTime))
            {
                cachedTime = DateTime.Now.ToString("HH:mm:ss");
                cache.Set(key, cachedTime, TimeSpan.FromSeconds(3)); //3 saniye cache de kalacak eğer sınırsız istiyorsak TimeSpan.FromSeconds(3) bu kısmı silmemiz yeterli

                return $"cache e eklendi: {cachedTime}";
            }
            else
            {
                 return $"cache den alındı: {cachedTime}";
            }
        }
    }
}
