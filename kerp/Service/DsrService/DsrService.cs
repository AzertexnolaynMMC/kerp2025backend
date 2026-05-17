using kerp.Hubs.IncidentHub;
using kerp.Prosedur.Canban;
using kerp.Prosedur.Dsr.Assistant;
using kerp.Prosedur.Dsr.Chat;
using kerp.Prosedur.Dsr.Cost;
using kerp.Prosedur.Dsr.Document;
using kerp.Prosedur.Dsr.Dsrs;
using kerp.Prosedur.Dsr.LostTime;
using kerp.Prosedur.Dsr.Material;
using kerp.Prosedur.Dsr.Record;
using kerp.Prosedur.Dsr.Task;
using kerp.Prosedur.Dsr.TaskComment;
using kerp.Prosedur.Dsr.WorkShift;
using kerp.Prosedur.Users;
using kerp.Repository.CanbanRepository;
using kerp.Repository.DsrRepository;
using kerp.Repository.UserRepository;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Service.DsrService
{
    public class DsrService(
        IDsrRepository dsrRepository,
        ICanbanRepository canbanRepository,
        IUserRepository userRepository,
        IHubContext<IncidentHub> hubContext) : IDsrService
    {
        private readonly IDsrRepository _dsrRepository = dsrRepository;
        private readonly ICanbanRepository _canbanRepository = canbanRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IHubContext<IncidentHub> _hubContext = hubContext;

        // =====================================================
        // HELPER - SignalR göndər
        // =====================================================
        private async Task SendUpdate(int dsrId)
        {
            DSRSelect? full = _dsrRepository.DSRSelect(dsrId);
            if (full != null)
            {
                await _hubContext.Clients.All.SendAsync("DSRUpdate", full);
            }
        }

        // =====================================================
        // DSR INSERT
        // =====================================================
        public async Task<int> DSRInsert(List<DSRInsert> request)
        {
            List<DSRSelect>? result = _dsrRepository.DSRInsert(request);

            if (result == null || result.Count == 0)
            {
                return 0;
            }

            List<CanbanCardHub> hubCards = [];

            foreach (DSRSelect item in result)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(item.Id, 4);
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
        public async Task<int> DSRWorkOrderStarted(DSRControllerLifeCycle request)
        {
            DSRSelect result = _dsrRepository.DSRWorkOrderStarted(request);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 4);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await SendUpdate(result.Id);

                return 1;
            }
            return 0;
        }

        public async Task<int> DSRReject(DSRReject request)
        {
            DSRSelect result = _dsrRepository.DSRReject(request);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 4);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await SendUpdate(result.Id);

                return 1;
            }
            return 0;
        }

        public async Task<int> WorkOrderEvaluated(DSRControllerLifeCycle request)
        {
            DSRSelect result = _dsrRepository.WorkOrderEvaluated(request);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 4);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await SendUpdate(result.Id);

                return 1;
            }
            return 0;
        }
        public async Task<int> WorkOrderFinished(DSRControllerLifeCycle request)
        {
            DSRSelect result = _dsrRepository.WorkOrderFinished(request);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 4);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await SendUpdate(result.Id);

                return 1;
            }
            return 0;
        }

        public async Task<int> WorkOrderClosed(DSRControllerLifeCycle request)
        {
            DSRSelect result = _dsrRepository.WorkOrderClosed(request);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id, 4);
                await _hubContext.Clients.All.SendAsync("IncidentCardUpdate", card);
                await SendUpdate(result.Id);

                return 1;
            }
            return 0;
        }
        public async Task<int> DSRTaskAssistantDelivered(DSRTaskAssistantControllerLifeCycle request)
        {
            DSRTaskAssistantSelect? result = _dsrRepository.DSRTaskAssistantDelivered(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }
        public async Task<int> DSRTaskAssistantRejected(DSRTaskAssistantReject request)
        {
            DSRTaskAssistantSelect? result = _dsrRepository.DSRTaskAssistantRejected(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        // =====================================================
        // WORK SHIFT
        // =====================================================
        public async Task<int> DSRWorkShiftInsert(DSRWorkShiftInsert request)
        {
            DSRWorkShiftSelect? result = _dsrRepository.DSRWorkShiftInsert(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRWorkShiftUpdate(DSRWorkShiftUpdate request)
        {
            DSRWorkShiftSelect? result = _dsrRepository.DSRWorkShiftUpdate(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }



        // =====================================================
        // TASK
        // =====================================================
        public async Task<int> DSRTaskInsert(DSRTaskInsert request)
        {
            DSRTaskSelect? result = _dsrRepository.DSRTaskInsert(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRTaskUpdate(DSRTaskUpdate request)
        {
            DSRTaskSelect? result = _dsrRepository.DSRTaskUpdate(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRCostInsert(List<DSRCostInsert> request)
        {
            DSRCostSelect? result = _dsrRepository.DSRCostInsert(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRTaskStatus(DSRTaskStatus request)
        {
            DSRTaskSelect? result = _dsrRepository.DSRTaskStatus(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        // =====================================================
        // TASK ASSISTANT
        // =====================================================
        public async Task<int> DSRTaskAssistantInsert(DSRTaskAssistantInsert request)
        {
            DSRTaskAssistantSelect? result = _dsrRepository.DSRTaskAssistantInsert(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRTaskAssistantStatus(DSRTaskAssistantStatus request)
        {
            DSRTaskAssistantSelect? result = _dsrRepository.DSRTaskAssistantStatus(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        // =====================================================
        // TASK COMMENT
        // =====================================================
        public async Task<int> DSRTaskCommentInsert(DSRTaskCommentInsert request)
        {
            DSRTaskCommentSelect? result = _dsrRepository.DSRTaskCommentInsert(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRTaskCommentUpdate(DSRTaskCommentUpdate request)
        {
            DSRTaskCommentSelect? result = _dsrRepository.DSRTaskCommentUpdate(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRTaskCommentDelete(DSRTaskCommentDelete request)
        {
            DSRTaskCommentSelect? result = _dsrRepository.DSRTaskCommentDelete(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        // =====================================================
        // CHAT
        // =====================================================
        public async Task<int> DSRChatInsert(DSRChatInsert request)
        {
            DSRChatSelect? result = _dsrRepository.DSRChatInsert(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        // =====================================================
        // DOCUMENT
        // =====================================================
        public async Task<int> DSRDocumentInsert(DSRDocumentInsert request)
        {
            DSRDocumentSelect? result = _dsrRepository.DSRDocumentInsert(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRDocumentUpdate(DSRDocumentUpdate request)
        {
            DSRDocumentSelect? result = _dsrRepository.DSRDocumentUpdate(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRDocumentStatus(DSRDocumentStatus request)
        {
            DSRDocumentSelect? result = _dsrRepository.DSRDocumentStatus(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        // =====================================================
        // LOST TIME
        // =====================================================
        public async Task<int> DSRLostTimeInsert(DSRLostTimeInsert request)
        {
            DSRLostTimeSelect? result = _dsrRepository.DSRLostTimeInsert(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRLostTimeUpdate(DSRLostTimeUpdate request)
        {
            DSRLostTimeSelect? result = _dsrRepository.DSRLostTimeUpdate(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRLostTimeStatus(DSRLostTimeStatus request)
        {
            DSRLostTimeSelect? result = _dsrRepository.DSRLostTimeStatus(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        // =====================================================
        // MATERIAL
        // =====================================================
        public async Task<int> DSRMaterialInsert(DSRMaterialInsert request)
        {
            DSRMaterialSelect? result = _dsrRepository.DSRMaterialInsert(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRMaterialUpdate(DSRMaterialUpdate request)
        {
            DSRMaterialSelect? result = _dsrRepository.DSRMaterialUpdate(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRMaterialStatus(DSRMaterialStatus request)
        {
            DSRMaterialSelect? result = _dsrRepository.DSRMaterialStatus(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        // =====================================================
        // RECORD
        // =====================================================
        public async Task<int> DSRRecordInsert(DSRRecordInsert request)
        {
            DSRRecordSelect? result = _dsrRepository.DSRRecordInsert(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRRecordUpdate(DSRRecordUpdate request)
        {
            DSRRecordSelect? result = _dsrRepository.DSRRecordUpdate(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        public async Task<int> DSRRecordStatus(DSRRecordStatus request)
        {
            DSRRecordSelect? result = _dsrRepository.DSRRecordStatus(request);
            if (result == null)
            {
                return 0;
            }

            await SendUpdate(result.DsrId);
            return 1;
        }

        // =====================================================
        // PUSH NOTIFICATIONS
        // =====================================================
        private async Task SendAndroidPushNotifications(List<DSRSelect> items)
        {
            NotificationService notificationService = new();
            foreach (DSRSelect item in items)
            {
                int workOrderTypeId = item.DSRWorkOrderTypeSelect?.FirstOrDefault()?.WorkOrderTypeId ?? 0;
                int structureId = item.DSRStructureSelect?.FirstOrDefault()?.StructureId ?? 0;

                List<UserFcmToken> userTokens = await _userRepository.GetUserFcmTokens(
                    workOrderTypeId,
                    structureId,
                    0
                );

                if (userTokens.Any())
                {
                    List<string> tokens = [.. userTokens.Select(x => x.FcmToken)];
                    await notificationService.SendAndroidNotificationAsync(tokens, item);
                }
            }
        }


    }
}