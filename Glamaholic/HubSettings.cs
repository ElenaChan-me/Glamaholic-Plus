using Newtonsoft.Json;
using System;
using System.IO;

namespace Glamaholic {
    /// <summary>
    /// XIVToolHub がプラグインの隣に書き出す設定（表示言語・フォント）。
    /// ハブを使わずに導入した場合はファイルが無いので、Dalamud の表示言語に合わせる。
    /// </summary>
    internal sealed class HubSettings {
        internal const string FileName = "xivtoolhub-settings.json";
        private const long MaxFileBytes = 64 * 1024;

        [JsonProperty("language")]
        public string? Language { get; set; }

        [JsonProperty("fontPath")]
        public string? FontPath { get; set; }

        internal static HubSettings Load(string? directory) {
            if (directory == null) {
                return new HubSettings();
            }

            var file = new FileInfo(Path.Combine(directory, FileName));
            try {
                if (!file.Exists || file.Length > MaxFileBytes) {
                    return new HubSettings();
                }

                return JsonConvert.DeserializeObject<HubSettings>(File.ReadAllText(file.FullName)) ?? new HubSettings();
            } catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException) {
                Service.Log.Warning(ex, "Failed to read XIVToolHub settings");
                return new HubSettings();
            }
        }

        internal UiLanguage ResolveLanguage(string dalamudLanguage) {
            return ParseLanguage(this.Language) ?? ParseLanguage(dalamudLanguage) ?? UiLanguage.English;
        }

        /// <summary>フォントは日本語表示のときだけ使う。ファイルが無い場合は既定のフォントに戻す。</summary>
        internal string? ResolveFontPath(UiLanguage language) {
            if (language != UiLanguage.Japanese || string.IsNullOrWhiteSpace(this.FontPath)) {
                return null;
            }

            return File.Exists(this.FontPath) ? this.FontPath : null;
        }

        private static UiLanguage? ParseLanguage(string? code) {
            return code?.Trim().ToLowerInvariant() switch {
                "ja" => UiLanguage.Japanese,
                "ko" => UiLanguage.Korean,
                "zh" or "zh-cn" or "zh-hans" => UiLanguage.ChineseSimplified,
                "en" => UiLanguage.English,
                _ => null,
            };
        }
    }
}
