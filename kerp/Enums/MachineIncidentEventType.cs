namespace kerp.Enums
{
    public enum MachineIncidentEventType
    {
        Created = 1,                     // Is emrini acan
        CreatedWithWorkerAssigned = 2,    // Is emrini acarken oz iscini teyin edib
        Accepted = 3,                    // Is Emrini qebul eden
        AssignedToMaster = 4,             // Is emrini yonlendiren ustaya
        AcceptedByMaster = 5,             // Is emrini qebul eden usta
        StartedByMaster = 6,              // Is emrini basladan usta
        CompletedByMaster = 7,            // Is emrini bitiren usta
        ApprovedByForeman = 8,            // Is emrini tesdiq eden formen
        ApprovedByCounterParty = 9,       // Is emrini tesdiq eden qarsi teref
        Closed = 10,                      // Is emrini baglayan

        CancelledByCounterParty = 11,     // Is emrini legv eden qarsi teref
        CancelledByReceiver = 12,         // Is emrini legv eden qebul eden teref

        RejectedByCounterParty = 13,      // Is emrini imtina eden qarsi teref
        RejectedByReceiver = 14,          // Is emrini imtina eden qebul eden teref

        ServiceTypeChanged = 15,          // Is emrinin ServisTypeni deyisen
        DescriptionChanged = 16,          // Is emrinin aciqlamasin deyisen
        TypeChanged = 17,                 // Is emrinin Novunu deyisen
        AssetChanged = 18,                // Is emrinin Assetini deyisen
        DepartmentChanged = 19,           // Is emrinin Bolmesi deyisdirildi
        StructureChanged = 20,            // Is emrinin Strukturu deyisdi

        TaskAdded = 21,                   // Is emrine Task elave edildi
        TaskUpdated = 22,                 // Is emrinin taski deyisdirildi
        TaskRemoved = 23,                 // Is emrinde Task silindi

        MaterialAdded = 24,               // Is emrine material elave edildi
        MaterialUpdated = 25,             // Is emrinde material deyisdirildi
        MaterialRemoved = 26,             // Is emrinde material silindi

        ProjectChanged = 27,              // Is emrinde layiheni deyisdi
        WorkShiftChanged = 28,            // Is emrin novbesini deyisen

        MasterAdded = 29,                 // Usta elave edildi
        HelperAdded = 30,                 // Komekci elave edildi
        MasterRemoved = 31,               // Usta silindi
        HelperRemoved = 32,               // Komekci silindi

        Started = 33,                     // Is emrini baslatdi

        DocumentAdded = 34,               // Sened elave etdi
        DocumentRemoved = 35              // Senedi sildi
    }
}
