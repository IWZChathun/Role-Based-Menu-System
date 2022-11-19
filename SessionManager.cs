using System.Text;

namespace RBMS
{
    public class SessionManager
    {
        public byte[] Salt { get; } = Encoding.ASCII.GetBytes("!bnP_{n<|Ii_/!VCW4nT8,xl8@]s|THoVDGYb7zoeUN8 = IZj / Ixk ? W * Kjf, Yfa");

        public string Audiance { get; } = "rbms";

        public string Issuer { get; } = "com.rbms";
    }
}
