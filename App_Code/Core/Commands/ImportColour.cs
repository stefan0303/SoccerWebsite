﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoccerWebsite;

public class ImportColour : System.Web.UI.Page
{
    private string colourName;
    public ImportColour(string dataArgs)
    {
        this.colourName = dataArgs;
    }
    public void Execute()
    {

        int number = (int)((EnumColor)Enum.Parse(typeof(EnumColor), this.colourName));

        Colour colour = new Colour();
        colour.Name = number;
        Guid guid = Guid.NewGuid();
        colour.ui = guid;
        soccerContext context = new soccerContext();
        try
        {
            context.Colours.Add(colour);
            context.SaveChanges();
        }
        catch (Exception)
        {

            throw new ArgumentException("There is such colour in data");
        }
            
        
       
    }
}