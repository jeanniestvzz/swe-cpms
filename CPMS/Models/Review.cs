using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Models
{
    [Table("Reviews")]
    public partial class Review
    {
        [Key]
        [Column("ReviewID")]
        public int ReviewId { get; set; }
        [Column("PaperID")]
        public int? PaperId { get; set; }
        [Column("ReviewerID")]
        public int? ReviewerId { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? AppropriatenessOfTopic { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? TimelinessOfTopic { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? SupportiveEvidence { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? TechnicalQuality { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? ScopeOfCoverage { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? CitationOfPreviousWork { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? Originality { get; set; }
        public string? ContentComments { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? OrganizationOfPaper { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? ClarityOfMainMessage { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? Mechanics { get; set; }
        public string? WrittenDocumentComments { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? SuitabilityForPresentation { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? PotentialInterestInTopic { get; set; }
        public string? PotentialForOralPresentationComments { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? OverallRating { get; set; }
        public string? OverallRatingComments { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? ComfortLevelTopic { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal? ComfortLevelAcceptability { get; set; }
        public bool? Complete { get; set; }

        [ForeignKey("PaperId")]
        [InverseProperty("Reviews")]
        public virtual Paper? Paper { get; set; }
        [ForeignKey("ReviewerId")]
        [InverseProperty("Reviews")]
        public virtual Reviewer? Reviewer { get; set; }
    }
}
