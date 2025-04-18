using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace MyCookBookApi.Authentication
{

    public static class FirebaseLogin{
        private static bool isInitialized = false;

        public static void InitializeDatabase(){
            if(!isInitialized){
                FirebaseApp.Create(new AddOptions()
                {
                    Credential = GoogleCredential.FromFile("path-to-service-account.json"),
                });

                isInitialized = true; 
            }
        }

        public static Task<FirebaseToken> VerifyTokenAsync(string idToken)
        {
            try
            {
                FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
                return decodedToken;
            }
            catch (Exception)
            {
                // Handle invalid token
                return null;
            }
        }
    }
}
