using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for ImportCountry
/// </summary>
public class ImportCountry
{
    private string data;
    public ImportCountry(string dataArgs)
    {
        this.data = dataArgs;
    }
    public void Execute()
    {
        Country country = new Country();
        country.Name = data;
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