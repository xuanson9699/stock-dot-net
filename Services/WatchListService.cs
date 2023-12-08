using StockAppWebApi.Models;
using StockAppWebApi.Repositories;
using StockAppWebApi.Repository;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Services
{
	public class WatchListService : IWatchListService
	{
		private readonly IWatchListRepository _watchListRepository;
		private readonly IUserRepository _userRepository;

		public WatchListService(IWatchListRepository watchListRepository, IUserRepository userRepository)
		{
			_watchListRepository = watchListRepository;
			_userRepository = userRepository;
		}

		public async Task<WatchList> AddStockToWatchList(AddStockToWatchListViewModel addStockToWatchListViewModel)
		{
			var user = await _userRepository.GetById(addStockToWatchListViewModel.UserId);
			if (user == null)
			{
				throw new ArgumentException("Username is not exists");
			}
			// Gọi UserRepository để lấy danh sách user
			return await _watchListRepository.AddStockToWatchList(addStockToWatchListViewModel);
		}

		public async Task<WatchList?> GetWatchList(AddStockToWatchListViewModel addStockToWatchListViewModel)
		{
			// Gọi UserRepository để lấy danh sách user
			return await _watchListRepository.GetWatchList(addStockToWatchListViewModel);
		}
	}
}
