using Dalamud.Interface;
using Dalamud.Interface.ManagedFontAtlas;
using System;
using System.Globalization;

namespace Glamaholic {
    /// <summary>
    /// 表示言語と選択フォントに合わせた ImGui フォントを用意する。
    /// 追加フォントにはかなしか収録していないものもあるため、足りない文字は Windows の各言語の標準フォントで補う。
    /// </summary>
    internal sealed class LanguageFont : IDisposable {
        private const int NormalWeight = 400;
        private const int NormalStretch = 5;
        private const int NormalStyle = 0;

        // 英数字・記号、かな、CJK 統合漢字、ハングル、全角記号
        private static readonly ushort[] GlyphRanges = [
            0x0020, 0x00FF,
            0x2000, 0x206F,
            0x3000, 0x30FF,
            0x31F0, 0x31FF,
            0x3130, 0x318F,
            0x4E00, 0x9FFF,
            0xAC00, 0xD7A3,
            0xFF00, 0xFFEF,
            0,
        ];

        private readonly IFontHandle? _handle;

        internal LanguageFont(IUiBuilder uiBuilder, UiLanguage language, string? fontPath) {
            var culture = language switch {
                UiLanguage.Korean => CultureInfo.GetCultureInfo("ko-KR"),
                UiLanguage.ChineseSimplified => CultureInfo.GetCultureInfo("zh-CN"),
                _ => fontPath != null ? CultureInfo.GetCultureInfo("ja-JP") : null,
            };

            // 既定のフォントで表示できる場合は、余計なフォントを読み込まない
            if (culture == null) {
                return;
            }

            _handle = uiBuilder.FontAtlas.NewDelegateFontHandle(e => e.OnPreBuild(tk => {
                var config = new SafeFontConfig { SizePx = UiBuilder.DefaultFontSizePx, GlyphRanges = GlyphRanges };
                config.MergeFont = fontPath != null
                    ? tk.AddFontFromFile(fontPath, config)
                    : tk.AddDalamudDefaultFont(-1, null);
                tk.AttachWindowsDefaultFont(culture, config, NormalWeight, NormalStretch, NormalStyle);
                tk.Font = config.MergeFont;
            }));
        }

        internal IDisposable? Push() {
            return _handle?.Push();
        }

        public void Dispose() {
            _handle?.Dispose();
        }
    }
}
