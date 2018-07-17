using System;

namespace API_Users.Models{

public class Keep
{
public int Id { get; set; }
public string Name { get; set; }
public string Description { get; set; }
public string AuthorId { get; set; }
public string ImageUrl {get; set;}
public int Share { get; set; }
public int View { get; set; }
public Boolean Publish {get;set;}
}



}