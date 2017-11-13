using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

public class ImportCountry
{
    private string countryName;
    public ImportCountry(string dataArgs)
    {
        this.countryName = dataArgs;
    }
    public void Execute()
    {
        Country country = new Country();
        country.Name = countryName;
        country.ui = Guid.NewGuid();
        soccerContext context = new soccerContext();
        try
        {
            context.Countries.Add(country);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            
            throw new System.InvalidOperationException("There is such country in data");
        }
    }
}