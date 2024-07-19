using System;
using CodeBase.UI.Form;
using CodeBase.UI.Service.Windows;

namespace CodeBase.Infrastructure.StaticData.Windows
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        public BaseWindow Prefab;
    }
}
