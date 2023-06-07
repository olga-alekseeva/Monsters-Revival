using UnityEngine;

namespace Settings
{
    internal sealed class ResourcePathes
    {
        internal sealed class ScriptableObjects
        {
            public const string PLAYER_MODEL_SETTINGS = "ScriptableObject/PlayerModelSettings";
            public const string FIREBALL_SETTINGS = "ScriptableObject/FireballSettings";
            public const string ENEMY_MODEL_SETTINGS = "ScriptableObject/EnemyModelSettings";
            public const string ENEMIES_SHIELD_MODEL_SETTINGS = "ScriptableObject/EnemiesShieldModelSettings";
            public const string ARCHER_MODEL_SETTINGS = "ScriptableObject/ArcherModelSettings";
            public const string LEVEL_LIST = "ScriptableObject/LevelList";
            public const string BOW_MODEL_SETTINGS = "ScriptableObject/BowModelSettings";
            public const string MAIN_CAMERA_SETTINGS = "ScriptableObject/MainCameraSettings";
            public const string ARROW_MODEL_SETTINGS = "ScriptableObject/ArrowModelSettings";
            public const string SIMPLE_ENEMY_MODEL_SETTINGS = "ScriptableObject/SimpleEnemyModelSettings";
        }
        internal sealed class Prefabs
        {
            public const string FIREBALL = "Prefabs/Fireball";
            public const string PLAYER = "Prefabs/Player";
            public const string ARCHER_ENEMY = "Prefabs/ArcherEnemy";
            public const string ENEMY_WITH_SHIELD = "Prefabs/EnemyWithShield";
            public const string PORTAL = "Prefabs/Portal";
            public const string HEALTH_BAR = "Prefabs/HealhBar";
            public const string ARROW = "Prefabs/Arrow";
            public const string SIMPLE_ENEMY = "Prefabs/SimpleEnemy";
            public const string LAUNCH_COUNT_UI = "Prefabs/UI/LaunchCountUI";
        }

        internal sealed class EffectsPrefabs
        {
            public const string SPARK_ROCK = "Prefabs/Effects/RockHit";
        }
    }
}
