using Dalamud.Game.Command;
using System;

namespace Glamaholic {
    internal class Commands : IDisposable {
        // 本家と同時に入れても衝突しないよう、別のコマンド名にしている
        private const string CommandName = "/glamjp";

        private Plugin Plugin { get; }

        internal Commands(Plugin plugin) {
            this.Plugin = plugin;

            Service.CommandManager.AddHandler(CommandName, new CommandInfo(this.OnCommand) {
                HelpMessage = Loc.CommandHelp(Plugin.Name),
            });
        }

        public void Dispose() {
            Service.CommandManager.RemoveHandler(CommandName);
        }

        private void OnCommand(string command, string arguments) {
            this.Plugin.Ui.ToggleMainInterface();
        }
    }
}
