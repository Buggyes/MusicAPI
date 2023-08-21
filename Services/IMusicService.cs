using MusicAPI.Models;

namespace MusicAPI.Services
{
	public interface IMusicService
	{
		Task<List<MusicModel>> GetAllSongs();
		Task<MusicModel?> GetSong(int id);
		Task<List<MusicModel>> AddSong(MusicModel song);
		Task<List<MusicModel>?> DeleteSong(int id);
		Task<List<MusicModel>?> UpdateSong(int id, MusicModel songRequest);
		Task<List<MusicModel>?> GetSongByComposer(string composer);
		Task<List<MusicModel>?> GetSongByGenre(string genre);
		Task<List<MusicModel>?> GetAllStereoSongs();
		Task<List<MusicModel>?> GetSongByLaunchYear(int launchYear);
	}
}
