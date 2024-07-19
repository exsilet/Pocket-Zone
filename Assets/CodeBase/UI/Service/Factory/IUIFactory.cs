using CodeBase.Infrastructure.Services;
using CodeBase.UI.Form;
using UnityEngine;

namespace CodeBase.UI.Service.Factory
{
    public interface IUIFactory : IService 
    { 
        GameObject CreateUIRoot();
        ViewInventory ViewInventory { get; }
        ViewObject View { get; }
    }
}