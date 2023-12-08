using StockAppWebApi.Models;
using StockAppWebApi.Services;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Repository
{
	public interface IWatchListRepository
	{
		Task<WatchList> AddStockToWatchList(AddStockToWatchListViewModel addStockToWatchListViewModel);

		Task<WatchList?> GetWatchList(AddStockToWatchListViewModel addStockToWatchListViewModel);
	}
}
