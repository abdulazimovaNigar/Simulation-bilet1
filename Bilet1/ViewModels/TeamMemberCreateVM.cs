namespace Bilet1.ViewModels
{
    public class TeamMemberCreateVM
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile Image { get; set; } = null!;
        public int PositionId { get; set; }
    }
}
