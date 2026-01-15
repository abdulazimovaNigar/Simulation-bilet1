namespace Bilet1.ViewModels
{
    public class TeamMemberUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile Image { get; set; } = null!;

        public int MemberPositionId { get; set; }
    }
}
