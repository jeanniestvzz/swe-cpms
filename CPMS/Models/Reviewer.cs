using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Models
{
    [Table("Reviewers")]
    public partial class Reviewer
    {
        public Reviewer()
        {
            Reviews = new HashSet<Review>();
        }

        [Key]
        [Column("ReviewerID")]
        public int ReviewerId { get; set; }
        public bool? Active { get; set; }
        [StringLength(9)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? MiddleInitial { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(50)]
        public string? Affiliation { get; set; }
        [StringLength(50)]
        public string? Department { get; set; }
        [StringLength(50)]
        public string? Address { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        [StringLength(2)]
        public string? State { get; set; }
        [StringLength(10)]
        public string? ZipCode { get; set; }
        [StringLength(50)]
        public string? PhoneNumber { get; set; }
        [StringLength(100)]
        public string? EmailAddress { get; set; }
        [StringLength(5)]
        public string? Password { get; set; }
        public bool? AnalysisOfAlgorithms { get; set; }
        public bool? Applications { get; set; }
        public bool? Architecture { get; set; }
        public bool? ArtificialIntelligence { get; set; }
        public bool? ComputerEngineering { get; set; }
        public bool? Curriculum { get; set; }
        public bool? DataStructures { get; set; }
        public bool? Databases { get; set; }
        public bool? DistancedLearning { get; set; }
        public bool? DistributedSystems { get; set; }
        public bool? EthicalSocietalIssues { get; set; }
        public bool? FirstYearComputing { get; set; }
        public bool? GenderIssues { get; set; }
        public bool? GrantWriting { get; set; }
        public bool? GraphicsImageProcessing { get; set; }
        public bool? HumanComputerInteraction { get; set; }
        public bool? LaboratoryEnvironments { get; set; }
        public bool? Literacy { get; set; }
        public bool? MathematicsInComputing { get; set; }
        public bool? Multimedia { get; set; }
        public bool? NetworkingDataCommunications { get; set; }
        public bool? NonMajorCourses { get; set; }
        public bool? ObjectOrientedIssues { get; set; }
        public bool? OperatingSystems { get; set; }
        public bool? ParallelProcessing { get; set; }
        public bool? Pedagogy { get; set; }
        public bool? ProgrammingLanguages { get; set; }
        public bool? Research { get; set; }
        public bool? Security { get; set; }
        public bool? SoftwareEngineering { get; set; }
        public bool? SystemsAnalysisAndDesign { get; set; }
        public bool? UsingTechnologyInTheClassroom { get; set; }
        public bool WebAndInternetProgramming { get; set; }
        public bool? Other { get; set; }
        [StringLength(50)]
        public string? OtherDescription { get; set; }
        public bool? ReviewsAcknowledged { get; set; }

        [InverseProperty("Reviewer")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
