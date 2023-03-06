using Microsoft.AspNetCore.Mvc.Rendering;
using Xmoor.Models;

namespace Xmoor.Main.Areas.Applicant.ViewModels
{
    
    /// <summary>
    ///  This class is used as a veiw model for the Create 
    ///  View.
    ///  
    ///  No input arguments
    ///  New objects from this class contains: new List<Titles> obect reference, new Staff object reference
    /// </summary>
    public class RegisterVM
    {
        // Used for the object
        public StaffPersonalDetails StaffPersonalDetails { get; set; }

        public List<SelectListItem> TitlesList { get; set; }


        public RegisterVM()
        {
            StaffPersonalDetails = new StaffPersonalDetails();
            TitlesList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Mr",Value="Mr"},
                new SelectListItem { Text = "Ms",Value="Ms"},
                new SelectListItem { Text = "Mrs",Value="Mrs"},
                new SelectListItem { Text = "Dr",Value="Dr"},
                new SelectListItem { Text = "Miss",Value="Miss"},
                new SelectListItem { Text = "Prof",Value="Prof"}
            };
        }

    }
}
