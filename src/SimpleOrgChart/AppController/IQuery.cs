namespace SimpleOrgChart.AppController
{
	public interface IQuery<T,R>
	{
		R Query(T queryData);
	}
}
