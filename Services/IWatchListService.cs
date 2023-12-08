using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Services
{
	public interface IWatchListService
	{
		Task<WatchList> AddStockToWatchList(AddStockToWatchListViewModel addStockToWatchListViewModel);

		Task<WatchList> GetWatchList(AddStockToWatchListViewModel addStockToWatchListViewModel);
	}
}
