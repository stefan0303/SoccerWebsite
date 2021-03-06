﻿using Models;
using System;
using System.Linq;

internal class ImportTown : IImport
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
        Town town = new Town
        {
            Name = name,
            ui = Guid.NewGuid()
        };

        soccerContext context = new soccerContext();
        try
        {
            Country country = context.Countries.FirstOrDefault(c => c.Name == countryName);
            country.Towns.Add(town);//Add town to this country
            town.Country_ui = country.ui;
            context.SaveChanges();
        }
        catch (Exception)
        {

            throw new System.InvalidOperationException("There is such town in data");
        }
    }
}