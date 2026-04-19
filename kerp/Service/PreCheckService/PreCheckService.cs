using kerp.Hubs.IncidentHub;
using kerp.Prosedur.Canban;
using kerp.Prosedur.PreCheck.Document;
using kerp.Prosedur.PreCheck.Pre;
using kerp.Prosedur.PreCheck.Record;
using kerp.Prosedur.Users;
using kerp.Repository.CanbanRepository;
using kerp.Repository.PreCheckRepository;
using kerp.Repository.UserRepository;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Service.PreCheckService
{
    public class PreCheckService(
        IPreCheckRepository preCheckRepository,
        ICanbanRepository canbanRepository,
        IHubContext<IncidentHub> hubContext,
        IUserRepository userRepository) : IPreCheckService
    {
        private readonly IPreCheckRepository _preCheckRepository = preCheckRepository;
        private readonly ICanbanRepository _canbanRepository = canbanRepository;
        private readonly IHubContext<IncidentHub> _hubContext = hubContext;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<int> PreCheckInsert(List<PreCheckInsert> request)
        {
            List<PreCheckSelect>? result = _preCheckRepository.PreCheckInsert(request);

            if (result != null && result.Count > 0)
            {
                List<CanbanCardHub> hubCards = [];

                foreach (PreCheckSelect item in result)
                {
                    CanbanCardHub? card = _canbanRepository.CanbanCardHub(item.Id, 3);
                    hubCards.Add(card!);
                }

                if (hubCards.Count > 0)
                {
                    await _hubContext.Clients.All.SendAsync("IncidentInserted", hubCards);
                    await _hubContext.Clients.All.SendAsync("NotificationDesktop", result);
                    await SendAndroidPushNotifications(result);
                }

                return 1;
            }

            return 0;
        }
        public async Task<int> PreCheckDocumentInsert(PreCheckDocumentInsert request)
        {
            PreCheckSelect? result = _preCheckRepository.PreCheckDocumentInsert(request);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PreCheckInfo", result);
                return 1;
            }

            return 0;
        }

        public async Task<int> PreCheckDocumentUpdate(PreCheckDocumentUpdate request)
        {
            PreCheckSelect? result = _preCheckRepository.PreCheckDocumentUpdate(request);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PreCheckInfo", result);
                return 1;
            }

            return 0;
        }

        public async Task<int> PreCheckDocumentStatus(PreCheckDocumentStatus request)
        {
            PreCheckSelect? result = _preCheckRepository.PreCheckDocumentStatus(request);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PreCheckInfo", result);
                return 1;
            }

            return 0;
        }
        public async Task<int> PreCheckRecordInsert(PreCheckRecordInsert request)
        {
            PreCheckSelect? result = _preCheckRepository.PreCheckRecordInsert(request);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PreCheckInfo", result);
                return 1;
            }

            return 0;
        }

        public async Task<int> PreCheckRecordUpdate(PreCheckRecordUpdate request)
        {
            PreCheckSelect? result = _preCheckRepository.PreCheckRecordUpdate(request);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PreCheckInfo", result);
                return 1;
            }

            return 0;
        }

        public async Task<int> PreCheckRecordStatus(PreCheckRecordStatus request)
        {
            PreCheckSelect? result = _preCheckRepository.PreCheckRecordStatus(request);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PreCheckInfo", result);
                return 1;
            }

            return 0;
        }

        private async Task SendAndroidPushNotifications(List<PreCheckSelect> items)
        {
            NotificationService notificationService = new();

            foreach (PreCheckSelect item in items)
            {
                int workOrderTypeId = item.PreCheckWorkOrderSelect?.FirstOrDefault()?.WorkOrderTypeId ?? 0;
                int structureId = item.PreCheckStructureSelect?.FirstOrDefault()?.StructureId ?? 0;

                List<UserFcmToken> userTokens = await _userRepository.GetUserFcmTokens(
                    workOrderTypeId,
                    structureId,
                    item.CreateUserId
                );

                if (userTokens.Any())
                {
                    List<string> tokens = [.. userTokens.Select(u => u.FcmToken)];
                    await notificationService.SendAndroidNotificationAsync(tokens, item);
                }
            }
        }

        public async Task<int> Accepted(PreCheckControllerLifeCircle request)
        {
            PreCheckSelect? result = _preCheckRepository.Accepted(request);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 3);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("PreCheckInfo", result);
                return 1;
            }

            return 0;
        }

        public async Task<int> InReview(PreCheckControllerLifeCircle request)
        {
            PreCheckSelect? result = _preCheckRepository.InReview(request);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 3);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("PreCheckInfo", result);
                return 1;
            }

            return 0;
        }

        public async Task<int> Approved(PreCheckControllerLifeCircle request)
        {
            PreCheckSelect? result = _preCheckRepository.Approved(request);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 3);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("PreCheckInfo", result);
                return 1;
            }

            return 0;
        }

        public async Task<int> Closed(PreCheckControllerLifeCircle request)
        {
            PreCheckSelect? result = _preCheckRepository.Closed(request);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 3);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("PreCheckInfo", result);
                return 1;
            }

            return 0;
        }
    }
}