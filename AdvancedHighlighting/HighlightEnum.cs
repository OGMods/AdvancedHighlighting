using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedHighlighting
{
    public enum Highlight
    {
        Pickupable,
        PickupableCreatures,
        PickupableResource,
        BreakableResource,
        ScannableItems,
        ScannableFragments,
        ScannedFragments,
        Interactables,
        StoryItems,
        DiskItems,
        SealedDoor,
        FruitAndVeg,
        OxygenFish,
        AnythingElse
    }
    public static class HighlightExtenstions
    {
        private static readonly Dictionary<Highlight, string> highlightToText = new Dictionary<Highlight, string>()
        {
            [Highlight.Pickupable] = "Pickupable Items",
            [Highlight.PickupableCreatures] = "Pickupable Creatures",
            [Highlight.PickupableResource] = "Pickupable Resources",
            [Highlight.BreakableResource] = "Breakable Outcrops",
            [Highlight.ScannableItems] = "Scannable Items",
            [Highlight.ScannableFragments] = "Scannable Fragments",
            [Highlight.ScannedFragments] = "Already Scanned Fragments",
            [Highlight.Interactables] = "Interactables",
            [Highlight.StoryItems] = "PDA Logs",
            [Highlight.DiskItems] = "Jukebox Disks",
            [Highlight.SealedDoor] = "Sealed Ship Doors",
            [Highlight.FruitAndVeg] = "Fruits and Vegetables",
            [Highlight.OxygenFish] = "Oxygen Fish",
            [Highlight.AnythingElse] = "Anything Else",
        };
        private static readonly Dictionary<Highlight, Type> highlightToType = new Dictionary<Highlight, Type>() { 
            [Highlight.Pickupable] = typeof(Pickupable),
            [Highlight.PickupableCreatures] = typeof(Creature),
            [Highlight.PickupableResource] = typeof(ResourceTracker),
            [Highlight.BreakableResource] = typeof(BreakableResource),
            [Highlight.Interactables] = typeof(GenericHandTarget),
            [Highlight.StoryItems] = typeof(StoryHandTarget),
            [Highlight.DiskItems] = typeof(JukeboxDisk),
            [Highlight.SealedDoor] = typeof(StarshipDoor),
            [Highlight.FruitAndVeg] = typeof(PickPrefab),
            [Highlight.OxygenFish] = typeof(TitanHolefishOxygen),
        };
        private static readonly List<Highlight> notComponentHighlights = new List<Highlight>()
        {
            Highlight.ScannableItems,
            Highlight.ScannableFragments,
            Highlight.ScannedFragments,
            Highlight.AnythingElse
        };
        public static bool IsPressent(this Highlight highlight, UnityEngine.Behaviour behaviour) => 
            highlight.IsComponent() && behaviour.TryGetComponent(highlight.GetComponentType(), out _);
        public static bool IsPressentAndActive(this Highlight highlight, UnityEngine.Behaviour behaviour) =>
            highlight.IsComponent() && highlight.IsActive() && behaviour.TryGetComponent(highlight.GetComponentType(), out _);
        public static bool IsActive(this Highlight highlight) => Settings.GetInstance().IsHighlightActive(highlight);
        public static bool IsComponent(this Highlight highlight) => !notComponentHighlights.Contains(highlight);
        public static string GetName(this Highlight highlight) => highlightToText.TryGetValue(highlight, out string name) ? name : null;
        public static Type GetComponentType(this Highlight highlight) => highlightToType.TryGetValue(highlight, out Type type) ? type : null;
    }
}
