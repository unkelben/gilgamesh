using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.Characters
{
    [CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
    public class NpcData : ScriptableObject
    {
        public Sprite npcSprite;
        public Animation npcAnimation;
    }
}
