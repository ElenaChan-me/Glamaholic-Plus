namespace Glamaholic {
    internal enum UiLanguage {
        English,
        Japanese,
        Korean,
        ChineseSimplified,
    }

    // 画面に出す文言はここに集める。本家の更新を取り込むときに、翻訳漏れを探しやすくするため。
    // 英語は本家の原文。中国語は FF14 中国版に合わせて簡体字。
    internal static class Loc {
        internal static UiLanguage Language { get; set; } = UiLanguage.Japanese;

        private static string T(string en, string ja, string ko, string zh) => Language switch {
            UiLanguage.Japanese => ja,
            UiLanguage.Korean => ko,
            UiLanguage.ChineseSimplified => zh,
            _ => en,
        };

        // メニュー
        internal static string MenuPlates => T("Plates", "プレート", "플레이트", "模板");
        internal static string MenuNew => T("New", "新規作成", "새로 만들기", "新建");
        internal static string MenuImportClipboard => T("Import from Clipboard", "クリップボードから取り込み", "클립보드에서 가져오기", "从剪贴板导入");
        internal static string NoPlateInClipboard => T("No valid plate data in clipboard.", "クリップボードに有効なプレートデータがありません。", "클립보드에 올바른 플레이트 데이터가 없습니다.", "剪贴板中没有有效的模板数据。");
        internal static string ToRoot => T("To Root", "ルートに追加", "최상위에 추가", "添加到根目录");
        internal static string MenuSettings => T("Settings", "設定", "설정", "设置");
        internal static string SettingShowEditorMenu => T("Show plate editor menu", "ミラージュプレート編集画面にメニューを表示", "투영 플레이트 편집 화면에 메뉴 표시", "在投影模板编辑界面显示菜单");
        internal static string SettingShowExamineMenu => T("Show examine window menu", "「調べる」画面にメニューを表示", "살펴보기 화면에 메뉴 표시", "在查看界面显示菜单");
        internal static string SettingShowTryOnMenu => T("Show try on menu", "試着画面にメニューを表示", "시착 화면에 메뉴 표시", "在试穿界面显示菜单");
        internal static string SettingTroubleshooting => T("Troubleshooting mode", "トラブルシューティング用のログを出力", "문제 해결용 로그 출력", "输出故障排查日志");
        internal static string MenuHelp => T("Help", "ヘルプ", "도움말", "帮助");

        // プレート一覧
        internal static string SearchHint => T("Search...", "検索...", "검색...", "搜索...");
        internal static string MoveToFolder => T("Move to Folder", "フォルダへ移動", "폴더로 이동", "移动到文件夹");
        internal static string Delete => T("Delete", "削除", "삭제", "删除");
        internal static string Cancel => T("Cancel", "キャンセル", "취소", "取消");
        internal static string Create => T("Create", "作成", "만들기", "创建");
        internal static string Rename => T("Rename", "名前を変更", "이름 변경", "重命名");
        internal static string ConfirmDeletePlate => T("Delete this plate? This cannot be undone.", "このプレートを削除しますか？元に戻せません。", "이 플레이트를 삭제할까요? 되돌릴 수 없습니다.", "要删除此模板吗？此操作无法撤销。");
        internal static string DeleteFolderWithContents => T("Delete Folder (and all contents)", "フォルダを削除（中身もすべて削除）", "폴더 삭제 (내용도 모두 삭제)", "删除文件夹（同时删除所有内容）");
        internal static string DeleteFolderMoveContents => T("Delete Folder (move contents out)", "フォルダを削除（中身はフォルダの外へ移動）", "폴더 삭제 (내용은 폴더 밖으로 이동)", "删除文件夹（将内容移出）");
        internal static string ConfirmDeleteFolderWithContents => T("Delete this folder and ALL its contents? This cannot be undone.", "このフォルダと中身をすべて削除しますか？元に戻せません。", "이 폴더와 모든 내용을 삭제할까요? 되돌릴 수 없습니다.", "要删除此文件夹及其所有内容吗？此操作无法撤销。");
        internal static string ConfirmDeleteFolderMoveContents => T("Delete this folder and move all contents out?", "このフォルダを削除し、中身をフォルダの外へ移動しますか？", "이 폴더를 삭제하고 내용을 폴더 밖으로 옮길까요?", "要删除此文件夹并将内容移出吗？");
        internal static string FolderName => T("Folder Name:", "フォルダ名:", "폴더 이름:", "文件夹名称：");
        internal static string TargetFolder => T("Folder:", "作成先のフォルダ:", "만들 위치:", "目标文件夹：");
        internal static string NewPlate => T("Untitled Plate", "新しいプレート", "새 플레이트", "新模板");
        internal static string NewPlateTooltip => T("New Plate", "新しいプレート", "새 플레이트", "新建模板");
        internal static string NewFolder => T("New Folder", "新しいフォルダ", "새 폴더", "新建文件夹");
        internal static string RootFolder => T("Root (No Folder)", "ルート（フォルダなし）", "최상위 (폴더 없음)", "根目录（无文件夹）");
        internal static string NoFolders => T("No folders created yet.", "フォルダはまだありません。", "아직 폴더가 없습니다.", "尚未创建文件夹。");
        internal static string FolderLabel => T("[Folder]", "[フォルダ]", "[폴더]", "[文件夹]");
        internal static string UnnamedPlate => T("Unnamed Plate", "名前なしプレート", "이름 없는 플레이트", "未命名模板");
        internal static string UnnamedFolder => T("Unnamed Folder", "名前なしフォルダ", "이름 없는 폴더", "未命名文件夹");

        // アイテム・染色の選択
        internal static string ShowObtainedOnly => T("Only show items in the armoire/dresser", "ミラージュドレッサー・愛蔵品キャビネットにあるものだけ表示", "투영대·애장품 보관함에 있는 것만 표시", "仅显示投影台/收藏柜中的物品");
        internal static string NoneKeepExisting => T("None (keep existing)", "なし（今の装備を残す）", "없음 (현재 장비 유지)", "无（保留现有）");
        internal static string NoneRemoveExisting => T("None (remove existing)", "なし（外す）", "없음 (해제)", "无（移除现有）");
        internal static string Dye1 => T("Primary Dye", "染色1", "염색 1", "染色1");
        internal static string Dye2 => T("Secondary Dye", "染色2", "염색 2", "染色2");
        internal static string NoDye => T("None", "なし", "없음", "无");
        internal static string NoDye1 => T("(no primary dye)", "（染色1なし）", "(염색 1 없음)", "（无染色1）");
        internal static string UnknownItem => T("Unknown Item", "不明なアイテム", "알 수 없는 아이템", "未知物品");
        internal static string UnknownDye => T("Unknown Stain", "不明なカララント", "알 수 없는 염료", "未知染剂");
        internal static string NoDyeItem => T("(no items)", "（アイテムなし）", "(아이템 없음)", "（无物品）");
        internal static string ClickToCopyName => T("* Left click to copy name to clipboard", "* 左クリックで名前をコピー", "* 왼쪽 클릭으로 이름 복사", "* 左键单击复制名称");

        // プレート操作
        internal static string Apply => T("Apply", "ミラージュプレートに適用", "투영 플레이트에 적용", "应用到投影模板");
        internal static string PlateEditorMustBeOpen => T("The in-game plate editor must be open.", "ゲーム内のミラージュプレート編集画面を開いてください。", "게임 내 투영 플레이트 편집 화면을 열어 주세요.", "请打开游戏内的投影模板编辑界面。");
        internal static string TryOn => T("Try on", "試着", "시착", "试穿");
        internal static string Edit => T("Edit", "編集", "편집", "编辑");
        internal static string Share => T("Share", "共有用データをコピー", "공유용 데이터 복사", "复制共享数据");
        internal static string ExportAsText => T("Export as Text", "テキストでコピー", "텍스트로 복사", "以文本复制");
        internal static string CopiedToClipboard => T("Copied to clipboard.", "クリップボードにコピーしました。", "클립보드에 복사했습니다.", "已复制到剪贴板。");
        internal static string EditingHint => T("Click an item to edit it. Right-click to dye.", "アイテムをクリックで変更、右クリックで染色します。", "아이템을 클릭하면 변경, 오른쪽 클릭하면 염색합니다.", "单击物品进行更改，右键单击进行染色。");
        internal static string Save => T("Save", "保存", "저장", "保存");
        internal static string TagInputHint => T("Input a tag and press Enter", "タグを入力して Enter", "태그를 입력하고 Enter", "输入标签后按 Enter");
        internal static string PressEnterToSave => T("Press Enter to save.", "Enter で保存します。", "Enter로 저장합니다.", "按 Enter 保存。");

        // 右側の設定欄
        internal static string Customize => T("Customize", "カスタマイズ", "사용자 설정", "自定义");
        internal static string FillEmptySlots => T("Fill Empty Slots with New Emperor", "空いている部位をニューエンペラーで埋める", "빈 부위를 황제의 새 옷 장비로 채우기", "用皇帝的新装填充空部位");
        internal static string FillEmptySlotsTooltip => T("Fills empty slots with the New Emperor set.", "空いている部位にニューエンペラー装備を設定します。", "빈 부위에 황제의 새 옷 장비를 설정합니다.", "在空部位设置皇帝的新装套装。");
        internal static string Settings => T("Settings", "設定", "설정", "设置");
        internal static string FillOnApply => T("Fill empty slots with New Emperor for Try on & Apply", "試着・適用時に空き部位をニューエンペラーで埋める", "시착·적용 시 빈 부위를 황제의 새 옷 장비로 채우기", "试穿和应用时用皇帝的新装填充空部位");
        internal static string FillOnApplyTooltip => T(
            "Does not modify the glamour itself!\n\nIf enabled, empty slots will be filled with the New Emperor set when tried on or applied to plates.",
            "プレートの内容は変更しません。\n\n有効にすると、試着や適用のときだけ空いている部位にニューエンペラー装備を使います。",
            "플레이트 내용은 변경하지 않습니다.\n\n켜면 시착이나 적용할 때만 빈 부위에 황제의 새 옷 장비를 사용합니다.",
            "不会修改模板本身。\n\n启用后，仅在试穿或应用时用皇帝的新装填充空部位。");
        internal static string DyeListHint => T("Hover to view dyes (click to copy)", "カーソルを合わせると必要なカララントを表示（クリックでコピー）", "마우스를 올리면 필요한 염료 표시 (클릭하면 복사)", "悬停显示所需染剂（单击复制）");

        // 注意
        internal static string WarningArmoireNotLoaded => T(
            "The Armoire is not loaded. Open it once to enable glamours from the Armoire.",
            "愛蔵品キャビネットが読み込まれていません。一度開くと、キャビネット内の装備も使えるようになります。",
            "애장품 보관함이 불러와지지 않았습니다. 한 번 열면 보관함의 장비도 사용할 수 있습니다.",
            "收藏柜尚未加载。打开一次后即可使用收藏柜中的装备。");
        internal static string WarningDresserEmpty => T(
            "Glamour Dresser is empty or has not been opened. Glamaholic will not know which items you have.",
            "ミラージュドレッサーが空か、まだ開かれていません。所持している装備を判別できません。",
            "투영대가 비어 있거나 아직 열지 않았습니다. 보유한 장비를 확인할 수 없습니다.",
            "投影台为空或尚未打开，无法判断你拥有的装备。");

        // ゲーム画面に重ねるメニュー
        internal static string CreatePlate => T("Create glamour plate", "プレートとして保存", "플레이트로 저장", "保存为模板");
        internal static string CreatePlateHint => T(
            "Select a folder, enter a name and then press then <Enter> to create a new plate, or choose a plate below to overwrite.",
            "保存先のフォルダを選んで名前を入力し、Enter で新規作成します。下の一覧から選ぶと上書きします。",
            "저장할 폴더를 고르고 이름을 입력한 뒤 Enter로 새로 만듭니다. 아래 목록에서 고르면 덮어씁니다.",
            "选择文件夹并输入名称，按 Enter 新建；从下方列表中选择则会覆盖。");
        internal static string HoldCtrlToOverwrite => T("Hold Control and click to overwrite.", "Ctrl を押しながらクリックで上書き", "Ctrl을 누른 채 클릭하면 덮어쓰기", "按住 Ctrl 单击以覆盖");
        internal static string CopiedGlamour => T("Copied glamour", "コピーしたミラプリ", "복사한 투영", "复制的幻化");
        internal static string FittingRoom => T("Fitting Room", "試着", "시착", "试穿");

        // 同じ見た目の装備
        internal static string ClickToLink => T("Click: link to chat", "クリック: チャットにリンク", "클릭: 채팅에 링크", "单击：链接到聊天");
        internal static string RightClickToTryOn => T("Right-click: try on", "右クリック: 試着", "오른쪽 클릭: 시착", "右键单击：试穿");

        // 部位名
        internal static string SlotMainHand => T("Main Hand", "武器", "무기", "主手");
        internal static string SlotOffHand => T("Off Hand", "盾", "보조 무기", "副手");
        internal static string SlotHead => T("Head", "頭", "머리", "头部");
        internal static string SlotBody => T("Body", "胴", "몸통", "身体");
        internal static string SlotHands => T("Hands", "手", "손", "手部");
        internal static string SlotLegs => T("Legs", "脚", "다리", "腿部");
        internal static string SlotFeet => T("Feet", "足", "발", "脚部");
        internal static string SlotEars => T("Ears", "耳", "귀걸이", "耳部");
        internal static string SlotNeck => T("Neck", "首", "목걸이", "颈部");
        internal static string SlotWrists => T("Wrists", "腕", "팔찌", "腕部");
        internal static string SlotRightRing => T("Right Ring", "右指", "오른쪽 반지", "右指");
        internal static string SlotLeftRing => T("Left Ring", "左指", "왼쪽 반지", "左指");

        internal static string Open(string name) => T($"Open {name}", $"{name} を開く", $"{name} 열기", $"打开 {name}");
        internal static string AddTo(string path) => T($"To {path}", $"{path} に追加", $"{path}에 추가", $"添加到 {path}");
        internal static string Moving(string name) => T($"Moving '{name}'", $"「{name}」を移動", $"'{name}' 이동", $"移动“{name}”");
        internal static string MovingFolder(string name) => T($"Moving folder '{name}'", $"フォルダ「{name}」を移動", $"폴더 '{name}' 이동", $"移动文件夹“{name}”");
        internal static string Tags(int count) => T($"Tags ({count})", $"タグ（{count}）", $"태그 ({count})", $"标签（{count}）");
        internal static string Warnings(int count) => T($"Warnings ({count})", $"注意（{count}）", $"주의 ({count})", $"警告（{count}）");
        internal static string CopiedName(string name) => T($"Copied '{name}' to clipboard.", $"「{name}」をクリップボードにコピーしました。", $"'{name}'을(를) 클립보드에 복사했습니다.", $"已将“{name}”复制到剪贴板。");
        internal static string DyeCount(string dyeName, int count) => T($"{count}x {dyeName}", $"{dyeName} ×{count}", $"{dyeName} ×{count}", $"{dyeName} ×{count}");
        internal static string AlternativeFinderTitle(string itemName) => T($"Alternative Finder: {itemName}", $"同じ見た目の装備: {itemName}", $"같은 외형의 장비: {itemName}", $"相同外观的装备：{itemName}");
        internal static string CommandHelp(string name) => T($"Toggle visibility of the {name} window", $"{name} のウィンドウを開閉します", $"{name} 창을 열고 닫습니다", $"打开或关闭 {name} 窗口");

        /// <summary>ヘルプの埋め込みリソース名。</summary>
        internal static string HelpResource => T("help.en.txt", "help.ja.txt", "help.ko.txt", "help.zh.txt");
    }
}
