using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmoor.Utility
{
    public class StaticDetails
    {

        //Details relavent to roles
        public const String Role_General_Staff = "GeneralStaff";
        public const String Role_Manager = "Manager";
        public const String Role_Payroll = "PayrollAdmin";
        public const String Role_Applicant= "Applicant";

        //Application status names for applications for job roles

        public const String ApplicationStatus_SUBMITTED = "SUBMITTED";
        public const String ApplicationStatus_WITHDRAWN = "WITHDRAWN";
        public const String ApplicationStatus_REJECTED = "REJECTED";
        public const String ApplicationStatus_SUCCESSFUL = "SUCCESSFUL";


    }
}
