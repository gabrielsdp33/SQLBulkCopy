namespace BulkCopyCSV.Infra.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Movies
    {
        [Display(Name = "")]
        public int Id { get; set; }

        [Display(Name = "Gender")]
        [StringLength(255)]
        public string Gender { get; set; }

        [Display(Name = "LeadStudio")]
        [StringLength(255)]
        public string LeadStudio { get; set; }

        [Display(Name = "AudienceScorePercentage")]
        [StringLength(255)]
        public string AudienceScorePercentage { get; set; }

        [Display(Name = "Profability")]
        [StringLength(255)]
        public string Profability { get; set; }

        [Display(Name = "RottenTomatoesPercentage")]
        [StringLength(255)]
        public string RottenTomatoesPercentage { get; set; }

        [Display(Name = "WorldwideGross")]
        [StringLength(255)]
        public string WorldwideGross { get; set; }

        [Display(Name = "Year")]
        [StringLength(255)]
        public string Year { get; set; }
    }
}
