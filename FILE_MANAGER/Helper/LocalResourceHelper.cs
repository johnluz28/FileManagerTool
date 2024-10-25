using System.Collections.Generic;
using System.IO;
using FILE_MANAGER.Model;

namespace FILE_MANAGER.Helper
{
	public static class LocalResourceHelper
	{
		public static IEnumerable<LocalResourceData> GetLocalResource()
		{
			var lData = new List<LocalResourceData>();
			using (var reader = new StreamReader($"DATA\\ALL.csv"))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');

					lData.Add(new LocalResourceData()
					{
						Id = values[0],
						IconName = values[1],
						Currency = values[2]
					});
				}
			}
			return lData;
		}
	}
}
