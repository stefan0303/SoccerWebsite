﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Colour
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Colour()
    {
        this.Teams = new HashSet<Team>();
        this.Teams1 = new HashSet<Team>();
    }

    public System.Guid ui { get; set; }
    public int C_id { get; set; }
    public int Name { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Team> Teams { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Team> Teams1 { get; set; }
}

public partial class Competition
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Competition()
    {
        this.Teams = new HashSet<Team>();
    }

    public System.Guid ui { get; set; }
    public int C_id { get; set; }
    public string Name { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Team> Teams { get; set; }
}

public partial class Country
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Country()
    {
        this.Towns = new HashSet<Town>();
    }

    public System.Guid ui { get; set; }
    public int C_id { get; set; }
    public string Name { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Town> Towns { get; set; }
}

public partial class Game
{
    public System.Guid ui { get; set; }
    public int C_id { get; set; }
    public System.Guid HomeTeam_ui { get; set; }
    public System.Guid AwayTeam_ui { get; set; }
    public int HomeTeamGoals { get; set; }
    public int AwayTeamGoals { get; set; }
    public System.DateTime Date { get; set; }

    public virtual Team Team { get; set; }
    public virtual Team Team1 { get; set; }
}

public partial class sysdiagram
{
    public string name { get; set; }
    public int principal_id { get; set; }
    public int diagram_id { get; set; }
    public Nullable<int> version { get; set; }
    public byte[] definition { get; set; }
}

public partial class Team
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Team()
    {
        this.Games = new HashSet<Game>();
        this.Games1 = new HashSet<Game>();
    }

    public System.Guid ui { get; set; }
    public int C_id { get; set; }
    public string Name { get; set; }
    public System.Guid Town_ui { get; set; }
    public System.Guid PrimaryKitColour_ui { get; set; }
    public System.Guid SecondaryKitColour_ui { get; set; }
    public System.Guid Competition_ui { get; set; }

    public virtual Colour Colour { get; set; }
    public virtual Colour Colour1 { get; set; }
    public virtual Competition Competition { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Game> Games { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Game> Games1 { get; set; }
    public virtual Town Town { get; set; }
}

public partial class Town
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Town()
    {
        this.Teams = new HashSet<Team>();
    }

    public System.Guid ui { get; set; }
    public int C_id { get; set; }
    public string Name { get; set; }
    public System.Guid Country_ui { get; set; }

    public virtual Country Country { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Team> Teams { get; set; }
}
