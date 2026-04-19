using FirebaseAdmin.Messaging;
using Newtonsoft.Json;

namespace kerp.Service
{
    public class NotificationService
    {
        private readonly FirebaseMessaging _firebaseMessaging;

        public NotificationService()
        {
            _firebaseMessaging = FirebaseMessaging.DefaultInstance;
        }

        public async Task SendAndroidNotificationAsync<T>(
            List<string> fcmTokens,
            T data

            )
        {
            if (fcmTokens == null || !fcmTokens.Any())
            {
                return;
            }

            string jsonData = JsonConvert.SerializeObject(data);
            string notificationType = typeof(T).Name;

            MulticastMessage message = new()
            {
                Tokens = fcmTokens,
                Data = new Dictionary<string, string>
                {
                    { "type", notificationType },
                    { "data", jsonData }
                },
                Android = new AndroidConfig
                {
                    Priority = Priority.High,
                }
            };

            BatchResponse response = await _firebaseMessaging.SendEachForMulticastAsync(message);
            Console.WriteLine($"Push sent: {response.SuccessCount} success, {response.FailureCount} failed");
        }
    }
}