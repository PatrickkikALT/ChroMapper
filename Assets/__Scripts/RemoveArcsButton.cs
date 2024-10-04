using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Beatmap.Base;
using Beatmap.Enums;
using Beatmap.V3;
using UnityEngine;

public class RemoveArcsButton : MonoBehaviour
{
    public bool Networked = false;
    internal bool affectsSeveralObjects = false;
    private static HashSet<BaseObject> SelectedObjects => SelectionController.SelectedObjects;
    
    public void RemoveArcs(bool refreshesPool = true)
    {
        var foundArcs = SelectedObjects.Where(IsArc).Cast<BaseArc>().ToList();
        foreach (var arc in foundArcs)
        {
            var collection = BeatmapObjectContainerCollection.GetCollectionForType(arc.ObjectType);
            if (Networked && !collection.ContainsObject(arc))
            {
                collection.RemoveConflictingObjects(new[] { arc });
                return;
            }

            collection.DeleteObject(arc, false, refreshesPool, inCollectionOfDeletes: affectsSeveralObjects);
        }
    }
    public static bool IsArc(BaseObject o) => o is BaseArc;
}
