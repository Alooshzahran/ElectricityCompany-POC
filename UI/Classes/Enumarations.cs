namespace UI.Classes
{
        public enum Service : int
        {

        Complaint = 1,
        /*MOIProjectRequest = 33 */ //add new service
        }
        public enum ServiceTypes : int
        {
        Complaint = 2,
        /*MOIProject = 86 *///add new
        }

        public enum LookupGroups : int
        {
            Branch = 1,
            Department = 2,
            Export_office = 3,
            Complaining_parties = 4,
            Complaint_Method = 5,
            Audit_Status = 6,
            AreaID   = 7 // add new
        }

        public enum Steps : int
        {
            Requester = 1,
            Audit = 2,
            Complaint_Response = 3,
            Audit2 = 4,
            SubWorkflow = 5,
            Audit3 = 6
        }

        public enum Actions : int
        {
            Submit = 1,
            Approve = 2,
            Reject = 3,
            Complete =5,
            Return =6,
            CompleteRemark =12,
    }

        public class Constants
        {
            public const int EmployeeId = 1;
            public const string UserGroup = "user";
            public const string ProcessIEC_Complaint = "WorkFlow\\IEC_Complaint.wf";
            

        }
}

