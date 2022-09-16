using System.Text.Json;

namespace AlbumShop.Infrastracture{

    public static class SessionExtensions{
        
        public static void SetJson(this ISession session, string  key, object val){
            session.SetString(key, JsonSerializer.Serialize(val));
        }

        public static T? GetJson<T>(this ISession session, string key){
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}