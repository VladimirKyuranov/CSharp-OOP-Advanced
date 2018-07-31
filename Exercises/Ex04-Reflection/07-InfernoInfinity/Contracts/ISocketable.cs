public interface ISocketable
{
	int SocketCount { get; }

	IGem[] Sockets { get; }

	void AddGem(IGem gem, int index);

	void RemoveGem(int index);
}