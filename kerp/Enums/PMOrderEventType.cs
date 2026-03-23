namespace kerp.Enums
{
    public enum PMOrderEventType
    {
        Created = 1,          // pm acildi
        Accepted = 2,         // pm qebul edildi / ise basladi
        Completed = 3,        // pm qutardi
        Closed = 4,           // pm baglandi
        Finished = 5,         // bitir
        TaskAdded = 6,         // Task elave edildi
        NoteAdded = 7,
        NoteDeleted = 8,
        NoteUpdate = 9,
        DocumentAdded = 10,
        DocumentDeleted = 11,
        DocumentUpdate = 12,
        MaterialAdded = 13,
        MaterialDeleted = 14,
        MaterialUpdate = 15,
        AssigneesAdded = 16,
        AssigneesDeleted = 17,
        ChatAdded = 18,

    }
}