using System;

public class Validator
{
	public static Clarity ValidateClarity(string clarity)
	{
		bool valid = Enum.TryParse<Clarity>(clarity, out Clarity result);

		if (valid == false)
		{
			throw new InvalidClarityException();
		}

		return result;
	}

	public static Rarity ValidateRarity(string rarity)
	{
		bool valid = Enum.TryParse<Rarity>(rarity, out Rarity result);

		if (valid == false)
		{
			throw new InvalidClarityException();
		}

		return result;
	}

	public static void ValidateSocket(int socket, IGem[] sockets)
	{
		if (socket < 0 || socket >= sockets.Length)
		{
			throw new InvalidSocketException();
		}
	}

	public static void ValidateType(Type typeToCheck, Type baseType)
	{
		if (typeToCheck == null)
		{
			throw new InvalidTypeException(typeToCheck.Name);
		}

		if (baseType.IsAssignableFrom(typeToCheck) == false)
		{
			throw new WrongTypeException(typeToCheck.Name, baseType.Name);
		}
	}

	public static void ValidateCommand(Type command, Type baseType)
	{
		if (command == null)
		{
			throw new InvalidCommandException();
		}

		if (baseType.IsAssignableFrom(command) == false)
		{
			throw new NotACommandException(command.Name);
		}
	}
}