using Bilet1.Common;

namespace Bilet1.Models
{
    public class MemberPosition : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TeamMember> Members { get; set; } = [];
    }
}
