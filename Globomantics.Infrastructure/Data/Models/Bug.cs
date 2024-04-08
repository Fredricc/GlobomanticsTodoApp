using Globomantics.Domain;

namespace Globomantics.Infrastructure.Data.Models
{
    public class Bug : TodoTask
    {
        public string Description { get; set; } = default!;
        public User? CreatedBy { get; set; } = default!;
        public User? AssignedTo { get; set; } = default!;
        public Severity Severity { get; set; }
        public string AffectedVersion { get; set; } = default!;
        public int AffectedUsers { get; set; }

        public virtual ICollection<Image> Images { get; set; } = default!;
    }
}
