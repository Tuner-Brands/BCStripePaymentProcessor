using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365BCConnectorAPIGear
{
    public class TokenManager
    {
        private static readonly object _lock = new object();
        private static TokenManager _instance;

        private string _bearerToken;
        private DateTime _tokenExpirationTime;

        // Private constructor to prevent instantiation outside the class
        private TokenManager() { }

        // Public property to access the instance
        public static TokenManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TokenManager();
                        }
                    }
                }
                return _instance;
            }
        }

        // Properties for BearerToken and TokenExpirationTime
        public string BearerToken
        {
            get => _bearerToken;
            set => _bearerToken = value;
        }

        public DateTime TokenExpirationTime
        {
            get => _tokenExpirationTime;
            set => _tokenExpirationTime = value;
        }
    }

}
