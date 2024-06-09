namespace BiuroPodrozy.Data.ViewModels.AbstractViewModels
{
    abstract public class AbstractTwoModels<T, Q>
    {
        public T? FirstModel { get; set; }
        public Q? SecondModel { get; set; }
    }
}