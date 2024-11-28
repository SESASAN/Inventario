namespace lib_utilidades
{
    public class EncodingHelper
    {
        public static string ToString(byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        public static byte[] ToBytes(string data)
        {
            return Convert.FromBase64String(data);
        }
    }
}