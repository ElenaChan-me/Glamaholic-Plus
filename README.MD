# Glamaholic Plus

[Glamaholic](https://github.com/caitlyn-gg/Glamaholic) の拡張版の Dalamud プラグインです。ミラージュプレートを好きなだけ保存し、ミラージュドレッサーで呼び出せます。日本語化から始まり、多言語表示・XIVToolHub のテーマ連携・軽量化を加えています。

An extended edition of the Dalamud plugin [Glamaholic](https://github.com/caitlyn-gg/Glamaholic).
It lets you save as many glamour plates as you like and apply them at the Glamour Dresser. It started as a Japanese localization and now adds multiple languages, XIVToolHub theme support and a lighter footprint.

> 旧名は Glamaholic JP です（2026-10 に改名）。保存データを引き継ぐため、内部名 `GlamaholicJP` とコマンド `/glamjp` は変えていません。
> Formerly Glamaholic JP (renamed in October 2026). The internal name `GlamaholicJP` and the `/glamjp` command are unchanged so existing saved plates keep working.

## 注意 / Warning

本プラグインはゲームクライアントに組み込んで動作する外部ツールです。
FINAL FANTASY XIV の利用規約では外部ツールの使用が禁止されており、使用が確認された場合はアカウントの利用停止などの対象になります。
利用は自己責任で行ってください。

This plugin runs inside the game client. Third-party tools are prohibited by the FINAL FANTASY XIV Terms of Service,
and their use may result in account suspension. Use at your own risk.

## 本家からの変更点 / Changes from the original

変更日 / Date of modification: 2026-10-13（ベース / based on: Glamaholic 1.15.2, commit `7ba1ae3`）

### 多言語化 / Localization

- 画面の文言をすべて日本語化（`Glamaholic/Loc.cs` に集約）
  All UI text translated into Japanese and collected in `Glamaholic/Loc.cs`
- アイテム名・カララント名をクライアントの言語で表示・検索（本家は英語データ固定）
  Item and dye names are shown and searched in the client language (the original always used English data)
- 検索でひらがな/カタカナ、全角/半角、大文字/小文字を区別しない
  Search ignores kana type, width and case
- `j:` 検索で英語略称に加えて日本語のジョブ名を使用可能（例: `j:ナイト`）
  `j:` filter also accepts localized job names
- ヘルプ・部位名・テキスト出力を日本語化
  Help, slot names and text export are localized
- 表示言語を日本語・英語・韓国語・中国語（簡体字）から選択可能。XIVToolHub でインストール時に選び、日本語の場合は追加フォントも選べる（ハブを使わない場合は Dalamud の言語設定に従う）
  Display language can be Japanese, English, Korean or Simplified Chinese, chosen in XIVToolHub (with an optional font for Japanese); without the hub, Dalamud's language is used
- 配色を XIVToolHub のテーマ（黒・赤 / 白・水色）に合わせて表示。ハブを使わない場合は Dalamud の配色のまま
  Colors follow the XIVToolHub theme (Black/Red or White/Light Blue); without the hub, Dalamud's style is kept

### 軽量化 / Slimming down

- Eorzea Collection からの取り込み（外部サイトとの通信）を削除
  Removed Eorzea Collection import (network access)
- Glamourer 連携と `Glamourer.Api` サブモジュールを削除
  Removed Glamourer integration and the `Glamourer.Api` submodule
- 作成のみで使われていなかったゲーム関数フック、Ko-fi ボタン、英語の更新履歴、IDA スクリプト、旧 CI 設定を削除
  Removed an unused game hook, the Ko-fi button, the English changelog popup, the IDA script and the old CI config
- 描画のたびに行っていた愛蔵品キャビネットのシート検索・ドレッサーの走査・カララント一覧の作成をキャッシュ化
  Cached armoire/dresser lookups and the dye list that were recomputed every frame

### その他 / Other

- 本家と同時に導入できるよう、内部名を `GlamaholicJP`、コマンドを `/glamjp` に変更
  Internal name changed to `GlamaholicJP` and the command to `/glamjp` so it can coexist with the original
- 初回起動時、本家 Glamaholic の保存データ（`pluginConfigs/Glamaholic.json`）があればコピーして引き継ぐ（本家のファイルは変更しない）
  On first launch, plates saved by the original plugin are copied over (the original file is left untouched)
- ドレッサー内の装備だけを表示する設定で、HQ 品が表示されない問題を修正
  Fixed HQ items missing from the "obtained only" item list

## インストール / Install

[XIVToolHub](https://github.com/ElenaChan-me/XIVToolHub) で Glamaholic Plus を選ぶと、Dalamud の開発用プラグインとして登録されます。
Select Glamaholic Plus in XIVToolHub; it is registered as a Dalamud dev plugin.

## 使い方 / Usage

`/glamjp` でメインウィンドウを開きます。使い方はウィンドウの「ヘルプ」メニューを参照してください。

Open the main window with `/glamjp`. See the Help menu in the window for details.

## ビルド / Build

.NET SDK 10 と Dalamud の参照ライブラリが必要です。
Requires the .NET 10 SDK and the Dalamud reference assemblies.

```powershell
# XIVLauncher で Dalamud を使っている環境では参照先の指定は不要
dotnet build Glamaholic.sln -c Release

# Dalamud の配布物を別の場所に展開した場合
dotnet build Glamaholic.sln -c Release -p:DalamudLibPath="C:\path\to\dalamud\"
```

出力は `Glamaholic/bin/x64/Release/GlamaholicJP/` です。Dalamud の設定「実験的機能」で開発用プラグインの場所に `GlamaholicJP.dll` を追加すると読み込めます。

The output is written to `Glamaholic/bin/x64/Release/GlamaholicJP/`. Add `GlamaholicJP.dll` as a dev plugin location in Dalamud's experimental settings.

## ブランチ / Branches

- `main`: 安定版 / stable
- `develop`: 開発統合ブランチ / integration
- `feature/*`: 作業用 / work in progress
- `upstream`（リモート）: 本家 / the original repository

## クレジット / Credits

本プラグインは Anna 氏が開発し（[原リポジトリ](https://git.anna.lgbt/anna/Glamaholic)、[Ko-fi](https://ko-fi.com/lojewalo)）、
Caitlyn 氏らが [caitlyn-gg/Glamaholic](https://github.com/caitlyn-gg/Glamaholic) で保守している Glamaholic を元にしています。

This plugin is based on Glamaholic, originally developed by Anna ([original repository](https://git.anna.lgbt/anna/Glamaholic), [Ko-fi](https://ko-fi.com/lojewalo))
and maintained by Caitlyn and contributors at [caitlyn-gg/Glamaholic](https://github.com/caitlyn-gg/Glamaholic).

## ライセンス / License

本家と同じく [EUPL-1.2](LICENCE) です。
Licensed under the [EUPL-1.2](LICENCE), the same as the original.

FINAL FANTASY は株式会社スクウェア・エニックス・ホールディングスの登録商標です。本プラグインはスクウェア・エニックスとは関係ありません。
FINAL FANTASY is a registered trademark of Square Enix Holdings Co., Ltd. This plugin is not affiliated with Square Enix.
