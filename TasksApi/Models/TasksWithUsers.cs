namespace TasksApi.Models
{
    public class TasksWithUsers
    {
        public int TaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
    }
}
