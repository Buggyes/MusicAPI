using Microsoft.EntityFrameworkCore;

using MusicAPI.Data;
using MusicAPI.Models;

namespace MusicAPI.Services
{
	public class MusicService : IMusicService
	{
		private readonly DataContext _dataContext;

		public MusicService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<List<MusicModel>> GetAllSongs()
		{
			List<MusicModel> songs = await _dataContext.Songs.ToListAsync();
			return songs;
		}

		public async Task<MusicModel?> GetSong(int id)
		{
			var song = await _dataContext.Songs.FindAsync(id);
			if(song == null)
			{
				return null;
			}
			return song;
		}

		public async Task<List<MusicModel>> AddSong(MusicModel song)
		{
			_dataContext.Songs.Add(song);
			await _dataContext.SaveChangesAsync();
			return await GetAllSongs();
		}

		public async Task<List<MusicModel>?> DeleteSong(int id)
		{
			var songDb = await _dataContext.Songs.FindAsync(id);
			if(songDb == null)
			{
				return null;
			}
			_dataContext.Songs.Remove(songDb);
			await _dataContext.SaveChangesAsync();
			return await GetAllSongs();
		}

		public async Task<List<MusicModel>?> UpdateSong(int id, MusicModel songRequest)
		{
			var songDb = await _dataContext.Songs.FindAsync(id);
			if(songDb == null)
			{
				return null;
			}

			songDb.Name = songRequest.Name;
			songDb.Composer = songRequest.Composer;
			songDb.Duration = songRequest.Duration;
			songDb.Genre = songRequest.Genre;
			songDb.HasStereoSound = songRequest.HasStereoSound;
			songDb.LaunchYear = songRequest.LaunchYear;

			_dataContext.Update(songDb);
			await _dataContext.SaveChangesAsync();

			return await GetAllSongs();
		}

		public async Task<List<MusicModel>?> GetSongByComposer(string composer)
		{
			var songs = await _dataContext.Songs.Where(s => s.Composer == composer).ToListAsync();

			if(songs == null)
			{
				return null;
			}
			return songs;
		}

		public async Task<List<MusicModel>?> GetSongByGenre(string genre)
		{
			var songs = await _dataContext.Songs.Where(s => s.Genre == genre).ToListAsync();
			
			if(songs == null)
			{
				return null;
			}
			return songs;
		}

		public async Task<List<MusicModel>?> GetAllStereoSongs()
		{
			var songs = await _dataContext.Songs.Where(s => s.HasStereoSound == true).ToListAsync();

			if(songs == null)
			{
				return null;
			}
			return songs;
		}

		public async Task<List<MusicModel>?> GetSongByLaunchYear(int launchYear)
		{
			var songs = await _dataContext.Songs.Where(s => s.LaunchYear == launchYear).ToListAsync();

			if(songs == null)
			{
				return null;
			}
			return songs;
		}
	}
}
