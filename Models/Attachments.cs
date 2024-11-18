namespace TasksApi.Models
{
    public class Attachments
    {
        public int AttachId { get; set; }

        public string?  AttachPath { get; set; }

        public string? UploadDate { get; set; }

        public Tasks? Task { get; set; }
    }
}
