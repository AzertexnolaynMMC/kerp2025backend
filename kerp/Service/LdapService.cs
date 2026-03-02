using System.DirectoryServices.Protocols;
using System.Net;

namespace kerp.Service
{
    public class LdapService
    {


        public bool Authenticate(string username, string password)
        {
            string[] servers = new[]
            {
        "gtcdc01.corp.gtc.az",
        "gtcdc02.corp.gct.az",
        "172.16.50.1",
        "172.16.50.5"
    };

            foreach (string? server in servers)
            {
                try
                {
                    LdapDirectoryIdentifier identifier = new(server, 636);
                    using LdapConnection connection = new(identifier)
                    {
                        AuthType = AuthType.Negotiate
                    };

                    connection.SessionOptions.ProtocolVersion = 3;
                    connection.SessionOptions.SecureSocketLayer = true;
                    connection.SessionOptions.ReferralChasing = ReferralChasingOptions.None;

                    // ⚠️ TEST ÜÇÜN (sertifikat check-i söndürür)
                    connection.SessionOptions.VerifyServerCertificate =
                        (conn, cert) => true;

                    connection.Credential = new NetworkCredential(
                        $"{username}@corp.gtc.az", // 🔴 VACİB
                        password
                    );

                    connection.Bind(); // 🔥 BURANI KEÇDİSƏ → LOGIN OK

                    return true;
                }
                catch (LdapException)
                {
                    // istəsən ex.ErrorCode logla
                    continue;
                }
            }

            return false;
        }



    }
}
