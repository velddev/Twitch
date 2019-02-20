﻿using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public enum VideoSort
    {
        [ModelEnumValue("time", type: EnumValueType.ReadOnly)]
        Time,
        [ModelEnumValue("trending")]
        Trending,
        [ModelEnumValue("views")]
        Views
    }
}
