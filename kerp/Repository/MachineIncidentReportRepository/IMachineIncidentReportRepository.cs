using kerp.Prosedur.MachineIncidentReport;

namespace kerp.Repository.MachineIncidentReportRepository
{
    public interface IMachineIncidentReportRepository
    {
        List<MachineIncidentReportSelect>? MachineIncidentReportSelect(int Year, int month);
        List<MachineIncidentReportYear>? MachineIncidentReportYear();
    }
}
