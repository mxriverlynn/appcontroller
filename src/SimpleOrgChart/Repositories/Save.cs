namespace SimpleOrgChart.Repositories
{
	public class Save<T>
	{
		public T ObjectToSave { get; set; }

		public Save(T objToSave)
		{
			ObjectToSave = objToSave;
		}
	}
}