﻿using ToolBox.Bridge;
using ToolBox.Platform;

namespace OpenRepo.Services
{
    public static class TerminalService
    {
        private static ShellConfigurator m_instance;
        private static ShellConfigurator Instance
        {
            get
            {
                if(m_instance == null)
                {
                    var bridgeSystem = OS.GetCurrent() == "win" ? BridgeSystem.Bat : BridgeSystem.Bash;
                    m_instance = new ShellConfigurator(bridgeSystem);
                }

                return m_instance;
            }
        }

        public static void OpenTerminal(string path)
        {
            Instance.Term("cd " + path, Output.External);
        }
    }
}
