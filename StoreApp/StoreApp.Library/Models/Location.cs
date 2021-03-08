namespace StoreApp.Library.Models
{
  public class Location
  {
    private int _id;
    private string _code;
    private string _address1;
    private string _address2;
    private string _city;
    private string _state;

    public Location() { }

    public Location(string code, string address1, string address2, string city, string state)
    {
      Code = code;
      Address1 = address1;
      Address2 = address2;
      City = city;
      State = state;
    }
    public Location(int id, string code, string address1, string address2, string city, string state)
    {
      Id = id;
      Code = code;
      Address1 = address1;
      Address2 = address2;
      City = city;
      State = state;
    }
    public int Id
    {
      get => _id;
      set => _id = value;
    }
    public string Code
    {
      get => _code;
      set => _code = value;
    }

    public string Address1
    {
      get => _address1;
      set => _address1 = value;
    }
    public string Address2
    {
      get => _address2;
      set => _address2 = value;
    }

    public string City
    {
      get => _city;
      set => _city = value;
    }

    public string State
    {
      get => _state;
      set => _state = value;
    }
    /// <summary>
    /// Checks if locacaton has a valid code
    /// </summary>
    /// <returns>bool</returns>
    public bool LocationHasValidCode(string code)
    {
      string forbbidenChars = "!@#$%^&*()";

      foreach (char i in code)
      {
        foreach (char j in forbbidenChars)
        {
          if (i == j)
          {
            return false;
          }
        }
      }
      return true;
    }
    /// <summary>
    /// Checks if Location object holds a valid id from the database
    /// </summary>
    /// <returns></returns>
    public bool LocationHasValidId()
    {
      return _id > 0;
    }
  }
}

