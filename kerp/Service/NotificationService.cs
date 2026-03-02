using FirebaseAdmin.Messaging;
using kerp.Prosedur.MachineIncident.Incident;
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

        public async Task SendAndroidNotificationAsync(
            List<string> fcmTokens,
            MachineIncidentSelectForBackEnd incident)
        {
            if (fcmTokens == null || !fcmTokens.Any())
            {
                return;
            }

            string jsonData = JsonConvert.SerializeObject(incident);

            MulticastMessage message = new()
            {
                Tokens = fcmTokens,
                Data = new Dictionary<string, string>
                {
                    { "type", "new_incident" },
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