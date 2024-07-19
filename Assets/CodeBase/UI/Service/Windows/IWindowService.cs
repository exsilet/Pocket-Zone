using CodeBase.Infrastructure.Services;

namespace CodeBase.UI.Service.Windows
{
    public interface IWindowService : IService
    {
        void Open(WindowId windowID);
    }
}