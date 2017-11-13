using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ImportTown
{
    private string name;
    private string countryName;
    public ImportTown(string townName,string countryN)
    {
        this.name = townName;
        this.countryName = countryN;
    }
    public void Execute()
    {
        Town town = new Town();
        town.Name = name;
        town.ui = Guid.NewGuid();
      
        soccerContext context = new soccerContext();
        try
        {
            Country country = context.Countries.FirstOrDefault(c => c.Name == countryName);
            country.Towns.Add(town);//Add town to this country
            context.SaveChanges();
        }
        catch (Exception)
        {

            throw new System.InvalidOperationException("There is such town in data");
        }
    }
}