﻿using Beatmap.Base;
using Beatmap.Base.Customs;
using SimpleJSON;

namespace Beatmap.V2.Customs
{
    public class V2CustomEvent : BaseCustomEvent, V2Object
    {
        public V2CustomEvent()
        {
        }

        public V2CustomEvent(BaseCustomEvent other) : base(other)
        {
        }

        public V2CustomEvent(JSONNode node) : base(node)
        {
        }

        public V2CustomEvent(float time, string type, JSONNode node = null) : base(time, type, node)
        {
        }

        public override string CustomKeyTrack { get; } = "_track";
        public override string CustomKeyColor { get; } = "_color";
        public override string KeyTime { get; } = "_time";
        public override string KeyType { get; } = "_type";
        public override string KeyData { get; } = "_data";
        public override string DataKeyDuration { get; } = "_duration";
        public override string DataKeyEasing { get; } = "_easing";
        public override string DataKeyRepeat { get; } = "_repeat";
        public override string DataKeyChildrenTracks { get; } = "_childrenTracks";
        public override string DataKeyParentTrack { get; } = "_parentTrack";
        public override string DataKeyWorldPositionStays { get; } = "_worldPositionStays";

        public override BaseItem Clone() => new V2CustomEvent(JsonTime, Type, Data.Clone());
    }
}
