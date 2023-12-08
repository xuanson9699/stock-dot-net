using StockAppWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.ViewModels
{
	public class AddStockToWatchListViewModel
	{
		[Required(ErrorMessage = "UserId is required")]
		public int UserId { get; set; }

		[Required(ErrorMessage = "StockId is required")]
		public int StockId { get; set; }
	}
}
