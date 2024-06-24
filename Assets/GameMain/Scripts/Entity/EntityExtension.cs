//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.DataTable;
using System;
using UnityGameFramework.Runtime;
using GFLearning.CollectApples;

namespace GFLearning
{
    public static class EntityExtension
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
        private static int s_SerialId = 0;


        // 通过实体ID获取实体对象
        public static Entity GetGameEntity(this EntityComponent entityComponent, int entityId)
        {
            UnityGameFramework.Runtime.Entity entity = entityComponent.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return (Entity)entity.Logic;
        }

        // 通过实体ID隐藏实体对象
        public static void HideEntity(this EntityComponent entityComponent, Entity entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }

        // 将实体附加到另一个实体
        public static void AttachEntity(this EntityComponent entityComponent, Entity entity, int ownerId, string parentTransformPath = null, object userData = null)
        {
            entityComponent.AttachEntity(entity.Entity, ownerId, parentTransformPath, userData);
        }

        private static void ShowEntity(this EntityComponent entityComponent, Type logicType, string entityGroup, int priority, EntityData data)
        {
            if (data == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(data.TypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
                return;
            }

            entityComponent.ShowEntity(data.Id, logicType, AssetUtility.GetEntityAsset(drEntity.AssetName), entityGroup, priority, data);
        }

        // 生成唯一的序列ID（负值）
        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }

        /// <summary>
        /// CollectApples
        /// </summary>
        public static void ShowCollectApples_Basket(this EntityComponent entityComponent, BasketData data)
        {
            entityComponent.ShowEntity(typeof(Basket), "CollectApples.Basket", Constant.AssetPriority.CollectApples_DefaultAsset, data);
        }
        public static void ShowCollectApples_AppleTree(this EntityComponent entityComponent, AppleTreeData data)
        {
            entityComponent.ShowEntity(typeof(AppleTree), "CollectApples.AppleTree", Constant.AssetPriority.CollectApples_DefaultAsset, data);
        }
        public static void ShowCollectApples_Apple(this EntityComponent entityComponent, AppleData data)
        {
            entityComponent.ShowEntity(typeof(Apple), "CollectApples.Apple", Constant.AssetPriority.CollectApples_DefaultAsset, data);
        }
    }
}
