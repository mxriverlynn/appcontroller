namespace SimpleOrgChart.App
{
	public class Result<T>
	{
		public ServiceResult ServiceResult { get; private set; }
		public T Data { get; private set; }

		public Result(ServiceResult serviceResult): this(serviceResult, default(T)){}

		public Result(ServiceResult serviceResult, T data)
		{
			ServiceResult = serviceResult;
			Data = data;
		}
	}
}