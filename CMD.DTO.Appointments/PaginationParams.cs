namespace CMD.DTO.Appointments
{
    public class PaginationParams
    {
        private const int _maxItemsPerPage = 8;
        private int _itemsPerPage;
        private const int _firstPage = 1;
        private int _currentPage;

        public int Page
        {
            get => _currentPage;
            set => _currentPage = value < _firstPage ? _firstPage : value;
        }

        public int ItemsPerPage
        {
            get => _itemsPerPage;
            set => _itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value;
        }
    }
}
