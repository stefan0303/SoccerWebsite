using System;
using Models;

internal class ImportColour : System.Web.UI.Page, IImport
{
    private string colourName;
    public ImportColour(string dataArgs)
    {
        this.colourName = dataArgs;
    }
    public void Execute()
    {

        int number = (int)((EnumColor)Enum.Parse(typeof(EnumColor), this.colourName));

        Colour colour = new Colour
        {
            Name = number
        };
        Guid guid = Guid.NewGuid();
        colour.ui = guid;
        
        try
        {
            using (soccerContext context = new soccerContext())
            {
                context.Colours.Add(colour);
                context.SaveChanges();
            }
           
        }
        catch (Exception)
        {

            throw new ArgumentException("There is such colour in data");
        }
            
        
       
    }
}