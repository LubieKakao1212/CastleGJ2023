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

	public class Binding_0c25a96a0fb615348b57d8131f1fc940_d766f79b_d810_4393_afbf_4a345b740256 : PositionBinding
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

	public class Binding_0c25a96a0fb615348b57d8131f1fc940_52a474b2_9e93_4a4e_a72d_e4acfd298611 : Vector2Binding
	{
		private Explosion CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (Explosion)UnityComponent;
		}
		public override string CoherenceComponentName => "Explosion_id1_Explosion_1780179320716845973";

		public override uint FieldMask => 0b00000000000000000000000000000001;

		public override Vector2 Value
		{
			get => (Vector2)(UnityEngine.Vector2)(CastedUnityComponent.direction);
			set => CastedUnityComponent.direction = (UnityEngine.Vector2)(value);
		}

		protected override Vector2 ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			var value = ((Explosion_id1_Explosion_1780179320716845973)coherenceComponent).direction;
			return value;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Explosion_id1_Explosion_1780179320716845973)coherenceComponent;
			update.direction = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Explosion_id1_Explosion_1780179320716845973();
		}
	}

	public class Binding_0c25a96a0fb615348b57d8131f1fc940_066ace98_66c1_4f5b_b72e_740ad6c9e8a9 : ReferenceBinding
	{
		private Explosion CastedUnityComponent;		

		protected override void OnBindingCloned()
		{
			CastedUnityComponent = (Explosion)UnityComponent;
		}
		public override string CoherenceComponentName => "Explosion_id1_Explosion_1780179320716845973";

		public override uint FieldMask => 0b00000000000000000000000000000010;

		public override SerializeEntityID Value
		{
			get => (SerializeEntityID)coherenceSync.MonoBridge.UnityObjectToEntityId(CastedUnityComponent.owner);
			set => CastedUnityComponent.owner = coherenceSync.MonoBridge.EntityIdToGameObject(value);
		}

		protected override SerializeEntityID ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
		{
			var value = ((Explosion_id1_Explosion_1780179320716845973)coherenceComponent).owner;
			return value;
		}
		
		public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent)
		{
			var update = (Explosion_id1_Explosion_1780179320716845973)coherenceComponent;
			update.owner = Value;
			return update;
		}

		public override ICoherenceComponentData CreateComponentData()
		{
			return new Explosion_id1_Explosion_1780179320716845973();
		}
	}


	[Preserve]
	[AddComponentMenu("coherence/Baked/Baked 'Explosion' (auto assigned)")]
	[RequireComponent(typeof(CoherenceSync))]
	public class CoherenceSyncExplosion_id1 : CoherenceSyncBaked
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

			logger = coherenceSync.logger.With<CoherenceSyncExplosion_id1>();
			if (coherenceSync.TryGetBindingByGuid("d766f79b-d810-4393-afbf-4a345b740256", "position", out Binding InternalWorldPosition_Translation_value))
			{
				var clone = new Binding_0c25a96a0fb615348b57d8131f1fc940_d766f79b_d810_4393_afbf_4a345b740256();
				InternalWorldPosition_Translation_value.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalWorldPosition_Translation_value)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (UnityEngine.Transform).position");
			}
			if (coherenceSync.TryGetBindingByGuid("52a474b2-9e93-4a4e-a72d-e4acfd298611", "direction", out Binding InternalExplosion_id1_Explosion_1780179320716845973_Explosion_id1_Explosion_1780179320716845973_direction))
			{
				var clone = new Binding_0c25a96a0fb615348b57d8131f1fc940_52a474b2_9e93_4a4e_a72d_e4acfd298611();
				InternalExplosion_id1_Explosion_1780179320716845973_Explosion_id1_Explosion_1780179320716845973_direction.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalExplosion_id1_Explosion_1780179320716845973_Explosion_id1_Explosion_1780179320716845973_direction)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (Explosion).direction");
			}
			if (coherenceSync.TryGetBindingByGuid("066ace98-66c1-4f5b-b72e-740ad6c9e8a9", "owner", out Binding InternalExplosion_id1_Explosion_1780179320716845973_Explosion_id1_Explosion_1780179320716845973_owner))
			{
				var clone = new Binding_0c25a96a0fb615348b57d8131f1fc940_066ace98_66c1_4f5b_b72e_740ad6c9e8a9();
				InternalExplosion_id1_Explosion_1780179320716845973_Explosion_id1_Explosion_1780179320716845973_owner.CloneTo(clone);
				coherenceSync.Bindings[coherenceSync.Bindings.IndexOf(InternalExplosion_id1_Explosion_1780179320716845973_Explosion_id1_Explosion_1780179320716845973_owner)] = clone;
			}
			else
			{
				logger.Error("Couldn't find binding (Explosion).owner");
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
					logger.Warning($"[CoherenceSyncExplosion_id1] Unhandled command: {command.GetType()}.");
					break;
			}
		}
	}
}
