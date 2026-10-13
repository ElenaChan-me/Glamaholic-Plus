namespace Glamaholic {
    // 画面に出す文言はここに集める。本家の更新を取り込むときに、翻訳漏れを探しやすくするため。
    internal static class Loc {
        // メニュー
        internal const string MenuPlates = "プレート";
        internal const string MenuNew = "新規作成";
        internal const string MenuImportClipboard = "クリップボードから取り込み";
        internal const string NoPlateInClipboard = "クリップボードに有効なプレートデータがありません。";
        internal const string ToRoot = "ルートに追加";
        internal const string MenuSettings = "設定";
        internal const string SettingShowEditorMenu = "ミラージュプレート編集画面にメニューを表示";
        internal const string SettingShowExamineMenu = "「調べる」画面にメニューを表示";
        internal const string SettingShowTryOnMenu = "試着画面にメニューを表示";
        internal const string SettingTroubleshooting = "トラブルシューティング用のログを出力";
        internal const string MenuHelp = "ヘルプ";

        // プレート一覧
        internal const string SearchHint = "検索...";
        internal const string MoveToFolder = "フォルダへ移動";
        internal const string Delete = "削除";
        internal const string Cancel = "キャンセル";
        internal const string Create = "作成";
        internal const string Rename = "名前を変更";
        internal const string ConfirmDeletePlate = "このプレートを削除しますか？元に戻せません。";
        internal const string DeleteFolderWithContents = "フォルダを削除（中身もすべて削除）";
        internal const string DeleteFolderMoveContents = "フォルダを削除（中身はフォルダの外へ移動）";
        internal const string ConfirmDeleteFolderWithContents = "このフォルダと中身をすべて削除しますか？元に戻せません。";
        internal const string ConfirmDeleteFolderMoveContents = "このフォルダを削除し、中身をフォルダの外へ移動しますか？";
        internal const string FolderName = "フォルダ名:";
        internal const string TargetFolder = "作成先のフォルダ:";
        internal const string NewPlate = "新しいプレート";
        internal const string NewFolder = "新しいフォルダ";
        internal const string RootFolder = "ルート（フォルダなし）";
        internal const string NoFolders = "フォルダはまだありません。";
        internal const string FolderLabel = "[フォルダ]";
        internal const string UnnamedPlate = "名前なしプレート";
        internal const string UnnamedFolder = "名前なしフォルダ";

        // アイテム・染色の選択
        internal const string ShowObtainedOnly = "ミラージュドレッサー・愛蔵品キャビネットにあるものだけ表示";
        internal const string NoneKeepExisting = "なし（今の装備を残す）";
        internal const string NoneRemoveExisting = "なし（外す）";
        internal const string Dye1 = "染色1";
        internal const string Dye2 = "染色2";
        internal const string NoDye = "なし";
        internal const string NoDye1 = "（染色1なし）";
        internal const string UnknownItem = "不明なアイテム";
        internal const string UnknownDye = "不明なカララント";
        internal const string NoDyeItem = "（アイテムなし）";
        internal const string ClickToCopyName = "* 左クリックで名前をコピー";

        // プレート操作
        internal const string Apply = "ミラージュプレートに適用";
        internal const string PlateEditorMustBeOpen = "ゲーム内のミラージュプレート編集画面を開いてください。";
        internal const string TryOn = "試着";
        internal const string Edit = "編集";
        internal const string Share = "共有用データをコピー";
        internal const string ExportAsText = "テキストでコピー";
        internal const string CopiedToClipboard = "クリップボードにコピーしました。";
        internal const string EditingHint = "アイテムをクリックで変更、右クリックで染色します。";
        internal const string Save = "保存";
        internal const string TagInputHint = "タグを入力して Enter";
        internal const string PressEnterToSave = "Enter で保存します。";

        // 右側の設定欄
        internal const string Customize = "カスタマイズ";
        internal const string FillEmptySlots = "空いている部位をニューエンペラーで埋める";
        internal const string FillEmptySlotsTooltip = "空いている部位にニューエンペラー装備を設定します。";
        internal const string Settings = "設定";
        internal const string FillOnApply = "試着・適用時に空き部位をニューエンペラーで埋める";
        internal const string FillOnApplyTooltip = "プレートの内容は変更しません。\n\n有効にすると、試着や適用のときだけ空いている部位にニューエンペラー装備を使います。";
        internal const string DyeListHint = "カーソルを合わせると必要なカララントを表示（クリックでコピー）";

        // 注意
        internal const string WarningArmoireNotLoaded = "愛蔵品キャビネットが読み込まれていません。一度開くと、キャビネット内の装備も使えるようになります。";
        internal const string WarningDresserEmpty = "ミラージュドレッサーが空か、まだ開かれていません。所持している装備を判別できません。";

        // ゲーム画面に重ねるメニュー
        internal const string CreatePlate = "プレートとして保存";
        internal const string CreatePlateHint = "保存先のフォルダを選んで名前を入力し、Enter で新規作成します。下の一覧から選ぶと上書きします。";
        internal const string HoldCtrlToOverwrite = "Ctrl を押しながらクリックで上書き";
        internal const string CopiedGlamour = "コピーしたミラプリ";
        internal const string FittingRoom = "試着";

        // 同じ見た目の装備
        internal const string ClickToLink = "クリック: チャットにリンク";
        internal const string RightClickToTryOn = "右クリック: 試着";

        internal static string Open(string name) => $"{name} を開く";
        internal static string AddTo(string path) => $"{path} に追加";
        internal static string Moving(string name) => $"「{name}」を移動";
        internal static string MovingFolder(string name) => $"フォルダ「{name}」を移動";
        internal static string Tags(int count) => $"タグ（{count}）";
        internal static string Warnings(int count) => $"注意（{count}）";
        internal static string CopiedName(string name) => $"「{name}」をクリップボードにコピーしました。";
        internal static string DyeCount(string dyeName, int count) => $"{dyeName} ×{count}";
        internal static string AlternativeFinderTitle(string itemName) => $"同じ見た目の装備: {itemName}";
        internal static string CommandHelp(string name) => $"{name} のウィンドウを開閉します";
    }
}
