 namespace P01_HarvestingFields
{
    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using System.Text;

	public class HarvestingFieldsTest
    {
        public static void Main()
        {
			Type type = typeof(HarvestingFields);

			FieldInfo[] allFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			IEnumerable<FieldInfo> publicFields = allFields.Where(m => m.IsPublic);
			IEnumerable<FieldInfo> privateFields = allFields.Where(m => m.IsPrivate);
			IEnumerable<FieldInfo> protectedFields = allFields.Where(m => m.IsFamily);

			string command;

			while ((command = Console.ReadLine()) != "HARVEST")
			{
				switch (command)
				{
					case "private":
						PrintFields(privateFields, command);
						break;
					case "protected":
						PrintFields(protectedFields, command);
						break;
					case "public":
						PrintFields(publicFields, command);
						break;
					case "all":
						PrintFields(allFields, command);
						break;
				}
			}
		}

		public static void PrintFields(IEnumerable<FieldInfo> fields, string command)
		{
			StringBuilder builder = new StringBuilder();

			foreach (var field in fields)
			{
				string accessModifier = field.IsPrivate ? "private" : field.IsFamily ? "protected" : "public";
				builder.AppendLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
			}

			string result = builder.ToString().TrimEnd();
			Console.WriteLine(result);
		}
	}
}
