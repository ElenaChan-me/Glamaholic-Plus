using System;

namespace Glamaholic {
    internal enum PlateSlot : uint {
        MainHand = 0,
        OffHand = 1,
        Head = 2,
        Body = 3,
        Hands = 4,
        Legs = 5,
        Feet = 6,
        Ears = 7,
        Neck = 8,
        Wrists = 9,
        RightRing = 10,
        LeftRing = 11,
    }

    internal static class PlateSlotExt {
        internal static string Name(this PlateSlot slot) {
            return slot switch {
                PlateSlot.MainHand => "武器",
                PlateSlot.OffHand => "盾",
                PlateSlot.Head => "頭",
                PlateSlot.Body => "胴",
                PlateSlot.Hands => "手",
                PlateSlot.Legs => "脚",
                PlateSlot.Feet => "足",
                PlateSlot.Ears => "耳",
                PlateSlot.Neck => "首",
                PlateSlot.Wrists => "腕",
                PlateSlot.RightRing => "右指",
                PlateSlot.LeftRing => "左指",
                _ => throw new ArgumentOutOfRangeException(nameof(slot), slot, null),
            };
        }
    }
}
