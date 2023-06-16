// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using Coherence.Toolkit;
	using Coherence.Toolkit.Bindings;
	using Coherence.Entity;
	using Coherence.ProtocolDef;
	using Coherence.Brook;
	using Coherence.Toolkit.Bindings.ValueBindings;
	using Coherence.Toolkit.Bindings.TransformBindings;
	using Coherence.Connection;
	using Coherence.Log;
	using Logger = Coherence.Log.Logger;
	using UnityEngine.Scripting;

	public class Binding_3b896e424d82c884d9d345e909e13ea9_406d0057_fba8_43e8_bfb8_6bf37c28e701 : PositionBinding
	{
		public override string CoherenceComponentName => "WorldPosition";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override Vector3 Value
		{
			get => (Vector3)(UnityEngine.Vector3)(coherenceSync.coherencePosition);
			set => coherenceSync.coherencePosition = (UnityEngine.Vector3)(value);
		}

		protected override Vector3 ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			var value = ((WorldPosition)coherenceComponent).value;
			if (!coherenceSync.HasParentWithCoherenceSync)
            {
                value += floatingOriginDelta;
            }
			return value;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (WorldPosition)coherenceComponent;
			update.value = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new WorldPosition();
		}
	}

	public class Binding_3b896e424d82c884d9d345e909e13ea9_f6d8171a_bf23_4f6d_beb0_d5eaf1d441f4 : IntBinding
	{
		private PlayerHP CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (PlayerHP)UnityComponent;
		}
		public override string CoherenceComponentName => "Player_id0_PlayerHP_520862196960591170";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override int Value
		{
			get => (int)(System.Int32)(CastedUnityComponent.SyncHP);
			set => CastedUnityComponent.SyncHP = (System.Int32)(value);
		}

		protected override int ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			var value = ((Player_id0_PlayerHP_520862196960591170)coherenceComponent).SyncHP;
			return value;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Player_id0_PlayerHP_520862196960591170)coherenceComponent;
			update.SyncHP = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Player_id0_PlayerHP_520862196960591170();
		}
	}

	public class Binding_3b896e424d82c884d9d345e909e13ea9_187ffbe0_18e5_429d_ba71_70eb0234f13a : IntBinding
	{
		private PlayerHP CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (PlayerHP)UnityComponent;
		}
		public override string CoherenceComponentName => "Player_id0_PlayerHP_520862196960591170";

		public override uint FieldMask => 0b00000000000000000000000000000010;

		public override int Value
		{
			get => (int)(System.Int32)(CastedUnityComponent.SyncMaxHP);
			set => CastedUnityComponent.SyncMaxHP = (System.Int32)(value);
		}

		protected override int ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			var value = ((Player_id0_PlayerHP_520862196960591170)coherenceComponent).SyncMaxHP;
			return value;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Player_id0_PlayerHP_520862196960591170)coherenceComponent;
			update.SyncMaxHP = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Player_id0_PlayerHP_520862196960591170();
		}
	}

	public class Binding_3b896e424d82c884d9d345e909e13ea9_79180d4f_b363_4217_9e50_e489fc56e306 : UIntBinding
	{
		private PlayerInfo CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (PlayerInfo)UnityComponent;
		}
		public override string CoherenceComponentName => "Player_id0_PlayerInfo_3474864809680843249";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override uint Value
		{
			get => (uint)(System.UInt32)(CastedUnityComponent.PlayerId);
			set => CastedUnityComponent.PlayerId = (System.UInt32)(value);
		}

		protected override uint ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			var value = ((Player_id0_PlayerInfo_3474864809680843249)coherenceComponent).PlayerId;
			return value;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Player_id0_PlayerInfo_3474864809680843249)coherenceComponent;
			update.PlayerId = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Player_id0_PlayerInfo_3474864809680843249();
		}
	}

	public class Binding_3b896e424d82c884d9d345e909e13ea9_6dfae5aa_d9d8_4842_94ac_77e7e9313440 : StringBinding
	{
		private PlayerInfo CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (PlayerInfo)UnityComponent;
		}
		public override string CoherenceComponentName => "Player_id0_PlayerInfo_3474864809680843249";

		public override uint FieldMask => 0b00000000000000000000000000000010;

		public override string Value
		{
			get => (string)(System.String)(CastedUnityComponent.PlayerName);
			set => CastedUnityComponent.PlayerName = (System.String)(value);
		}

		protected override string ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			var value = ((Player_id0_PlayerInfo_3474864809680843249)coherenceComponent).PlayerName;
			return value;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Player_id0_PlayerInfo_3474864809680843249)coherenceComponent;
			update.PlayerName = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Player_id0_PlayerInfo_3474864809680843249();
		}
	}

	public class Binding_3b896e424d82c884d9d345e909e13ea9_ee745906_d1ab_461e_9049_1780b0f3f185 : DeepRotationBinding
	{
		private UnityEngine.Transform CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (UnityEngine.Transform)UnityComponent;
		}
		public override string CoherenceComponentName => "Player_id0_UnityEngine__char_46_Transform_2639605840214257464";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override Quaternion Value
		{
			get => (Quaternion)(UnityEngine.Quaternion)(CastedUnityComponent.localRotation);
			set => CastedUnityComponent.localRotation = (UnityEngine.Quaternion)(value);
		}

		protected override Quaternion ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			var value = ((Player_id0_UnityEngine__char_46_Transform_2639605840214257464)coherenceComponent).rotation;
			return value;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Player_id0_UnityEngine__char_46_Transform_2639605840214257464)coherenceComponent;
			update.rotation = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Player_id0_UnityEngine__char_46_Transform_2639605840214257464();
		}
	}


	[Preserve]
	[AddComponentMenu("coherence/Baked/Baked 'Player' (auto assigned)")]
	[RequireComponent(typeof(CoherenceSync))]
	public class CoherenceSyncPlayer_id0 : CoherenceSyncBaked
	{
		private CoherenceSync coherenceSync;
		private Logger logger;

		// Cached targets for commands

		private IClient client;
		private CoherenceMonoBridge monoBridge => coherenceSync.MonoBridge;

		protected void Awake()
		{
			coherenceSync = GetComponent<CoherenceSync>();
			coherenceSync.usingReflection = false;

			logger = coherenceSync.logger.With<CoherenceSyncPlayer_id0>();
			if (coherenceSync.TryGetBindingByGuid("406d0057-fba8-43e8-bfb8-6bf37c28e701", "position", out Binding InternalWorldPosition_Translation_value))
			{
				var clone = new Binding_3b896e424d82c884d9d345e909e13ea9_406d0057_fba8_43e8_bfb8_6bf37c28e701();
				InternalWorldPosition_Translation_value.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalWorldPosition_Translation_value)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.Transform).position");
			}
			if (coherenceSync.TryGetBindingByGuid("f6d8171a-bf23-4f6d-beb0-d5eaf1d441f4", "SyncHP", out Binding InternalPlayer_id0_PlayerHP_520862196960591170_Player_id0_PlayerHP_520862196960591170_SyncHP))
			{
				var clone = new Binding_3b896e424d82c884d9d345e909e13ea9_f6d8171a_bf23_4f6d_beb0_d5eaf1d441f4();
				InternalPlayer_id0_PlayerHP_520862196960591170_Player_id0_PlayerHP_520862196960591170_SyncHP.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlayer_id0_PlayerHP_520862196960591170_Player_id0_PlayerHP_520862196960591170_SyncHP)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (PlayerHP).SyncHP");
			}
			if (coherenceSync.TryGetBindingByGuid("187ffbe0-18e5-429d-ba71-70eb0234f13a", "SyncMaxHP", out Binding InternalPlayer_id0_PlayerHP_520862196960591170_Player_id0_PlayerHP_520862196960591170_SyncMaxHP))
			{
				var clone = new Binding_3b896e424d82c884d9d345e909e13ea9_187ffbe0_18e5_429d_ba71_70eb0234f13a();
				InternalPlayer_id0_PlayerHP_520862196960591170_Player_id0_PlayerHP_520862196960591170_SyncMaxHP.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlayer_id0_PlayerHP_520862196960591170_Player_id0_PlayerHP_520862196960591170_SyncMaxHP)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (PlayerHP).SyncMaxHP");
			}
			if (coherenceSync.TryGetBindingByGuid("79180d4f-b363-4217-9e50-e489fc56e306", "PlayerId", out Binding InternalPlayer_id0_PlayerInfo_3474864809680843249_Player_id0_PlayerInfo_3474864809680843249_PlayerId))
			{
				var clone = new Binding_3b896e424d82c884d9d345e909e13ea9_79180d4f_b363_4217_9e50_e489fc56e306();
				InternalPlayer_id0_PlayerInfo_3474864809680843249_Player_id0_PlayerInfo_3474864809680843249_PlayerId.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlayer_id0_PlayerInfo_3474864809680843249_Player_id0_PlayerInfo_3474864809680843249_PlayerId)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (PlayerInfo).PlayerId");
			}
			if (coherenceSync.TryGetBindingByGuid("6dfae5aa-d9d8-4842-94ac-77e7e9313440", "PlayerName", out Binding InternalPlayer_id0_PlayerInfo_3474864809680843249_Player_id0_PlayerInfo_3474864809680843249_PlayerName))
			{
				var clone = new Binding_3b896e424d82c884d9d345e909e13ea9_6dfae5aa_d9d8_4842_94ac_77e7e9313440();
				InternalPlayer_id0_PlayerInfo_3474864809680843249_Player_id0_PlayerInfo_3474864809680843249_PlayerName.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlayer_id0_PlayerInfo_3474864809680843249_Player_id0_PlayerInfo_3474864809680843249_PlayerName)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (PlayerInfo).PlayerName");
			}
			if (coherenceSync.TryGetBindingByGuid("ee745906-d1ab-461e-9049-1780b0f3f185", "rotation", out Binding InternalPlayer_id0_UnityEngine__char_46_Transform_2639605840214257464_Player_id0_UnityEngine__char_46_Transform_2639605840214257464_rotation))
			{
				var clone = new Binding_3b896e424d82c884d9d345e909e13ea9_ee745906_d1ab_461e_9049_1780b0f3f185();
				InternalPlayer_id0_UnityEngine__char_46_Transform_2639605840214257464_Player_id0_UnityEngine__char_46_Transform_2639605840214257464_rotation.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalPlayer_id0_UnityEngine__char_46_Transform_2639605840214257464_Player_id0_UnityEngine__char_46_Transform_2639605840214257464_rotation)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.Transform).rotation");
			}
		}

		public override List<ICoherenceComponentData> CreateEntity()
		{
			if (coherenceSync.UsesLODsAtRuntime && (Archetypes.IndexForName.TryGetValue(coherenceSync.Archetype.ArchetypeName, out int archetypeIndex)))
			{
				var components = new List<ICoherenceComponentData>()
				{
					new ArchetypeComponent
					{
						index = archetypeIndex
					}
				};

				return components;
			}
			else
			{
				logger.Warning($"Unable to find archetype {coherenceSync.Archetype.ArchetypeName} in dictionary. Please, bake manually (coherence > Bake)");
			}

			return null;
		}

		public override void Initialize(CoherenceSync sync, IClient client)
		{
			if (coherenceSync == null)
			{
				coherenceSync = sync;
			}
			this.client = client;
		}

		public override void ReceiveCommand(IEntityCommand command)
		{
			switch(command)
			{
				default:
					logger.Warning($"[CoherenceSyncPlayer_id0] Unhandled command: {command.GetType()}.");
					break;
			}
		}
	}
}
