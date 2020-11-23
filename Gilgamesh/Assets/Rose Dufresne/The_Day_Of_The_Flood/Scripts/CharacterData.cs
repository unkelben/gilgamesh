using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rose.Characters
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Character")]
    public class CharacterData : ScriptableObject
    {
        public Sprite sprite;
        public RuntimeAnimatorController animatorController;
        public AudioClip[] voiceLines;
        public AudioClip alarm;
        public AudioClip confused;
    }
}
