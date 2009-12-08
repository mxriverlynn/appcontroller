namespace SimpleOrgChart.App.NewEmployeeProcess.SupplyEmployeeInfo
{
	
	public class NewEmployeeInfoPresenter: IGetNewEmployeeInfo
	{
		private INewEmployeeInfoView View { get; set; }
		private string LastName { get; set; }
		private string FirstName { get; set; }
		private string Email { get; set; }
		private ServiceResult ServiceResult { get; set; }

		public NewEmployeeInfoPresenter(INewEmployeeInfoView view)
		{
			View = view;
			View.Presenter = this;
		}

		public void FirstNameSupplied(string firstname)
		{
			FirstName = firstname;
		}

		public void LastNameSupplied(string lastname)
		{
			LastName = lastname;
		}

		public void EmailSupplied(string email)
		{
			Email = email;
		}

		public Result<EmployeeInfo> Get()
		{
			View.Run();
			EmployeeInfo info = null;
			if (ServiceResult == ServiceResult.Ok)
			{
				info = new EmployeeInfo
					{
						FirstName = FirstName,
						LastName = LastName,
						Email = Email
					};
			}
			Result<EmployeeInfo> result = new Result<EmployeeInfo>(ServiceResult, info);
			return result;
		}

		public void Next()
		{
			ServiceResult = ServiceResult.Ok;
		}

		public void Cancel()
		{
			ServiceResult = ServiceResult.Cancel;
		}

	}

}