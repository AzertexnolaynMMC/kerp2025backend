using kerp.Hubs.IncidentHub;
using kerp.Prosedur.Canban;
using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.MachineIncident.Record;
using kerp.Prosedur.PMOrders;
using kerp.Prosedur.PMOrders.Asset;
using kerp.Prosedur.PMOrders.Assigness;
using kerp.Prosedur.PMOrders.Chat;
using kerp.Prosedur.PMOrders.CheckList;
using kerp.Prosedur.PMOrders.Doc;
using kerp.Prosedur.PMOrders.Material;
using kerp.Prosedur.PMOrders.Order;
using kerp.Prosedur.PMOrders.Record;
using kerp.Prosedur.Users;
using kerp.Repository.CanbanRepository;
using kerp.Repository.MachineIncidentRepository;
using kerp.Repository.PMOrdersRepository;
using kerp.Repository.UserRepository;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Service.PmOrderService
{
    public class PmOrderService(
          IPMOrdersRepository incidentRepository,
        ICanbanRepository canbanRepository,
        IHubContext<IncidentHub> hubContext, IUserRepository userRepository,
        IMachineIncidentRepository machineIncidentRepository
        ) : IPmOrderService
    {
        private readonly IPMOrdersRepository _incidentRepository = incidentRepository;
        private readonly ICanbanRepository _canbanRepository = canbanRepository;
        private readonly IHubContext<IncidentHub> _hubContext = hubContext;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMachineIncidentRepository _machineIncidentRepository = machineIncidentRepository;  // ✅ əlavə et
        public async Task<int> PMChecklistExecutionUpdate(List<PMChecklistExecutionUpdate> Id)
        {
            PMOrdersSelect result = _incidentRepository.PMChecklistExecutionUpdate(Id);
            if (result != null)
            {

                //  CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 2);
                // await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }
            return 0;
        }



        public async Task<int> PMOrderControllerLifeCrcyle(PMOrderControllerLifeCrcyle Id)
        {
            PMOrdersSelect result = _incidentRepository.PMOrderControllerLifeCrcyle(Id);
            if (result != null)
            {

                CanbanCardHub? card = _canbanRepository.CanbanCardHub(Id.Id, 2);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }
            return 0;


        }

        public async Task<int> PMOrderSend(PMOrderControllerLifeCrcyle Id)
        {
            PMOrdersSelect result = _incidentRepository.PMOrderSend(Id);
            if (result != null)
            {

                CanbanCardHub? card = _canbanRepository.CanbanCardHub(Id.Id, 2);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> PMRecordInsert(PMRecordInsert Id)
        {
            PMOrdersSelect result = _incidentRepository.PMRecordInsert(Id);
            if (result != null)
            {

                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> PMRecordStatus(PMRecordStatus Id)
        {
            PMOrdersSelect result = _incidentRepository.PMRecordStatus(Id);
            if (result != null)
            {

                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> PMRecordUpdate(PMRecordUpdate Id)
        {
            PMOrdersSelect result = _incidentRepository.PMRecordUpdate(Id);
            if (result != null)
            {

                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }
            return 0;
        }


        public async Task<int> PMDocumentsInsert(PMDocumentsInsert Id)
        {
            PMOrdersSelect result = _incidentRepository.PMDocumentsInsert(Id);
            if (result != null)
            {

                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> PMDocumentsStatus(PMDocumentsStatus Id)
        {
            PMOrdersSelect result = _incidentRepository.PMDocumentsStatus(Id);
            if (result != null)
            {

                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> PMDocumentsUpdate(PMDocumentsUpdate Id)
        {
            PMOrdersSelect result = _incidentRepository.PMDocumentsUpdate(Id);
            if (result != null)
            {

                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> PMMaterialInsert(PMMaterialInsert Id)
        {
            PMOrdersSelect result = _incidentRepository.PMMaterialInsert(Id);
            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);
                return 1;
            }
            return 0;
        }

        public async Task<int> PMMaterialUpdate(PMMaterialUpdate Id)
        {
            PMOrdersSelect result = _incidentRepository.PMMaterialUpdate(Id);
            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);
                return 1;
            }
            return 0;
        }

        public async Task<int> PMMaterialStatus(PMMaterialStatus Id)
        {
            PMOrdersSelect result = _incidentRepository.PMMaterialStatus(Id);
            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);
                return 1;
            }
            return 0;
        }

        public async Task<int> PMAssigneesStatus(PMAssigneesStatus Id)
        {
            PMOrdersSelect result = _incidentRepository.PMAssigneesStatus(Id);
            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);
                return 1;
            }
            return 0;
        }

        public async Task<int> PMAssigneesInsert(List<PMAssigneesInsert> Id)
        {
            PMOrdersSelect result = _incidentRepository.PMAssigneesInsert(Id);
            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);
                return 1;
            }
            return 0;
        }

        public async Task<int> PMChatInsert(PMChatInsert model)
        {
            // Repository-dən nəticəni al
            PMOrdersSelect? result = _incidentRepository.PMChatInsert(model);

            if (result != null)
            {
                // SignalR vasitəsilə frontend-ə göndər
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);
                return 1;
            }

            return 0;
        }

        public async Task<int> PMOrderConfirm(PMOrderControllerLifeCrcyle Id)
        {
            PMOrdersSelect result = _incidentRepository.PMOrderConfirm(Id);
            if (result != null)
            {

                CanbanCardHub? card = _canbanRepository.CanbanCardHub(Id.Id, 2);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> PMOrdersCreateCM(PMOrdersCreateCM model)
        {
            PMOrdersSelect result = _incidentRepository.PMOrdersCreateCM(model);
            if (result != null)
            {


                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                // 🔥 model.CreatedCmId ilə PMChecklistExecutionSelect.Id eyni olanı tap
                PMChecklistExecutionSelect? matchedExecution = result.PMChecklistExecutionSelect?
                    .FirstOrDefault(x => x.Id == model.PMChecklistExecutionId && x.CreatedCmId != null);

                if (matchedExecution != null)
                {

                    // 🔥 əvvəl incident record insert edirik
                    MachineIncidentRecordInsert record = new()
                    {
                        UserId = model.UserId,
                        MachineIncidentId = matchedExecution.CreatedCmId!.Value,
                        Title = $"Bu iş əmri, {result.Id} nömrəli PM iş əmri zamanı aparılan {matchedExecution.Id} nömrəli yoxlamaya əsasən açılıb."
                    };

                    _ = _machineIncidentRepository.MachineIncidentRecordInsert(record);
                    MachineIncidentSelectForBackEnd? incident =
                        _machineIncidentRepository.GetMachineIncidentForBackEnd(matchedExecution.CreatedCmId!.Value);

                    if (incident != null)
                    {
                        CanbanCardHub? card = _canbanRepository.CanbanCardHub(incident.Id, 1);
                        await _hubContext.Clients.All.SendAsync("IncidentInserted", new[] { card });
                        await _hubContext.Clients.All.SendAsync("NotificationDesktop", new[] { incident });
                        await SendAndroidPushNotifications([incident]);
                    }
                }

                return 1;
            }
            return 0;
        }


        private async Task SendAndroidPushNotifications(List<MachineIncidentSelectForBackEnd> incidents)
        {
            NotificationService notificationService = new();
            foreach (MachineIncidentSelectForBackEnd incident in incidents)
            {
                List<UserFcmToken> userTokens = await _userRepository.GetUserFcmTokens(
                    incident.WorkOrderTypeId,
                    incident.StructureId,
                    incident.CreateUserId
                );

                if (userTokens.Count != 0)
                {
                    List<string> tokens = [.. userTokens.Select(u => u.FcmToken)];
                    await notificationService.SendAndroidNotificationAsync(tokens, incident);
                }
            }
        }

        public async Task<int> PMOrderClosed(PMOrderClosed model)
        {
            PMOrdersSelect? result = _incidentRepository.PMOrderClosed(model);

            if (result != null)
            {
                // Canban update (PM order üçün type = 2 istifadə edirsən artıq)
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(
                    model.PMOrderControllerLifeCrcyle!.Id, 2);

                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);

                // PM order update push
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }

            return 0;
        }

        public async Task<int> PMOrderAssetInsert(List<PMOrderAssetInsert> model)
        {
            PMOrdersSelect? result = _incidentRepository.PMOrderAssetInsert(model);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);
                return 1;
            }

            return 0;
        }
        public async Task<int> PMOrderAssetStatus(PMOrderAssetStatus model)
        {
            PMOrdersSelect? result = _incidentRepository.PMOrderAssetStatus(model);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("PMOrdersHub", result);

                return 1;
            }

            return 0;
        }
    }
}
