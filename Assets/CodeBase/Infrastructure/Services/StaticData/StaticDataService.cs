using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.StaticData.Windows;
using CodeBase.UI.Service.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataWindowsPath = "StaticData/UI/WindowStaticData";
        private Dictionary<WindowId,WindowConfig> _windowConfigs;

        public void Load()
        {
            _windowConfigs = Resources
                .Load<WindowStaticData>(StaticDataWindowsPath)
                .Configs
                .ToDictionary(x => x.WindowId, x => x);
        }

        public WindowConfig ForWindow(WindowId windowID) =>
            _windowConfigs.TryGetValue(windowID, out WindowConfig windowConfig) 
                ? windowConfig 
                : null;
    }
}