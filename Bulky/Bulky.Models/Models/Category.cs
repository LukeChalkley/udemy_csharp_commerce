using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models;

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
    [DisplayName("Category Name")]
    [MinLength(5, ErrorMessage = "Category Name must be 5 to 30 characters in length.")]
    [MaxLength(30, ErrorMessage = "Category Name must be 5 to 30 characters in length.")]
    public String Name { get; set; }
    
    // I don't really understand this one yet. I feel this is more UI than Model.
    [DisplayName("Display Order")]
    [Range(1,100, ErrorMessage = "Display Order must be between 1 and 30.")]
    public int DisplayOrder { get; set; }
}