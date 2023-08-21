using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MusicAPI.Models;
using MusicAPI.Services;

namespace MusicAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MusicController : ControllerBase
	{
		private readonly IMusicService _musicService;

		public MusicController(IMusicService musicService)
		{
			_musicService = musicService;
		}

		[HttpGet]
		public async Task<ActionResult<List<MusicModel>>> GetAllSongs()
		{
			var request = await _musicService.GetAllSongs();
			if(request == null)
			{
				return NotFound("Music Not Found");
			}
			return Ok(request);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetSong(int id)
		{
			var request = await _musicService.GetSong(id);
			if(request == null)
			{
				return NotFound("Music Not Found");
			}
			return Ok(request);
		}

		[HttpPost]
		public async Task<IActionResult> AddSong(MusicModel song)
		{
			var request = await _musicService.AddSong(song);
			return Ok(request);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSong(int id)
		{
			var result = await _musicService.DeleteSong(id);

			if(result == null)
			{
				return NotFound("Music Not Found");
			}
			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSong(int id, MusicModel request)
		{
			var result = await _musicService.UpdateSong(id, request);

			if(result == null)
			{
				return NotFound("Music Not Found");
			}
			return Ok(result);
		}

		[HttpGet("composer/{composer}")]
		public async Task<IActionResult> GetSongByComposer(string composer)
		{
			var result = await _musicService.GetSongByComposer(composer);

			if (result == null)
			{
				return NotFound("Music Not Found");
			}
			return Ok(result);
		}

		[HttpGet("genre/{genre}")]
		public async Task<IActionResult> GetSongByGenre(string genre)
		{
			var result = await _musicService.GetSongByGenre(genre);

			if (result == null)
			{
				return NotFound("Music Not Found");
			}
			return Ok(result);
		}

		[HttpGet("stereo/")]
		public async Task<IActionResult> GetAllStereoSongs()
		{
			var result = await _musicService.GetAllStereoSongs();

			if (result == null)
			{
				return NotFound("Music Not Found");
			}
			return Ok(result);
		}

		[HttpGet("launchYear/{launchYear}")]
		public async Task<IActionResult> GetSongByLaunchYear(int launchYear)
		{
			var result = await _musicService.GetSongByLaunchYear(launchYear);

			if (result == null)
			{
				return NotFound("Music Not Found");
			}
			return Ok(result);
		}
	}
}
