using Dalamud.Game;
using Dalamud.Utility;
using Lumina.Excel;
using Lumina.Excel.Sheets;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Glamaholic {
    // Lazy loading and caching of important data which requires filtering or transforming
    internal class DataCache {
        // 除外判定は英語名（"Dated" など）に依存するため、英語シートで一度だけ求めておく
        private static readonly Lazy<HashSet<uint>> SkippedItemIds = new(() =>
            Service.DataManager.GetExcelSheet<Item>(ClientLanguage.English)!
                .Where(Util.IsSkippedByEnglishName)
                .Select(row => row.RowId)
                .ToHashSet());

        // 表示と検索に使うため、クライアントの言語（日本語クライアントなら日本語）で保持する
        public static Lazy<ImmutableList<Item>> EquippableItems { get; } =
            new(() => Service.DataManager.GetExcelSheet<Item>()!
                .Where(row => row.EquipSlotCategory.RowId != 0 &&
                       row.EquipSlotCategory.Value!.SoulCrystal == 0)
                .ToImmutableList());

        public static Lazy<ImmutableDictionary<byte, CachedStain>> Stains { get; } =
            new(() =>
                Service.DataManager.GetExcelSheet<Stain>()!
                    .Where(static row => row.RowId != 0 && !row.Name.IsEmpty)
                    .ToImmutableDictionary(static row => (byte) row.RowId, static row => {
                        uint[] itemIds = new uint[row.Item.Count];
                        int i = 0;
                        foreach (RowRef<Item> itemRef in row.Item)
                            itemIds[i++] = itemRef.RowId;

                        string itemName = row.Item.Count != 0 ? row.Item[0].Value.Name.ExtractText() : Loc.NoDyeItem;
                        return new CachedStain(row.Name.ExtractText(), itemIds, itemName);
                    }));

        // 染色の選択画面で毎フレームシートを走査しないよう、選べるカララントだけを並び順どおりに保持する
        public static Lazy<ImmutableList<DyeOption>> DyeOptions { get; } =
            new(() =>
                Service.DataManager.GetExcelSheet<Stain>()!
                    .Where(static row => row.RowId != 0 && row.Shade != 0)
                    .Select(static row => new DyeOption((byte) row.RowId, row.Name.ExtractText()))
                    .ToImmutableList());

        public static bool IsSkippedItem(uint itemId) => SkippedItemIds.Value.Contains(itemId);

        public static int GetNumStainSlots(uint itemId) {
            var (id, kind) = ItemUtil.GetBaseId(itemId);
            return Service.DataManager.GetExcelSheet<Item>(ClientLanguage.English)!.GetRowOrDefault(id)?.DyeCount ?? 0;
        }

        public static HashSet<byte> ValuableStains { get; } = [101, 102, 103]; // Pure White, Jet Black, Pastel Pink
    }

    internal class CachedStain {
        public string StainName { get; }
        public uint[] ItemIds { get; }
        public string ItemName { get; }

        public CachedStain(string stainName, uint[] itemIds, string itemName) {
            StainName = stainName;
            ItemIds = itemIds;
            ItemName = itemName;
        }
    }

    internal record DyeOption(byte Id, string Name);
}
