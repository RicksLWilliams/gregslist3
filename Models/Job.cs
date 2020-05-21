using System;
using System.ComponentModel.DataAnnotations;

namespace fullstack_gregslist.Models
{
  public class Job
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    [Required]
    public string Company { get; set; }
    [Required]
    public string JobTitle { get; set; }
    [Required]
    public int Hours { get; set; }
    [Required]
    public int Rate { get; set; }
    [Required]
    public string Description { get; set; }
  }
}
// CREATE TABLE jobs (
//   id INT NOT NULL AUTO_INCREMENT,
//   userId VARCHAR(255) NOT NULL,
//   company VARCHAR(255),
//   jobTitle VARCHAR(255),
//   hours int,
//   rate int,
//   description VARCHAR(255),
//   PRIMARY KEY (id)
// );