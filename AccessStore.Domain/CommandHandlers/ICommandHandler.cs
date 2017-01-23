using AccessStore.Domain.Commands;

namespace AccessStore.Domain.CommandHandlers
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        void Handle(T command);
    }
}
