using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.ViewModels
{
    public class SearchUserViewModel
    {
        public string? SearchTerm { get; set; } = "";
        public string? Filter { get; set; } = "";

        public int PageSize { get; set; } = 20;

        public int PageIndex { get; set; } = 1;
    }
}
