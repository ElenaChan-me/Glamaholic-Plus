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
                PlateSlot.MainHand => Loc.SlotMainHand,
                PlateSlot.OffHand => Loc.SlotOffHand,
                PlateSlot.Head => Loc.SlotHead,
                PlateSlot.Body => Loc.SlotBody,
                PlateSlot.Hands => Loc.SlotHands,
                PlateSlot.Legs => Loc.SlotLegs,
                PlateSlot.Feet => Loc.SlotFeet,
                PlateSlot.Ears => Loc.SlotEars,
                PlateSlot.Neck => Loc.SlotNeck,
                PlateSlot.Wrists => Loc.SlotWrists,
                PlateSlot.RightRing => Loc.SlotRightRing,
                PlateSlot.LeftRing => Loc.SlotLeftRing,
                _ => throw new ArgumentOutOfRangeException(nameof(slot), slot, null),
            };
        }
    }
}
