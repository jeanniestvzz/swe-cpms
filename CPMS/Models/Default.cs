using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Models
{
    [Keyless]
    public partial class Default
    {
        public bool? EnabledReviewers { get; set; }
        public bool? EnabledAuthors { get; set; }
    }
}
