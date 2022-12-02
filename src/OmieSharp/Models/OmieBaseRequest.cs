namespace OmieSharp.Models
{
    internal class OmieBaseRequest<T>
    {
        public string call { get; private set; }
        public string app_key { get; private set; }
        public string app_secret { get; private set; }
        public List<T> param { get; private set; }

        public OmieBaseRequest(string call, string app_key, string app_secret, T param)
        {
            this.call = call;
            this.app_key = app_key;
            this.app_secret = app_secret;
            this.param = new List<T>() { param };
        }
    }
}
