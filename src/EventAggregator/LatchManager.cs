using System;
using System.Collections.Generic;

namespace EventAggregator
{
	public class LatchManager<T>
	{	
		private IList<T> CurrentLocks { get; set; }

		public LatchManager()
		{
			CurrentLocks = new List<T>();
		}

		public void RunWithLock(T lockType, Action action)
		{
			if (CurrentLocks.Contains(lockType))
				return;

			CurrentLocks.Add(lockType);
			action();
			CurrentLocks.Remove(lockType);
		}
	}
}