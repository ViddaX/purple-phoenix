using System;

namespace pp {

	/// <summary>
	/// Raw material types.
	/// </summary>
	public enum ItemType {
		None,
		IronSheet,
		Wheel,
		Rubber,
		Aluminum,
		Seat, 
		Leather,
		Cotton,
		CarBody,
		BikeBody,
		Steel,
		Window, 
		Glass
	}

	public static class ItemTypeExtensions {
		public static ItemProperty[] GetProperties(this ItemType type) {
			switch (type) {
			case ItemType.IronSheet:
				return new ItemProperty[] {ItemProperty.Metal, ItemProperty.Thin};
			case ItemType.Aluminum:
				return new ItemProperty[] {ItemProperty.Metal, ItemProperty.Thin, ItemProperty.Light};
			case ItemType.CarBody:
				return new ItemProperty[] {ItemProperty.Metal, ItemProperty.IrregularShape, ItemProperty.Heavy};
			case ItemType.BikeBody:
				return new ItemProperty[] {ItemProperty.Metal, ItemProperty.IrregularShape, ItemProperty.Heavy};
			case ItemType.Cotton:
				return new ItemProperty[] {ItemProperty.Light, ItemProperty.Small, ItemProperty.Thick};
			case ItemType.Glass:
				return new ItemProperty[] {ItemProperty.Light, ItemProperty.Transparent, ItemProperty.Thin};
			case ItemType.Rubber:
				return new ItemProperty[] {ItemProperty.Thick, ItemProperty.Heavy, ItemProperty.Circular};
			case ItemType.Leather:
				return new ItemProperty[] {ItemProperty.Thin, ItemProperty.Heavy};
			case ItemType.Steel:
				return new ItemProperty[] {ItemProperty.Metal, ItemProperty.Thick};
			case ItemType.Wheel:
				return new ItemProperty[] {ItemProperty.Metal, ItemProperty.Circular, ItemProperty.Heavy, ItemProperty.Thick};
			case ItemType.Seat:
				return new ItemProperty[] {ItemProperty.IrregularShape, ItemProperty.Light};
			case ItemType.Window:
				return new ItemProperty[] {ItemProperty.Transparent, ItemProperty.IrregularShape, ItemProperty.Heavy};
			default:
				throw new NotImplementedException();
			}
		}

		public static bool HasProperty(this ItemType type, ItemProperty property) {
			return Array.FindIndex(GetProperties(type), x => x == property) != -1;
		}

	}

}