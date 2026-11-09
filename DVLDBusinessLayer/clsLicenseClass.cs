using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

public class clsLicenseClass
{
    public int LicenseClassID { set; get; }
    public string ClassName { set; get; }
    public string ClassDescription { set; get; }
    public byte MinimumAllowedAge { set; get; }
    public byte DefaultValidityLength { set; get; }
    public decimal ClassFees { set; get; }

    clsLicenseClass(int LicenseClassID,  string ClassName,  string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength,  decimal ClassFees) {
        this.LicenseClassID = LicenseClassID;
        this.ClassName = ClassName;
        this.ClassDescription = ClassDescription;
        this.MinimumAllowedAge = MinimumAllowedAge;
        this.DefaultValidityLength = DefaultValidityLength;
        this.ClassFees = ClassFees;
    }

    public static DataTable GetAllLicenseClasses() { 
        return LicenseClassesData.GetAllLicenseClasses();
    }

    public static clsLicenseClass Find(int LicenseClassID) {
       
        string ClassName = "";
        string ClassDescription = "";
        byte MinimumAllowedAge = 0;
        byte DefaultValidityLength = 0;
        decimal ClassFees = 0;
        return LicenseClassesData.GetLicenseClasseByID(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees) ?
            new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees) :
            null;
    }


}
