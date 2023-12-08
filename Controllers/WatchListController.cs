using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Attributes;
using StockAppWebApi.Models;
using StockAppWebApi.Services;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WatchListController : ControllerBase
	{

		private readonly IWatchListService _watchListService;
		public WatchListController(IWatchListService watchListService)
		{
			_watchListService = watchListService;
		}

		[HttpGet("add-stock-watch-list/{stockId}")]
		[JwtAuthorize]
		public async Task<IActionResult> AddStockToWatchList(int stockId)
		{
			try
			{
				if (HttpContext.Items["UserId"] is int userId)
				{
					var addStockToWatchListViewModel = new AddStockToWatchListViewModel { StockId = stockId, UserId = userId };

					var data = await _watchListService.AddStockToWatchList(addStockToWatchListViewModel);
					return Ok(data);
				}
				return StatusCode(500, $"Internal server error");
			}

			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}
