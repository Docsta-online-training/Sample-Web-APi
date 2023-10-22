using Newtonsoft.Json;

namespace EntityFrameworkDemo.Models;


/* 
 * Student class:
 * 
 * Address property: This represents a 1:1 relationship. Each student has one address.
 * MarkList property: This represents a 1 to Many relationship. Each student can have multiple marks.
 * TeamList property: This represents a Many to Many relationship. Each student can belong to multiple teams, and each team can have multiple students.
 * 
 * Team class:
 * 
 * StudentList property: This represents a Many to Many relationship. Each team can have multiple students, and each student can belong to multiple teams.
 */
public class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string? LastName { get; set; }


    // Navigation Property
    public Address? Address { get; set; } // 1:1  

    public List<Mark>? MarkList { get; set; } = new List<Mark>(); //1 to Many

    
    public List<Team>? TeamList { get; set; } = new(); // Manay To Many


}

public class Address
{
    public int Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
}

public class Mark
{
    public int Id { get; set; }

    public string Name { get; set; } = null!; //Subject Name

    public int  MarkObtained { get; set; }

    public int MaxMark { get; set; } = 100;

}

public class Team
{
    public int Id { get; set; }

    public string Name { get; set; }=null!;

    public List<Student>? StudentList { get; set; } = new(); //Many to Many

}

/// <summary>
/// ///////////////////////////////////////////////////  View Models /////////////////////////////////////////
/// </summary>
public class StudentListViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Mark>? MarkList { get; set; }

    public int TotalMark { get; set; }

    public Mark Highest { get; set; }

    public Team SearchTeam { get; set; }

    

}

public class TeamListViewModel
{
    public string TeamName { get; set; }
    public List<StudentViewModel>? StudentList { get; set; } = new();
}

public class StudentViewModel
{

    public int Id { get; set; }
    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public Address Address { get; set; }

    public List<Mark> MarkList { get; set; } = new();
}



