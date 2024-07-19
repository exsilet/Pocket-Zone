using CodeBase.Infrastructure.StaticData.Windows;
using CodeBase.UI.Service.Windows;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        WindowConfig ForWindow(WindowId windowID);
    }
}