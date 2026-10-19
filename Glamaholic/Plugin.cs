using Dalamud.Plugin;

namespace Glamaholic {
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Plugin : IDalamudPlugin {
        // 表示名だけを変える。内部名（GlamaholicJP）を変えると保存済みのプレートが読み込めなくなる
        internal static string Name => "Glamaholic Plus";

        internal Configuration Config { get; }
        internal GameFunctions Functions { get; }
        internal PluginUi Ui { get; }
        private Commands Commands { get; }
        private LanguageFont Font { get; }

#pragma warning disable 8618
        public Plugin(IDalamudPluginInterface pluginInterface) {
            pluginInterface.Create<Service>();

            // 文言は画面やコマンドを作る前に決めておく
            var hubSettings = HubSettings.Load(Service.Interface.AssemblyLocation.DirectoryName);
            Loc.Language = hubSettings.ResolveLanguage(Service.Interface.UiLanguage);
            this.Font = new LanguageFont(Service.Interface.UiBuilder, Loc.Language, hubSettings.ResolveFontPath(Loc.Language));

            this.Config = Configuration.LoadAndMigrate(Service.Interface!.ConfigFile);

            this.Functions = new GameFunctions(this);
            this.Ui = new PluginUi(this, this.Font, new UiTheme(hubSettings.Theme));
            this.Commands = new Commands(this);
        }
#pragma warning restore 8618

        public void Dispose() {
            this.Commands.Dispose();
            this.Ui.Dispose();
            this.Functions.Dispose();
            this.Font.Dispose();
        }

        public void LogTroubleshooting(string message) {
            if (!Config.TroubleshootingMode)
                return;

            Service.Log.Info($"[Troubleshooting] {message}");
        }

        internal void SaveConfig() {
            Service.Interface.SavePluginConfig(this.Config);
        }
    }
}
