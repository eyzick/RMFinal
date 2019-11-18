using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Host
/// </summary>
public class Host
{


    private int HostID;
    private String FirstName;
    private String LastName;
    private String EmailAddress;
    private String phoneNumber;
    private String HouseNumber;
    private String Street;
    private String CityCounty;
    private String HomeState;
    private String Country;
    private String Zip;
    private DateTime DateOfBirth;
    private String userType;

    public Host()
    {

    }
    public Host(int HostID, String FirstName, String LastName, String EmailAddress, String HouseNumber, String Street, String CityCounty, String HomeState, String Country, String Zip, DateTime DateOfBirth, String userType)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.EmailAddress = EmailAddress;
        this.HouseNumber = HouseNumber;
        this.Street = Street;
        this.CityCounty = CityCounty;
        this.HomeState = HomeState;
        this.Country = Country;
        this.Zip = Zip;
        this.DateOfBirth = DateOfBirth;



    }

    public void setPhoneNumber(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }

    public string getPhoneNumber()
    {
        return phoneNumber;
    }
    public int GetHostID()
    {
        return HostID;
    }
    public void SetHostID(int HostID)
    {
        this.HostID = HostID;

    }

    public String GetFirstName()
    {
        return FirstName;
    }
    public void SetFirstName(String FirstName)
    {
        this.FirstName = FirstName;
    }

    public String GetLastName()
    {
        return LastName;
    }
    public void SetLastName(String LastName)
    {
        this.LastName = LastName;
    }

    public String GetEmailAddress()
    {
        return EmailAddress;
    }
    public void SetEmailAddress(String EmailAddress)
    {
        this.EmailAddress = EmailAddress;
    }

    public String GetHouseNumber()
    {
        return HouseNumber;
    }
    public void SetHouseNumber(String HouseNumber)
    {
        this.HouseNumber = HouseNumber;

    }
    public String GetStreet()
    {
        return Street;
    }
    public void SetStreet(String Street)
    {
        this.Street = Street;

    }
    public String GetCityCounty()
    {
        return CityCounty;
    }
    public void SetCityCounty(String CityCounty)
    {
        this.CityCounty = CityCounty;

    }
    public String GetCountry()
    {
        return Country;
    }
    public void SetCountry(String Country)
    {
        this.Country = Country;

    }
    public String GetHomeState()
    {
        return HomeState;
    }
    public void SetHomeState(String HomeState)
    {
        this.HomeState = HomeState;

    }
    public String GetZip()
    {
        return Zip;
    }
    public void SetZip(String Zip)
    {
        this.Zip = Zip;

    }
    public DateTime GetDateOfBirth()
    {
        return DateOfBirth;
    }
    public void SetDateOfBirth(DateTime DateOfBirth)
    {
        this.DateOfBirth = DateOfBirth;

    }
}
