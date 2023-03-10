using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    [ModelStringEnum]
    public enum BitsPeriod
    {
        [ModelEnumValue("", EnumValueType.ReadOnly)]
        All,
        [ModelEnumValue("day")]
        Day,
        [ModelEnumValue("week")]
        Week,
        [ModelEnumValue("month")]
        Month,
        [ModelEnumValue("year")]
        Year
    }
}
