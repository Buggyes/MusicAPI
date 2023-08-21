namespace MusicAPI.Models
{
	public class MusicModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Composer { get; set; } = string.Empty;
		public int Duration { get; set; } //seconds
		public string Genre { get; set; } = string.Empty;
		public bool HasStereoSound { get; set; }
		public int LaunchYear { get; set; }
	}
}
