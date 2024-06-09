namespace BiuroPodrozy.Data.Utilities.Others
{
    public class ConnectNavigationProperties<T, Q>
    {
        public async Task<bool> Connect(T firstModel, Q secondModel, string idPropertyName)
        {
            try
            {
                var propertyT = typeof(T).GetProperty(secondModel.GetType().Name);
                var propertyQ = typeof(Q).GetProperty(firstModel.GetType().Name);
                var propertyTId = typeof(T).GetProperty(idPropertyName);

                var propertyValueQId = typeof(Q).GetProperty(idPropertyName).GetValue(secondModel);

                propertyT.SetValue(firstModel, secondModel);
                propertyTId.SetValue(firstModel, propertyValueQId);
                propertyQ.SetValue(secondModel, firstModel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
