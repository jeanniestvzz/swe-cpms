using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CPMS.Models;

namespace CPMS.Data
{
    public partial class CPMSContext : DbContext
    {
        public CPMSContext()
        {
        }

        public CPMSContext(DbContextOptions<CPMSContext> options)
            : base(options)
        {
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263. 
                optionsBuilder.UseSqlServer("Server=JEANNIE-ESTEVEZ; Database=CPMS; User ID=ADMIN; Password=cpmsadmin; trusted_connection=yes;"); 
            } 
        }*/

        // Query and save instances of all entities (Authors, Papers, Reviews, and Reviewers) from the database
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Default> Defaults { get; set; } = null!;
        public virtual DbSet<Paper> Papers { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Reviewer> Reviewers { get; set; } = null!;

        // Builds all models for each entity and states various properties they have
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Address).HasDefaultValueSql("('')");

                entity.Property(e => e.Affiliation).HasDefaultValueSql("('')");

                entity.Property(e => e.City).HasDefaultValueSql("('')");

                entity.Property(e => e.Department).HasDefaultValueSql("('')");

                entity.Property(e => e.EmailAddress).HasDefaultValueSql("('')");

                entity.Property(e => e.FirstName).HasDefaultValueSql("('')");

                entity.Property(e => e.LastName).HasDefaultValueSql("('')");

                entity.Property(e => e.MiddleInitial).HasDefaultValueSql("('')");

                entity.Property(e => e.Password).HasDefaultValueSql("('')");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("('')");

                entity.Property(e => e.State).HasDefaultValueSql("('')");

                entity.Property(e => e.ZipCode).HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Default>(entity =>
            {
                entity.Property(e => e.EnabledAuthors).HasDefaultValueSql("((0))");

                entity.Property(e => e.EnabledReviewers).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Paper>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.AnalysisOfAlgorithms).HasDefaultValueSql("((0))");

                entity.Property(e => e.Applications).HasDefaultValueSql("((0))");

                entity.Property(e => e.Architecture).HasDefaultValueSql("((0))");

                entity.Property(e => e.ArtificialIntelligence).HasDefaultValueSql("((0))");

                entity.Property(e => e.Certification).HasDefaultValueSql("('')");

                entity.Property(e => e.ComputerEngineering).HasDefaultValueSql("((0))");

                entity.Property(e => e.Curriculum).HasDefaultValueSql("((0))");

                entity.Property(e => e.DataStructures).HasDefaultValueSql("((0))");

                entity.Property(e => e.Databases).HasDefaultValueSql("((0))");

                entity.Property(e => e.DistanceLearning).HasDefaultValueSql("((0))");

                entity.Property(e => e.DistributedSystems).HasDefaultValueSql("((0))");

                entity.Property(e => e.EthicalSocietalIssues).HasDefaultValueSql("((0))");

                entity.Property(e => e.Filename).HasDefaultValueSql("('')");

                entity.Property(e => e.FilenameOriginal).HasDefaultValueSql("('')");

                entity.Property(e => e.FirstYearComputing).HasDefaultValueSql("((0))");

                entity.Property(e => e.GenderIssues).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrantWriting).HasDefaultValueSql("((0))");

                entity.Property(e => e.GraphicsImageProcessing).HasDefaultValueSql("((0))");

                entity.Property(e => e.HumanComputerInteraction).HasDefaultValueSql("((0))");

                entity.Property(e => e.LaboratoryEnvironments).HasDefaultValueSql("((0))");

                entity.Property(e => e.Literacy).HasDefaultValueSql("((0))");

                entity.Property(e => e.MathematicsInComputing).HasDefaultValueSql("((0))");

                entity.Property(e => e.Multimedia).HasDefaultValueSql("((0))");

                entity.Property(e => e.NetworkingDataCommunications).HasDefaultValueSql("((0))");

                entity.Property(e => e.NonMajorCourses).HasDefaultValueSql("((0))");

                entity.Property(e => e.NotesToReviewers).HasDefaultValueSql("('')");

                entity.Property(e => e.ObjectOrientedIssues).HasDefaultValueSql("((0))");

                entity.Property(e => e.OperatingSystems).HasDefaultValueSql("((0))");

                entity.Property(e => e.Other).HasDefaultValueSql("((0))");

                entity.Property(e => e.OtherDescription).HasDefaultValueSql("('')");

                entity.Property(e => e.ParallelsProcessing).HasDefaultValueSql("((0))");

                entity.Property(e => e.Pedagogy).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProgrammingLanguages).HasDefaultValueSql("((0))");

                entity.Property(e => e.Research).HasDefaultValueSql("((0))");

                entity.Property(e => e.Security).HasDefaultValueSql("((0))");

                entity.Property(e => e.SoftwareEngineering).HasDefaultValueSql("((0))");

                entity.Property(e => e.SystemsAnalysisAndDesign).HasDefaultValueSql("((0))");

                entity.Property(e => e.Title).HasDefaultValueSql("('')");

                entity.Property(e => e.UsingTechnologyInTheClassroom).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Papers)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Paper_Author");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.AppropriatenessOfTopic).HasDefaultValueSql("((0))");

                entity.Property(e => e.CitationOfPreviousWork).HasDefaultValueSql("((0))");

                entity.Property(e => e.ClarityOfMainMessage).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComfortLevelAcceptability).HasDefaultValueSql("((0))");

                entity.Property(e => e.ComfortLevelTopic).HasDefaultValueSql("((0))");

                entity.Property(e => e.Complete).HasDefaultValueSql("((0))");

                entity.Property(e => e.ContentComments).HasDefaultValueSql("('')");

                entity.Property(e => e.Mechanics).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrganizationOfPaper).HasDefaultValueSql("((0))");

                entity.Property(e => e.Originality).HasDefaultValueSql("((0))");

                entity.Property(e => e.OverallRating).HasDefaultValueSql("((0))");

                entity.Property(e => e.OverallRatingComments).HasDefaultValueSql("('')");

                entity.Property(e => e.PotentialForOralPresentationComments).HasDefaultValueSql("('')");

                entity.Property(e => e.PotentialInterestInTopic).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScopeOfCoverage).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuitabilityForPresentation).HasDefaultValueSql("((0))");

                entity.Property(e => e.SupportiveEvidence).HasDefaultValueSql("((0))");

                entity.Property(e => e.TechnicalQuality).HasDefaultValueSql("((0))");

                entity.Property(e => e.TimelinessOfTopic).HasDefaultValueSql("((0))");

                entity.Property(e => e.WrittenDocumentComments).HasDefaultValueSql("('')");

                entity.HasOne(d => d.Paper)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.PaperId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Score_Paper");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ReviewerId)
                    .HasConstraintName("FK_Review_Reviewer");
            });

            modelBuilder.Entity<Reviewer>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.Address).HasDefaultValueSql("('')");

                entity.Property(e => e.Affiliation).HasDefaultValueSql("('')");

                entity.Property(e => e.AnalysisOfAlgorithms).HasDefaultValueSql("((0))");

                entity.Property(e => e.Applications).HasDefaultValueSql("((0))");

                entity.Property(e => e.Architecture).HasDefaultValueSql("((0))");

                entity.Property(e => e.ArtificialIntelligence).HasDefaultValueSql("((0))");

                entity.Property(e => e.City).HasDefaultValueSql("('')");

                entity.Property(e => e.ComputerEngineering).HasDefaultValueSql("((0))");

                entity.Property(e => e.Curriculum).HasDefaultValueSql("((0))");

                entity.Property(e => e.DataStructures).HasDefaultValueSql("((0))");

                entity.Property(e => e.Databases).HasDefaultValueSql("((0))");

                entity.Property(e => e.Department).HasDefaultValueSql("('')");

                entity.Property(e => e.DistancedLearning).HasDefaultValueSql("((0))");

                entity.Property(e => e.DistributedSystems).HasDefaultValueSql("((0))");

                entity.Property(e => e.EmailAddress).HasDefaultValueSql("('')");

                entity.Property(e => e.EthicalSocietalIssues).HasDefaultValueSql("((0))");

                entity.Property(e => e.FirstName).HasDefaultValueSql("('')");

                entity.Property(e => e.FirstYearComputing).HasDefaultValueSql("((0))");

                entity.Property(e => e.GenderIssues).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrantWriting).HasDefaultValueSql("((0))");

                entity.Property(e => e.GraphicsImageProcessing).HasDefaultValueSql("((0))");

                entity.Property(e => e.HumanComputerInteraction).HasDefaultValueSql("((0))");

                entity.Property(e => e.LaboratoryEnvironments).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName).HasDefaultValueSql("('')");

                entity.Property(e => e.Literacy).HasDefaultValueSql("((0))");

                entity.Property(e => e.MathematicsInComputing).HasDefaultValueSql("((0))");

                entity.Property(e => e.MiddleInitial).HasDefaultValueSql("('')");

                entity.Property(e => e.Multimedia).HasDefaultValueSql("((0))");

                entity.Property(e => e.NetworkingDataCommunications).HasDefaultValueSql("((0))");

                entity.Property(e => e.NonMajorCourses).HasDefaultValueSql("((0))");

                entity.Property(e => e.ObjectOrientedIssues).HasDefaultValueSql("((0))");

                entity.Property(e => e.OperatingSystems).HasDefaultValueSql("((0))");

                entity.Property(e => e.Other).HasDefaultValueSql("((0))");

                entity.Property(e => e.OtherDescription).HasDefaultValueSql("('')");

                entity.Property(e => e.ParallelProcessing).HasDefaultValueSql("((0))");

                entity.Property(e => e.Password).HasDefaultValueSql("('')");

                entity.Property(e => e.Pedagogy).HasDefaultValueSql("((0))");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("('')");

                entity.Property(e => e.ProgrammingLanguages).HasDefaultValueSql("((0))");

                entity.Property(e => e.Research).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReviewsAcknowledged).HasDefaultValueSql("((0))");

                entity.Property(e => e.Security).HasDefaultValueSql("((0))");

                entity.Property(e => e.SoftwareEngineering).HasDefaultValueSql("((0))");

                entity.Property(e => e.State).HasDefaultValueSql("('')");

                entity.Property(e => e.SystemsAnalysisAndDesign).HasDefaultValueSql("((0))");

                entity.Property(e => e.UsingTechnologyInTheClassroom).HasDefaultValueSql("((0))");

                entity.Property(e => e.ZipCode).HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
