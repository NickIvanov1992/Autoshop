using Shop.Web.Models;
using System.Text;

namespace Shop.Web
{
    public static class SessionExtensions
    {
        private const string key = "Favorites";
        public static void Set (this ISession session,Favorites value)
        {
            if (value == null)
                return;
            using (var stream = new MemoryStream())
                using(var writer = new BinaryWriter(stream, Encoding.UTF8,true))
            {
                writer.Write(value.OrderId);
                writer.Write(value.TotalCount);
                writer.Write(value.TotalPrice);

                session.Set(key, stream.ToArray());
            }
        }

        public static bool TryGetFavorites(this ISession session, out Favorites value)
        {
            if (session.TryGetValue(key, out byte[] buffer))
            {
                using (var stream = new MemoryStream(buffer))
                    using(var reader = new BinaryReader(stream,Encoding.UTF8,true))
                {
                    var orderId = reader.ReadInt32();
                    var totalCount = reader.ReadInt32();
                    var totalPrice = reader.ReadDecimal();

                    value = new Favorites(orderId)
                    {
                        TotalPrice = totalPrice,
                        TotalCount = totalCount,

                    };

                    
                    return true;
                }   
            }
            value = null;
            return false;
        }

        
    }

    
}
