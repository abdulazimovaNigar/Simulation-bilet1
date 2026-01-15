using Bilet1.Common;

namespace Bilet1.Models
{
    public class TeamMember : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int MemberPositionId { get; set; }
        public MemberPosition MemberPosition { get; set; } = null;
    }
}
