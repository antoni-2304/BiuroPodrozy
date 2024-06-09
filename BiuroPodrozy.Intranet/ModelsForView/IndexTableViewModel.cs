namespace BiuroPodrozy.Intranet.ModelsForView
{
	public class IndexTableViewModel<T>
	{
		public IEnumerable<T>? Items { get; set; }
		public int ItemsPerPage { get; set; } = 10;
		public int CurrentPage { get; set; }
		public string ModelNameTranslatedList { get; set; } = String.Empty;
		public string ModelNameTranslatedAdd { get; set; } = String.Empty;

		public readonly string ModelName = typeof(T).Name;

		public int PageCount() => (int)Math.Ceiling((double)Items.Count() / ItemsPerPage);

		public IEnumerable<T> PaginatedItems()
		{
			int start = (CurrentPage - 1) * ItemsPerPage;
			return Items.Skip(start).Take(ItemsPerPage);
		}
	}
}