using System;
using System.Text;


namespace hey_url_challenge_code_dotnet.Services
{
    public class ShortUrlService : IShortUrlService
    {
        public string GetUrl()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int len = 5;

            Random rnd = new Random();
            StringBuilder b = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                b.Append(chars[rnd.Next(chars.Length)]);
            }

            return b.ToString();
        }
    }
}
