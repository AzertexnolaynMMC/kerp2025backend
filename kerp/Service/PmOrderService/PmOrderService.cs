using kerp.Hubs.IncidentHub;
using kerp.Prosedur.Canban;
using kerp.Prosedur.PMOrders;
using kerp.Repository.CanbanRepository;
using kerp.Repository.PMOrdersRepository;
using kerp.Repository.UserRepository;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Service.PmOrderService
{
    public class PmOrderService(
          IPMOrdersRepository incidentRepository,
        ICanbanRepository canbanRepository,
        IHubContext<IncidentHub> hubContext, IUserRepository userRepository
        ) : IPmOrderService
    {
        private readonly IPMOrdersRepository _incidentRepository = incidentRepository;
        private readonly ICanbanRepository _canbanRepository = canbanRepository;
        private readonly IHubContext<IncidentHub> _hubContext = hubContext;
        private readonly IUserRepository _userRepository = userRepository;

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
    }
}
