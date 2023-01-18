namespace App.Configurations {
    public class SettingsApp {
        public MicroServiceStripe MicroServiceStripe { get; set; }
        public AwsS3 AwsS3 { get; set; }
        public GerenciaNet GerenciaNet { get; set; }
    }
    public class MicroServiceStripe {
        public string email { get; set; }
        public string password { get; set; }
        public string Url { get; set; }

    }
    public class AwsS3 {
        public string KeyS3 { get; set; }
        public string SecretKeyS3 { get; set; }
        public string BucketName { get; set; }
        public string BaseUrlS3 { get; set; }

    }

    public class GerenciaNet {

        public string GerenciaUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string KeyPaymentPix { get; set; }

    }





}
