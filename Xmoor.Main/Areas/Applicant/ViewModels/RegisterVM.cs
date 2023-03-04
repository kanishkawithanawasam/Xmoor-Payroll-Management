using Xmoor.Models;

namespace Xmoor.Main.Areas.Applicant.ViewModels
{
    
    public class Titles
    {
        public string Title { get; set; }
    }


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

        public List<Titles> Title { get; set; }


        public RegisterVM()
        {
            this.StaffPersonalDetails = new StaffPersonalDetails();
            this.Title = new List<Titles>
            {
                new Titles { Title = "Mr"},
                new Titles { Title = "Ms"},
                new Titles { Title = "Mrs"},
                new Titles { Title = "Miss"},
                new Titles { Title = "Dr"},
                new Titles { Title = "Prof"}
            };
        }

    }
}
