using System.Net.NetworkInformation;

namespace StockAppWebApi.ViewModels


{
    public class PagingResultViewModel<T>
    {
        public List<T> Data { get; set; }
        public PagingInfo Paging { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((double)Paging.TotalItems / Paging.PageSize);
            }
        }

        public PagingResultViewModel(List<T> items, int totalItems, int pageNumber, int pageSize)
        {
            Data = items;
            Paging = new PagingInfo
            {
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
