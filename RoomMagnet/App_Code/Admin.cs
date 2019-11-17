using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Admin
/// </summary>
public class Admin
{

    private String FirstName;
    private String LastName;
    private String EmailAddress;
    public Admin(String FirstName, String LastName, String EmailAddress)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.EmailAddress = EmailAddress;

    }

    public String GetFirstName(String FirstName)
    {
        return FirstName;
    }
    public void SetFirstName(String FirstName)
    {
        this.FirstName = FirstName;
    }

    public String GetLastName(String LastName)
    {
        return LastName;
    }
    public void SetLastName(String LastName)
    {
        this.LastName = LastName;
    }
    public String GetEmailAddress(String EmailAddress)
    {
        return EmailAddress;
    }
    public void SetEmailAddress(String EmailAddress)
    {
        this.EmailAddress = EmailAddress;
    }





}