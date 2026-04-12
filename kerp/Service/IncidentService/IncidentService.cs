using kerp.Hubs.IncidentHub;
using kerp.Prosedur.Canban;
using kerp.Prosedur.MachineIncident.Document;
using kerp.Prosedur.MachineIncident.Event;
using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.MachineIncident.MachineIncidentAssistant;
using kerp.Prosedur.MachineIncident.MachineIncidentChat;
using kerp.Prosedur.MachineIncident.MachineIncidentDocument;
using kerp.Prosedur.MachineIncident.MachineIncidentLostTime;
using kerp.Prosedur.MachineIncident.MachineIncidentTask;
using kerp.Prosedur.MachineIncident.MachineIncidentWorkShift;
using kerp.Prosedur.MachineIncident.Material;
using kerp.Prosedur.MachineIncident.Record;
using kerp.Prosedur.MachineIncident.SelectModels;
using kerp.Prosedur.MachineIncident.Task;
using kerp.Prosedur.MachineIncident.Type;
using kerp.Prosedur.MachineIncident.WorkOrderType;
using kerp.Prosedur.Users;
using kerp.Repository.CanbanRepository;
using kerp.Repository.MachineIncidentRepository;
using kerp.Repository.UserRepository;
using kerp.Service.MailService;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Service.IncidentService
{
    public class IncidentService(
        IMachineIncidentRepository incidentRepository,
        ICanbanRepository canbanRepository,
        IMailService mailService,
        IHubContext<IncidentHub> hubContext, IUserRepository userRepository) : IIncidentService
    {
        private readonly IMachineIncidentRepository _incidentRepository = incidentRepository;
        private readonly ICanbanRepository _canbanRepository = canbanRepository;
        private readonly IMailService _mailService = mailService;
        private readonly IHubContext<IncidentHub> _hubContext = hubContext;

        private readonly IUserRepository _userRepository = userRepository;
        public async Task<List<MachineIncidentSelectForBackEnd>> InsertAsync(
     List<MachineIncidentInsert> inserts)
        {
            // 1️⃣ DB INSERT
            List<MachineIncidentSelectForBackEnd> incidents = _incidentRepository.Post(inserts);

            // 🔥 HUB üçün list
            List<CanbanCardHub> hubCards = [];



            // 2️⃣ CanbanCardHub-ları yığ və mail task-larını hazırla
            foreach (MachineIncidentSelectForBackEnd incident in incidents)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(incident.Id, 1);
                /*
                // Mail məlumatlarını al
                MailMachineIncidentResult? mailResult = _incidentRepository.MailMachineIncidentResult(incident.Id);

                if (mailResult != null)
                {
                    // ✅ Local variable yarat (closure problemi həll edir)
                    MailMachineIncidentResult mailData = mailResult;

                    // Task yarat amma await etmə
                    Task mailTask = Task.Run(async () =>
                    {
                        try
                        {
                            await _mailService.SendMailAsync(new SendMailDto
                            {
                                MailMachineIncidentResult = mailData, // local variable istifadə et
                                ToEmails = ["virtu309a7@gmail.com"]
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Mail göndərilmədi: {ex.Message}");
                        }
                    });

                    mailTasks.Add(mailTask);
                }
                */
                hubCards.Add(card!);
            }

            // 3️⃣ 🔥 HUB – TƏK DƏFƏ (mail gözləmədən)
            if (hubCards.Count > 0)
            {
                await _hubContext.Clients.All.SendAsync("IncidentInserted", hubCards);
                await _hubContext.Clients.All.SendAsync("NotificationDesktop", incidents);
                await SendAndroidPushNotifications(incidents);
            }

            // 4️⃣ Mail task-larını background-da işlət (await etmədən)
            /*
              _ = Task.WhenAll(mailTasks).ContinueWith(t =>
              {
                  if (t.Exception != null)
                  {
                      Console.WriteLine($"Bəzi maillər göndərilmədi: {t.Exception}");
                  }
              });
              */
            // 5️⃣ Controller-ə geri (mail gözləmədən)
            return incidents;
        }
     
        
        /// <summary>
        /// Android cihazlara push notification göndər
        /// </summary>
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

                if (userTokens.Any())
                {
                    List<string> tokens = userTokens.Select(u => u.FcmToken).ToList();
                    await notificationService.SendAndroidNotificationAsync(tokens, incident);
                }
            }
        }



        public async Task<int> MachineIncidentAccept(MachineIncidentAccept Id)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentAccept(Id);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(Id.Id, 1);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> MachineIncidentAssetUpdate(MachineIncidentAssetUpdate Id)
        {
            MachineIncidentSelect result =
     _incidentRepository.MachineIncidentAssetUpdate(Id);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(Id.Id, 1);
                await _hubContext.Clients.All.SendAsync(
    "IncidentCardUpdate",
    card
);
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0;
        }

        public async Task<int> MachineIncidentAssistantStatus(MachineIncidentAssistantStatus Id)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentAssistantStatus(Id);

            if (result != null)
            {
                _ = _canbanRepository.CanbanCardHub(Id.Id, 1);
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> MachineIncidentCrashTypeUpdate(MachineIncidentCrashTypeUpdate Id)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentCrashTypeUpdate(Id);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 1);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;

        }

        public async Task<int> MachineIncidentProjectUpdate(MachineIncidentProjectUpdate model)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentProjectUpdate(model);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0;
        }

        public async Task<int> MachineIncidentStart(List<MachineIncidentAssistantInsert> item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentStart(item);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 1);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;
        }
        public async Task<int> MachineIncidentAssistantInsert(List<MachineIncidentAssistantInsert> item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentAssistantInsert(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> MachineIncidentTitleUpdateAsync(
            MachineIncidentTitleUpdate model)
        {
            MachineIncidentSelect result =
                _incidentRepository.MachineIncidentTitleUpdate(model);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0;
        }

        public async Task<int> MachineIncidentWorkOrderTypeUpdate(MachineIncidentWorkOrderTypeUpdate Id)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentWorkOrderTypeUpdate(Id);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 1);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> MachineIncidentWorkShiftUpdate(MachineIncidentWorkShiftUpdate model)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentWorkShiftUpdate(model);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0;
        }

        public async Task<int> MachineIncidentDocumentInsert(MachineIncidentDocumentInsert item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentDocumentInsert(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0;
        }

        public async Task<int> MachineIncidentDocumentStatus(MachineIncidentDocumentStatus item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentDocumentStatus(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0;
        }

        public async Task<int> MachineIncidentTaskInsert(MachineIncidentTaskInsert item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentTaskInsert(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0;
        }
        public async Task<int> MachineIncidentChatInsert(MachineIncidentChatInsert item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentChatInsert(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0;
        }

        public async Task<int> MachineIncidentTaskTitleCrashTypeUpdate(MachineIncidentTaskTitleCrashTypeUpdate item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentTaskTitleCrashTypeUpdate(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0; ;
        }

        public async Task<int> MachineIncidentTaskStatus(MachineIncidentTaskStatus item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentTaskStatus(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0; ;
        }

        public async Task<int> MachineIncidentMaterialInsert(MachineIncidentMaterialInsert item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentMaterialInsert(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0; ;
        }
        public async Task<int> MachineIncidentMaterialStatus(MachineIncidentMaterialStatus item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentMaterialStatus(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0; ;
        }

        public async Task<int> MachineIncidentResolved(MachineIncidentResolved item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentResolved(item);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 1);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;
        }
        public async Task<int> MachineIncidentAwaitingApproval(MachineIncidentAwaitingApproval item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentAwaitingApproval(item);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 1);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;
        }
        public async Task<int> MachineIncidentClosed(MachineIncidentClosed item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentClosed(item);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 1);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;
        }
        public async Task<int> MachineIncidentCanceled(MachineIncidentCanceled item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentCanceled(item);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 1);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;
        }
        public async Task<int> MachineIncidentReject(MachineIncidentReject item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentReject(item);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 1);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;
        }

        public async Task<int> MachineIncidentRecordInsert(MachineIncidentRecordInsert item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentRecordInsert(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0; ;
        }

        public async Task<int> MachineIncidentRecordUpdate(MachineIncidentRecordUpdate item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentRecordUpdate(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0; ;
        }

        public async Task<int> MachineIncidentRecordStatus(MachineIncidentRecordStatus item)
        {

            MachineIncidentSelect result = _incidentRepository.MachineIncidentRecordStatus(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0; ;
        }
        public async Task<int> MachineIncidentLostTimeInsert(MachineIncidentLostTimeInsert item)
        {

            MachineIncidentSelect result = _incidentRepository.MachineIncidentLostTimeInsert(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0; ;
        }
        public async Task<int> MachineIncidentLostTimeStatus(MachineIncidentLostTimeStatus item)
        {

            MachineIncidentSelect result = _incidentRepository.MachineIncidentLostTimeStatus(item);

            if (result != null)
            {
                await _hubContext.Clients.All.SendAsync(
                    "MachineIncidentTitleUpdate",
                    result
                );

                return 1;
            }

            return 0; ;
        }

        public async Task<int> MachineIncidentEventUpdate(MachineIncidentEventUpdate item)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentEventUpdate(item);
            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 1);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await _hubContext.Clients.All.SendAsync("MachineIncidentTitleUpdate", result);

                return 1;
            }
            return 0;
        }
    }
}
