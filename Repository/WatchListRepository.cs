using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;
using StockAppWebApi.Services;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Repository
{
	public class WatchListRepository: IWatchListRepository
	{
		private readonly StockAppContext _context;
		private readonly IConfiguration _config;

		public WatchListRepository(StockAppContext context, IConfiguration config)
		{
			_context = context;
			_config = config;
		}

		public async Task<WatchList> AddStockToWatchList(AddStockToWatchListViewModel addStockToWatchListViewModel)
		{
			var newWatchList = new WatchList
			{
				StockId = addStockToWatchListViewModel.StockId,
				UserId = addStockToWatchListViewModel.UserId,
			};

			_context.WatchLists.Add(newWatchList);
			await _context.SaveChangesAsync();

			return newWatchList;
		}

		public async Task<WatchList?> GetWatchList(AddStockToWatchListViewModel addStockToWatchListViewModel)
		{
			return await _context.WatchLists.FirstOrDefaultAsync(u => u.StockId == addStockToWatchListViewModel.StockId && 
			        u.UserId == addStockToWatchListViewModel.UserId);
		}
	}
}
