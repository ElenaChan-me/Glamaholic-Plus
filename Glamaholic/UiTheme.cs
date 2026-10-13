using Dalamud.Bindings.ImGui;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Glamaholic {
    /// <summary>
    /// XIVToolHub・Triggevent JP と共通の配色（黒・赤 / 白・水色）。色の値はハブの Themes/Dark.xaml・Light.xaml と揃えている。
    /// ハブを使わずに導入した場合はテーマの指定が無いので、Dalamud の配色のまま表示する。
    /// </summary>
    internal sealed class UiTheme {
        private const float FrameRounding = 4f;
        // ハブの画面と同じく、ボタンや入力欄に枠線を付けて背景との境目を分かりやすくする
        private const float FrameBorderSize = 1f;
        private const int StyleVarCount = 2;

        private static readonly Dictionary<ImGuiCol, uint> Dark = new() {
            [ImGuiCol.Text] = 0xEDEDED,
            [ImGuiCol.TextDisabled] = 0x8A8A8A,
            [ImGuiCol.WindowBg] = 0x121212,
            [ImGuiCol.ChildBg] = 0x121212,
            [ImGuiCol.PopupBg] = 0x1B1B1B,
            [ImGuiCol.Border] = 0x363636,
            [ImGuiCol.FrameBg] = 0x1B1B1B,
            [ImGuiCol.FrameBgHovered] = 0x262626,
            [ImGuiCol.FrameBgActive] = 0x3A1C1F,
            [ImGuiCol.TitleBg] = 0x121212,
            [ImGuiCol.TitleBgActive] = 0x1B1B1B,
            [ImGuiCol.TitleBgCollapsed] = 0x121212,
            [ImGuiCol.MenuBarBg] = 0x1B1B1B,
            [ImGuiCol.ScrollbarBg] = 0x121212,
            [ImGuiCol.ScrollbarGrab] = 0x363636,
            [ImGuiCol.ScrollbarGrabHovered] = 0x4A4A4A,
            [ImGuiCol.ScrollbarGrabActive] = 0xE23B44,
            [ImGuiCol.CheckMark] = 0xE23B44,
            [ImGuiCol.SliderGrab] = 0xE23B44,
            [ImGuiCol.SliderGrabActive] = 0xF0555D,
            [ImGuiCol.Button] = 0x262626,
            [ImGuiCol.ButtonHovered] = 0x5A1E23,
            [ImGuiCol.ButtonActive] = 0xE23B44,
            [ImGuiCol.Header] = 0x3A1C1F,
            [ImGuiCol.HeaderHovered] = 0x5A1E23,
            [ImGuiCol.HeaderActive] = 0xE23B44,
            [ImGuiCol.Separator] = 0x363636,
            [ImGuiCol.SeparatorHovered] = 0x5A1E23,
            [ImGuiCol.SeparatorActive] = 0xE23B44,
            [ImGuiCol.ResizeGrip] = 0x363636,
            [ImGuiCol.ResizeGripHovered] = 0x5A1E23,
            [ImGuiCol.ResizeGripActive] = 0xE23B44,
            [ImGuiCol.Tab] = 0x1B1B1B,
            [ImGuiCol.TabHovered] = 0x5A1E23,
            [ImGuiCol.TabActive] = 0xE23B44,
            [ImGuiCol.TabUnfocused] = 0x1B1B1B,
            [ImGuiCol.TabUnfocusedActive] = 0x3A1C1F,
            [ImGuiCol.TableHeaderBg] = 0x1B1B1B,
            [ImGuiCol.TextSelectedBg] = 0x5A1E23,
            [ImGuiCol.NavHighlight] = 0xE23B44,
        };

        private static readonly Dictionary<ImGuiCol, uint> Light = new() {
            [ImGuiCol.Text] = 0x1D2B36,
            [ImGuiCol.TextDisabled] = 0x8C9BA6,
            [ImGuiCol.WindowBg] = 0xF5FAFD,
            [ImGuiCol.ChildBg] = 0xF5FAFD,
            [ImGuiCol.PopupBg] = 0xFFFFFF,
            [ImGuiCol.Border] = 0xCBE2EF,
            [ImGuiCol.FrameBg] = 0xFFFFFF,
            [ImGuiCol.FrameBgHovered] = 0xE6F4FB,
            [ImGuiCol.FrameBgActive] = 0xD4EEFA,
            [ImGuiCol.TitleBg] = 0xE6F4FB,
            [ImGuiCol.TitleBgActive] = 0xD4EEFA,
            [ImGuiCol.TitleBgCollapsed] = 0xE6F4FB,
            [ImGuiCol.MenuBarBg] = 0xE6F4FB,
            [ImGuiCol.ScrollbarBg] = 0xF5FAFD,
            [ImGuiCol.ScrollbarGrab] = 0xCBE2EF,
            [ImGuiCol.ScrollbarGrabHovered] = 0xA9D3EA,
            [ImGuiCol.ScrollbarGrabActive] = 0x2EA7E0,
            [ImGuiCol.CheckMark] = 0x2EA7E0,
            [ImGuiCol.SliderGrab] = 0x2EA7E0,
            [ImGuiCol.SliderGrabActive] = 0x4DB8EA,
            [ImGuiCol.Button] = 0xE6F4FB,
            [ImGuiCol.ButtonHovered] = 0xBFE6F8,
            [ImGuiCol.ButtonActive] = 0x2EA7E0,
            [ImGuiCol.Header] = 0xD4EEFA,
            [ImGuiCol.HeaderHovered] = 0xBFE6F8,
            [ImGuiCol.HeaderActive] = 0x2EA7E0,
            [ImGuiCol.Separator] = 0xCBE2EF,
            [ImGuiCol.SeparatorHovered] = 0xBFE6F8,
            [ImGuiCol.SeparatorActive] = 0x2EA7E0,
            [ImGuiCol.ResizeGrip] = 0xCBE2EF,
            [ImGuiCol.ResizeGripHovered] = 0xBFE6F8,
            [ImGuiCol.ResizeGripActive] = 0x2EA7E0,
            [ImGuiCol.Tab] = 0xE6F4FB,
            [ImGuiCol.TabHovered] = 0xBFE6F8,
            [ImGuiCol.TabActive] = 0x2EA7E0,
            [ImGuiCol.TabUnfocused] = 0xE6F4FB,
            [ImGuiCol.TabUnfocusedActive] = 0xD4EEFA,
            [ImGuiCol.TableHeaderBg] = 0xE6F4FB,
            [ImGuiCol.TextSelectedBg] = 0xBFE6F8,
            [ImGuiCol.NavHighlight] = 0x2EA7E0,
        };

        private readonly (ImGuiCol Index, Vector4 Color)[]? _colors;

        internal UiTheme(string? code) {
            var palette = code?.Trim().ToLowerInvariant() switch {
                "dark" => Dark,
                "light" => Light,
                _ => null,
            };
            if (palette != null) {
                _colors = [.. EnumerateColors(palette)];
            }
        }

        /// <summary>描画の間だけ配色を切り替える。Dalamud や他のプラグインの見た目には影響しない。</summary>
        internal IDisposable? Push() {
            if (_colors == null) {
                return null;
            }

            foreach (var (index, color) in _colors) {
                ImGui.PushStyleColor(index, color);
            }
            ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, FrameRounding);
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, FrameBorderSize);
            return new Popper(_colors.Length);
        }

        private static IEnumerable<(ImGuiCol, Vector4)> EnumerateColors(Dictionary<ImGuiCol, uint> palette) {
            foreach (var (index, rgb) in palette) {
                yield return (index, new Vector4(((rgb >> 16) & 0xFF) / 255f, ((rgb >> 8) & 0xFF) / 255f, (rgb & 0xFF) / 255f, 1f));
            }
        }

        private sealed class Popper(int colorCount) : IDisposable {
            private bool _disposed;

            public void Dispose() {
                if (_disposed) {
                    return;
                }

                _disposed = true;
                ImGui.PopStyleVar(StyleVarCount);
                ImGui.PopStyleColor(colorCount);
            }
        }
    }
}
