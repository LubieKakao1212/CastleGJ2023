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

	public struct Player_id0_PlayerHP_520862196960591170 : ICoherenceComponentData
	{
		public int SyncHP;
		public int SyncMaxHP;

		public override string ToString()
		{
			return $"Player_id0_PlayerHP_520862196960591170(SyncHP: {SyncHP}, SyncMaxHP: {SyncMaxHP})";
		}

		public uint GetComponentType() => Definition.InternalPlayer_id0_PlayerHP_520862196960591170;

		public const int order = 0;

		public int GetComponentOrder() => order;

		public AbsoluteSimulationFrame Frame;
	
		private static readonly int _SyncHP_Min = -2147483648;
		private static readonly int _SyncHP_Max = 2147483647;
		private static readonly int _SyncMaxHP_Min = -2147483648;
		private static readonly int _SyncMaxHP_Max = 2147483647;

		public void SetSimulationFrame(AbsoluteSimulationFrame frame)
		{
			Frame = frame;
		}

		public AbsoluteSimulationFrame GetSimulationFrame() => Frame;

		public ICoherenceComponentData MergeWith(ICoherenceComponentData data, uint mask)
		{
			var other = (Player_id0_PlayerHP_520862196960591170)data;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				SyncHP = other.SyncHP;
			}
			mask >>= 1;
			if ((mask & 0x01) != 0)
			{
				Frame = other.Frame;
				SyncMaxHP = other.SyncMaxHP;
			}
			mask >>= 1;
			return this;
		}

		public uint DiffWith(ICoherenceComponentData data)
		{
			throw new System.NotSupportedException($"{nameof(DiffWith)} is not supported in Unity");

		}

		public static void Serialize(Player_id0_PlayerHP_520862196960591170 data, uint mask, IOutProtocolBitStream bitStream)
		{
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.SyncHP, _SyncHP_Min, _SyncHP_Max, "Player_id0_PlayerHP_520862196960591170.SyncHP");
				data.SyncHP = Coherence.Utils.Bounds.Clamp(data.SyncHP, _SyncHP_Min, _SyncHP_Max);
				bitStream.WriteIntegerRange(data.SyncHP, 32, -2147483648);
			}
			mask >>= 1;
			if (bitStream.WriteMask((mask & 0x01) != 0))
			{
				Coherence.Utils.Bounds.Check(data.SyncMaxHP, _SyncMaxHP_Min, _SyncMaxHP_Max, "Player_id0_PlayerHP_520862196960591170.SyncMaxHP");
				data.SyncMaxHP = Coherence.Utils.Bounds.Clamp(data.SyncMaxHP, _SyncMaxHP_Min, _SyncMaxHP_Max);
				bitStream.WriteIntegerRange(data.SyncMaxHP, 32, -2147483648);
			}
			mask >>= 1;
		}

		public static (Player_id0_PlayerHP_520862196960591170, uint, uint?) Deserialize(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Player_id0_PlayerHP_520862196960591170();
	
			if (bitStream.ReadMask())
			{
				val.SyncHP = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000000000000000001;
			}
			if (bitStream.ReadMask())
			{
				val.SyncMaxHP = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000000000000000010;
			}
			return (val, mask, null);
		}
		public static (Player_id0_PlayerHP_520862196960591170, uint, uint?) DeserializeArchetypePlayer_3b896e424d82c884d9d345e909e13ea9_Player_id0_PlayerHP_520862196960591170_LOD0(InProtocolBitStream bitStream)
		{
			var mask = (uint)0;
			var val = new Player_id0_PlayerHP_520862196960591170();
			if (bitStream.ReadMask())
			{
				val.SyncHP = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000000000000000001;
			}
			if (bitStream.ReadMask())
			{
				val.SyncMaxHP = bitStream.ReadIntegerRange(32, -2147483648);
				mask |= 0b00000000000000000000000000000010;
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
			var last = lastSent as Player_id0_PlayerHP_520862196960591170?;
	
		}
	}
}