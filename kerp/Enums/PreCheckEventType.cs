namespace kerp.Enums
{
    public enum PreCheckEventType
    {
        Created = 1,        // Açıldı
        Accepted = 2,       // Qəbul edildi
        InReview = 3,       // Yoxlamaya göndərildi
        Approved = 4,       // Təsdiq edildi
        Closed = 5,      // Bağlandı
                         // =========================
                         // RECORD CRUD EVENTS
                         // =========================
        RecordInserted = 6,
        RecordUpdated = 7,
        RecordStatusChanged = 8,

        // =========================
        // DOCUMENT CRUD EVENTS
        // =========================
        DocumentInserted = 9,
        DocumentUpdated = 10,
        DocumentStatusChanged = 11,
        ElectricalController = 12,
        MechanicalController = 13,
        CMAdded = 14,
        CMEMAdded = 15

    }
}