using Models;
using System;

internal class ImportCountry: IImport
{
    private string countryName;
    public ImportCountry(string dataArgs)
    {
        this.countryName = dataArgs;
    }
    public void Execute()
    {
        Country country = new Country
        {
            Name = countryName,
            ui = Guid.NewGuid()
        };

        try
        {
            using (soccerContext context = new soccerContext())
            {
                context.Countries.Add(country);
                context.SaveChanges();
            }
          
        }
        catch (Exception)
        {
            
            throw new System.InvalidOperationException("There is such country in data");
        }
    }
}