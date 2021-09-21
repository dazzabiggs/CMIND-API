using KB.AUTH.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.AUTH.Middleware.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<Client> WithoutSecrets(this IEnumerable<Client> clients)
        {
            if (clients == null) return null;

            return clients.Select(x => x.WithoutSecrets());
        }

        public static Client WithoutSecrets(this Client client)
        {
            if (client == null) return null;

            client.ClientID = null;
            client.ClientSecret = null;

            return client;
        }
    }
}
