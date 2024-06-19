namespace CPT231_Assignment06_LeviNoell_Baba.Models
{
    public class MagicCookies
    {
        //constants for the cookie key and delimiter
        private const string MagicsKey = "mymagics";
        private const string Delimiter = "-";
        //request and response cookie collections for handling cookies
        private IRequestCookieCollection requestCookies { get; set; } = null!;
        private IResponseCookies responseCookies { get; set; } = null!;
        //
        public MagicCookies(IRequestCookieCollection cookies) 
        {
            requestCookies = cookies;
        }
        public MagicCookies(IResponseCookies cookies) 
        {
            responseCookies = cookies;
        }
        //method to nset magic ids in a cookie
        public void SetMyMagicIds(List<Magic> mymagics)
        {
            //extract magic ids from the list and convert them to strings
            List<string> ids = mymagics.Select(t => t.MagicId.ToString()).ToList();
            string idsString = String.Join(Delimiter, ids);//join the ids into a single string using the delimiter
            CookieOptions options = new CookieOptions { //set the exiration date
                Expires = DateTime.Now.AddDays(30) 
            };
            RemoveMyMagicIds();     // delete old cookie first
            responseCookies.Append(MagicsKey, idsString, options);//add new cookie
        }
        //method to get magic ids from a cookie
        public string[] GetMyMagicIds()
        {
            string cookie = requestCookies[MagicsKey] ?? String.Empty;//retrieve cookie string from the request cookies or an empty string
            if (string.IsNullOrEmpty(cookie))
                return Array.Empty<string>();   // empty string array
            else
                return cookie.Split(Delimiter);
        }      

        public void RemoveMyMagicIds()//method to remove magic ids cookie from the response
        {
            responseCookies.Delete(MagicsKey);
        }
    }
}
