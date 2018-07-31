namespace _03BarracksFactory.Core.Commands
{
	using System;
	using Contracts;
	public class RetireCommand : Command
	{
		[Inject]
		private IRepository repository;

		public RetireCommand(string[] data, IRepository repository)
			: base(data)
		{
			this.Repository = repository;
		}

		public IRepository Repository
		{
			get { return this.repository; }
			private set { this.repository = value; }
		}

		public override string Execute()
		{
			string unitType = Data[1];

			try
			{
				this.Repository.RemoveUnit(unitType);
				return $"{unitType} retired!";
			}
			catch(Exception e)
			{
				throw new ArgumentException("No such units in repository.", e);
			}
		}
	}
}
