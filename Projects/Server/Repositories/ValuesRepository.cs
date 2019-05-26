using Server.Repositories.Interfaces;

namespace Server.Repositories
{
	public class ValuesRepository : IValuesRepository
	{
		public string[] GetValues()
		{
			return new[] {"value 1", "value 2"};
		}
	}
}