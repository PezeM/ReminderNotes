using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ReminderNotes.Authorization
{
    public static class NoteOperations
    {
        public static OperationAuthorizationRequirement Create = new OperationAuthorizationRequirement
        {
            Name = Constans.CreateOperationName
        };

        public static OperationAuthorizationRequirement Read = new OperationAuthorizationRequirement
        {
            Name = Constans.ReadOperationName
        };

        public static OperationAuthorizationRequirement Update = new OperationAuthorizationRequirement
        {
            Name = Constans.UpdateOperationName
        };

        public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement
        {
            Name = Constans.DeleteOperationName
        };
    }

    public class Constans
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Reaad";
        public static readonly string DeleteOperationName = "Delete";
        public static readonly string UpdateOperationName = "Update";
    }
}
