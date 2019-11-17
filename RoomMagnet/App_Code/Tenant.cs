using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Tenant
/// </summary>
public class Tenant
{
    private int TenantID;
    private String FirstName;
    private String LastName;
    private String EmailAddress;
    private String PhoneNumber;
    private String HouseNumber;
    private String Street;
    private String CityCounty;
    private String HomeState;
    private String Zip;
    private DateTime DateOfBirth;
    private string userType;
    

    public Tenant()
    {

    }
    public Tenant(String FirstName, String LastName, String EmailAddress, String PhoneNumber, String HouseNumber, String Street, String CityCounty, String HomeState, String Zip, DateTime DateOfBirth, String userType)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.EmailAddress = EmailAddress;
        this.PhoneNumber = PhoneNumber;
        this.HouseNumber = HouseNumber;
        this.Street = Street;
        this.CityCounty = CityCounty;
        this.HomeState = HomeState;
        this.Zip = Zip;
        this.DateOfBirth = DateOfBirth;
        this.userType = userType;



    }
    public void setPhoneNumber(string phoneNumber)
    {
        this.PhoneNumber = phoneNumber;
    }
    public string getPhoneNumber()
    {
        return PhoneNumber;
    }

    public string getUserType()
    {

        return this.userType;
    }

    public int GetTenantID()
    {
        return TenantID;
    }
    public void setTenantID(int TenantID)
    {
        this.TenantID = TenantID;

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