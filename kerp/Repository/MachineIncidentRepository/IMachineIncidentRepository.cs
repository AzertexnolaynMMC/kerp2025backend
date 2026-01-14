using kerp.Prosedur.MachineIncident.Incident;
using kerp.Prosedur.MachineIncident.SelectModels;

namespace kerp.Repository.MachineIncidentRepository
{
    public interface IMachineIncidentRepository
    {
        List<MachineIncidentCrashTypeSelectMulti>? MachineIncidentCrashTypeSelectMulti();
        List<MachineIncidentProjectSelectMulti>? MachineIncidentProjectSelectMulti();
        List<MachineIncidentWorkOrderTypeSelectMulti>? MachineIncidentWorkOrderTypeSelectMulti();
        List<MachineIncidentWorkShiftSelectMulti>? MachineIncidentWorkShiftSelectMulti();
        int Post(List<MachineIncidentInsert> MachineIncidentInsert);
    }
}
