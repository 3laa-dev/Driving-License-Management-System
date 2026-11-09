using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class LocalDrivingLicenseApplicationsData
    {
        public static int CreateLocalDrivingLicenseApplication
            (
             int ApplicationPersonID,
             int CreatedByUserID,
             int ApplicationTypeID,
             DateTime ApplicationDate,
             byte ApplicationStatus,
             DateTime LastStatusDate,
             decimal PaidFees , 
             int LicenseClassID
            )
        {
            return 1;
        }
    }
}
