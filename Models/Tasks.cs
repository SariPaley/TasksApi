using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TasksApi.Models;

public partial class Tasks
{
    [Key]
    public int TaskId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? UserId { get; set; }

    public int? ProjectId { get; set; }

    public virtual Users? User { get; set; }
}
