namespace kerp.Enums
{
    public enum DsrEventType
    {
        WorkOrderOpened = 1,
        WorkOrderStarted = 2,
        WorkOrderEvaluated = 3,
        WorkOrderFinished = 4,
        WorkOrderClosed = 5,

        // Chat
        ChatAdded = 6,

        // Document
        DocumentAdded = 7,
        DocumentUpdated = 8,
        DocumentDeleted = 9,

        // LostTime
        LostTimeAdded = 10,
        LostTimeUpdated = 11,
        LostTimeDeleted = 12,

        // Material
        MaterialAdded = 13,
        MaterialUpdated = 14,
        MaterialDeleted = 15,

        // Record
        RecordAdded = 16,
        RecordUpdated = 17,
        RecordDeleted = 18,

        // Task
        TaskAdded = 19,
        TaskUpdated = 20,
        TaskDeleted = 21,

        // TaskAssistant
        AssistantAdded = 22,
        AssistantRemoved = 23,

        // TaskComment
        CommentAdded = 24,
        CommentUpdated = 25,
        CommentDeleted = 26,

        // WorkShift
        WorkShiftAdded = 27,
        WorkShiftUpdated = 28,

        // WorkOrderType
        WorkOrderTypeAdded = 29,

        // Section
        SectionAdded = 30,

        // Structure
        StructureAdded = 31,

        // Machine
        MachineAdded = 32,

        // TaskAssistant LifeCycle
        AssistantAccepted = 33,
        AssistantDelivered = 34,
        AssistantRejected = 35,
        DsrRejected = 36,
        CostAdded = 37,
    }
}