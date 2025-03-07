using System;
using System.Collections.Generic;
using System.Linq;
using Beatmap.Base;
using SimpleJSON;
using UnityEngine;
using LiteNetLib.Utils;

namespace Beatmap.V3
{
    public class V3LightTranslationEventBoxGroup : BaseLightTranslationEventBoxGroup<BaseLightTranslationEventBox>, V3Object
    {
        public override void Serialize(NetDataWriter writer) => throw new NotImplementedException();
        public override void Deserialize(NetDataReader reader) => throw new NotImplementedException();
        public V3LightTranslationEventBoxGroup()
        {
        }

        public V3LightTranslationEventBoxGroup(JSONNode node)
        {
            JsonTime = node["b"].AsFloat;
            ID = node["g"].AsInt;
            Events = new List<BaseLightTranslationEventBox>(RetrieveRequiredNode(node, "e").AsArray.Linq
                .Select(x => new V3LightTranslationEventBox(x)).ToList());
            CustomData = node["customData"];
        }

        public V3LightTranslationEventBoxGroup(float time, int id, List<BaseLightTranslationEventBox> events,
            JSONNode customData = null) : base(time, id, events, customData)
        {
        }

        public override Color? CustomColor
        {
            get => null;
            set { }
        }

        public override string CustomKeyTrack { get; } = "track";
        public override string CustomKeyColor { get; } = "color";

        public override JSONNode ToJson()
        {
            JSONNode node = new JSONObject();
            node["b"] = JsonTime;
            node["g"] = ID;
            var ary = new JSONArray();
            foreach (var k in Events) ary.Add(k.ToJson());
            node["e"] = ary;
            CustomData = SaveCustom();
            if (!CustomData.Children.Any()) return node;
            node["customData"] = CustomData;
            return node;
        }

        // TODO: proper event box group cloning
        public override BaseItem Clone() => new V3LightTranslationEventBoxGroup(JsonTime, ID, Events);
    }
}
