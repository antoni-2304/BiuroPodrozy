namespace BiuroPodrozy.Intranet.ModelsForView
{
	public class DeleteItemViewModel<T>
	{
		public T? Item { get; set; }
		public int? ItemId { get; set; }

		public readonly string ModelName = typeof(T).Name;
	}
}
