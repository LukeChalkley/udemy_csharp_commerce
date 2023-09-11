using System.ComponentModel.DataAnnotations;

namespace BulkyWebApp.Models;

public class Category
{
    /// <summary>
    /// The ID of the Category, used for ORM.
    /// </summary>
    [Key]   // Using this, Entity Framework Core will know this is the Primary Key.
    // Because the name of the property is Id (Or CategoryId), Entity Framework can infer this is the Key. 
    // If the name was something else, we would need the attribute [Key] to help Entity Framework.
    public int Id { get; set; } 
    
    [Required]  // When using ORM mapping, the SQL generated will have NotNull setting to True.
    public String Name { get; set; }
    
    // I don't really understand this one yet. I feel this is more UI than Model.
    public int DisplayOrder { get; set; }
}