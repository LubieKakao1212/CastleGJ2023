// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Serializer;
	using Coherence.SimulationFrame;
	using Coherence.Entity;
	using Coherence.Utils;
	using Coherence.Brook;
	using Coherence.Toolkit;
	using UnityEngine;

	public struct SystemsSynced_id4_PlayerList_5830596318896160362 : ICoherenceComponentData
	{
		public uint nextId;

		public override string ToString()
		{
			return $"SystemsSynced_id4_PlayerList_5830596318896160362(nextId: {nextId})";
		}

		public uint GetComponentType() => Definition.InternalSystemsSynced_id4_PlayerList_5830596318896160362;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;
	
		private static readonly uint _nextId_Min = 0;
		private static readonly uint _nextId_Max = 4294967295;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (SystemsSynced_id4_PlayerList_5830596318896160362)data;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				nextId = other.nextId;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			throw new System.NotSupportedException($"{nameof(DiffWith)} is not supported in Unity");

		}

		public static void Serialize(SystemsSynced_id4_PlayerList_5830596318896160362 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.nextId, _nextId_Min, _nextId_Max, "SystemsSynced_id4_PlayerList_5830596318896160362.nextId");
				data.nextId = Coherence.Utils.Bounds.Clamp(data.nextId, _nextId_Min, _nextId_Max);
				bitStream.WriteUIntegerRange(data.nextId, 32, 0);
			}
			mask >>= 1;
		}

		public static (SystemsSynced_id4_PlayerList_5830596318896160362, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new SystemsSynced_id4_PlayerList_5830596318896160362();
	
			if (bitStream.ReadMask())
			{
				val.nextId = bitStream.ReadUIntegerRange(32, 0);
				mask |= 0b00000000000000000000000000000001;
			}
			return (val, mask, null);
		}
		public static (SystemsSynced_id4_PlayerList_5830596318896160362, uint, uint?) DeserializeArchetypeSystemsSynced_ec84610ffed7f904db8ab89dc4452e37_SystemsSynced_id4_PlayerList_5830596318896160362_LOD0(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new SystemsSynced_id4_PlayerList_5830596318896160362();
			if (bitStream.ReadMask())
			{
				val.nextId = bitStream.ReadUIntegerRange(32, 0);
				mask |= 0b00000000000000000000000000000001;
			}

			return (val, mask, 0);
		}

		/// <summary>
		/// Resets byte array references to the local array instance that is kept in the lastSentData.
		/// If the array content has changed but remains of same length, the new content is copied into the local array instance.
		/// If the array length has changed, the array is cloned and overwrites the local instance.
		/// If the array has not changed, the reference is reset to the local array instance.
		/// Otherwise, changes to other fields on the component might cause the local array instance reference to become permanently lost.
		/// </summary>
		public void ResetByteArrays(ICoherenceComponentData lastSent, uint mask)
		{
			var last = lastSent as SystemsSynced_id4_PlayerList_5830596318896160362?;
	
		}
	}
}