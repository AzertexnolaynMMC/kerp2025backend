using kerp.Hubs.IncidentHub;
using kerp.Prosedur.Canban;
using kerp.Prosedur.MachineIncident.Document;
using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.MachineIncident.MachineIncidentAssistant;
using kerp.Prosedur.MachineIncident.MachineIncidentDocument;
using kerp.Prosedur.MachineIncident.MachineIncidentWorkShift;
using kerp.Prosedur.MachineIncident.SelectModels;
using kerp.Prosedur.MachineIncident.Task;
using kerp.Prosedur.MachineIncident.Type;
using kerp.Prosedur.MachineIncident.WorkOrderType;
using kerp.Repository.CanbanRepository;
using kerp.Repository.MachineIncidentRepository;
using Microsoft.AspNetCore.SignalR;

namespace kerp.Service.IncidentService
{
    public class IncidentService(
        IMachineIncidentRepository incidentRepository,
        ICanbanRepository canbanRepository,
        IHubContext<IncidentHub> hubContext) : IIncidentService
    {
        private readonly IMachineIncidentRepository _incidentRepository = incidentRepository;
        private readonly ICanbanRepository _canbanRepository = canbanRepository;
        private readonly IHubContext<IncidentHub> _hubContext = hubContext;

        public async Task<List<MachineIncidentSelectForBackEnd>> InsertAsync(
            List<MachineIncidentInsert> inserts)
        {
            // 1️⃣ DB INSERT
            List<MachineIncidentSelectForBackEnd> incidents =
                _incidentRepository.Post(inserts);

            // 🔥 HUB üçün list
            List<CanbanCardHub> hubCards = [];

            // 2️⃣ CanbanCardHub-ları yığ
            foreach (MachineIncidentSelectForBackEnd incident in incidents)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(incident.Id);

                hubCards.Add(card);
            }

            // 3️⃣ 🔥 HUB – TƏK DƏFƏ
            if (hubCards.Count > 0)
            {
                await _hubContext.Clients.All.SendAsync(
                    "IncidentInserted",
                    hubCards
                );
            }

            // 4️⃣ Controller-ə geri
            return incidents;
        }

        public async Task<int> MachineIncidentAccept(MachineIncidentAccept Id)
        {
            MachineIncidentSelect result = _incidentRepository.MachineIncidentAccept(Id);

            if (result != null)
            {
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(Id.Id);
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
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(Id.Id);
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
                _ = _canbanRepository.CanbanCardHub(Id.Id);
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
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id);
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
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id);
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
                CanbanCardHub? card = _canbanRepository.CanbanCardHub(result.Id);
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
    }
}
