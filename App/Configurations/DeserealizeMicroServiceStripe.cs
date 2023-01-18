namespace App.Configurations {
    public class DeserealizeMicroServiceStripe {
        public TokenMicroservice token { get; set; }
    }
    public class TokenMicroservice {
        public string accessToken { get; set; }
    }

    public class GerenciaNetDeserealizeAuth {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
    }
}