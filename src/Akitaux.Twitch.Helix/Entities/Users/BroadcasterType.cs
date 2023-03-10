using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    [ModelStringEnum]
    public enum BroadcasterType
    {
        [ModelEnumValue("", type: EnumValueType.ReadOnly)]
        None = -1,
        [ModelEnumValue("affiliate")]
        Affiliate,
        [ModelEnumValue("partner")]
        Partner
    }
}
