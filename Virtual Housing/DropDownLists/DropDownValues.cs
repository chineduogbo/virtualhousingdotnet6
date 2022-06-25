namespace Virtual_Housing.DropDownLists
{
    public class DropDownValues
    {
        public DropDownValues()
        {
            States = new List<string>() { "Abuja","Abia","Adamawa","Akwa-Ibom","Anambra","Bauchi","Bayelsa",
             "Benue","Borno","Cross River","Delta","Ebonyi","Edo","Ekiti","Enugu","Gombe","Imo","Jigawa","Kaduna","Kano","Kebbi","Kogi","Kwara",
             "Lagos","Nasarawa","Niger","Ogun","Ondo","Osun","Oyo","Plateau","Rivers","Sokoto","Taraba","Yobe","Zamfara"};
            Category = new List<string>() { "Land", "Rental", "Commercial", "Industrial" };
            Country = new List<string>() { "Nigeria" };
        }
        public List<string> States { get; set; } 
        public List<string> Category { get; set; } 
        public List<string> Country { get; set; } 
    }
}
