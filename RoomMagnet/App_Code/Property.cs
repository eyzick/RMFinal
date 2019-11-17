using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Property
/// </summary>
public class Property
{


    private String HouseNumber;
    private String Street;
    private String CityCounty;
    private String HomeState;
    private String Zip;
    private double MonthlyPrice;
    private int capacity;
    Boolean availability;
    private String roomType;
    private String description;
    private DateTime Effectivedate;
    private DateTime TerminationDate;



    //JMU Honor Code Verified
    public Property()
    {

    }
    public Property(String HouseNumber, String Street, String CityCounty, String HomeState, String Country, String Zip,
         double MonthlyPrice, DateTime Effectivedate, DateTime TerminationDate)
    {
        setHouseNumber(HouseNumber);
        setStreet(Street);
        setHomeState(HomeState);
        setCityCounty(CityCounty);
       
        setZip(Zip);
        setMonthlyPrice(MonthlyPrice);
        setTerminationDate(TerminationDate);
        setEffectivedate(Effectivedate);

    }

    public void setDescription(string description)
    {
        this.description = description;
    }

    public string getDescription()
    {
        return description;
    }

    public void setRoomType(string roomType)
    {
        this.roomType = roomType;
    }

    public string getRoomType()
    {
        return roomType;
    }
   
    public String getHouseNumber()
    {
        return HouseNumber;
    }
    public void setHouseNumber(String HouseNumber)
    {
        this.HouseNumber = HouseNumber;

    }
    public String getStreet()
    {
        return Street;
    }
    public void setStreet(String Street)
    {
        this.Street = Street;

    }
    public String getCityCounty()
    {
        return CityCounty;
    }
    public void setCityCounty(String CityCounty)
    {
        this.CityCounty = CityCounty;

    }
   
    public String getHomeState()
    {
        return HomeState;
    }
    public void setHomeState(String HomeState)
    {
        this.HomeState = HomeState;

    }
    public String getZip()
    {
        return Zip;
    }
    public void setZip(String Zip)
    {
        this.Zip = Zip;

    }

    public double getMonthlyPrice()
    {
        return MonthlyPrice;
    }
    public void setMonthlyPrice(double MonthlyPrice)
    {
        this.MonthlyPrice = MonthlyPrice;

    }
    public DateTime getEffectivedate()
    {
        return Effectivedate;
    }
    public void setEffectivedate(DateTime Effectivedate)
    {
        this.Effectivedate = Effectivedate;

    }
    public DateTime getTerminationDate()
    {
        return TerminationDate;
    }
    public void setTerminationDate(DateTime TerminationDate)
    {
        this.TerminationDate = TerminationDate;

    }




}