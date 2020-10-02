using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterCreator2D
{
    public class Part : ScriptableObject
    {
        /// <summary>
        /// Part's package name.
        /// </summary>
        [Tooltip("Part's package name")]
        public string packageName;

        /// <summary>
        /// Part's category.
        /// </summary>
        [Tooltip("Part's category")]
        public PartCategory category;

#if UNITY_EDITOR || !CC2D_DEMO
        /// <summary>
        /// Part's main texture.
        /// </summary>
        [Tooltip("Part's main texture")]
        public Texture2D texture;
#endif

#if UNITY_EDITOR || !CC2D_DEMO
        /// <summary>
        /// Part's color mask.
        /// </summary>
        [Tooltip("Part's color mask")]
        public Texture2D colorMask;
#endif

        /// <summary>
        /// A list of BodyTypes supported by this Part.
        /// </summary>
        [Tooltip("List of BodyTypes supported by this Part")]
        public List<BodyType> supportedBody;

#if UNITY_EDITOR || !CC2D_DEMO
        /// <summary>
        /// List of sprite used by this Part.
        /// </summary>
        [Tooltip("List of sprite used by this Part")]
        public List<Sprite> sprites;
#endif
    }
}