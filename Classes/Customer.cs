namespace Classes;

public class Customer
{
    public int Id { get; set; }

    private string _firstName;
    public string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            if (value.ToLower().Equals("admin"))
            {
                _firstName = "You are not f. admin.";
            }
            else
            {
                _firstName = value;
            }
        }
    }

    public string LastName { get; set; }
    public string City { get; set; }
}