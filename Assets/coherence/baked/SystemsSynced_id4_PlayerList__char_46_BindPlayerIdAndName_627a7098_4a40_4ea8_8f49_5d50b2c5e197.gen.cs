// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
	using Coherence.ProtocolDef;
	using Coherence.Serializer;
	using Coherence.Brook;
	using UnityEngine;
	using Coherence.Entity;

	public struct SystemsSynced_id4_PlayerList__char_46_BindPlayerIdAndName_627a7098_4a40_4ea8_8f49_5d50b2c5e197 : IEntityCommand
	{
		public SerializeEntityID targetPlayerSync;
		public string playerName;
		public uint id;

		public MessageTarget Routing => MessageTarget.All;
		public uint GetComponentType() => Definition.InternalSystemsSynced_id4_PlayerList__char_46_BindPlayerIdAndName_627a7098_4a40_4ea8_8f49_5d50b2c5e197;

		public SystemsSynced_id4_PlayerList__char_46_BindPlayerIdAndName_627a7098_4a40_4ea8_8f49_5d50b2c5e197
		(
			SerializeEntityID datatargetPlayerSync,
			string dataplayerName,
			uint dataid
		)
		{
			targetPlayerSync = datatargetPlayerSync;
			playerName = dataplayerName;
			id = dataid;
		}

		public static void Serialize(SystemsSynced_id4_PlayerList__char_46_BindPlayerIdAndName_627a7098_4a40_4ea8_8f49_5d50b2c5e197 commandData, IOutProtocolBitStream bitStream)
		{
			bitStream.WriteEntity(commandData.targetPlayerSync);
			bitStream.WriteShortString(commandData.playerName);
			bitStream.WriteUIntegerRange(commandData.id, 32, 0);
		}

		public static SystemsSynced_id4_PlayerList__char_46_BindPlayerIdAndName_627a7098_4a40_4ea8_8f49_5d50b2c5e197 Deserialize(IInProtocolBitStream bitStream)
		{
			var datatargetPlayerSync = bitStream.ReadEntity();
			var dataplayerName = bitStream.ReadShortString();
			var dataid = bitStream.ReadUIntegerRange(32, 0);

			return new SystemsSynced_id4_PlayerList__char_46_BindPlayerIdAndName_627a7098_4a40_4ea8_8f49_5d50b2c5e197
			(
				datatargetPlayerSync,
				dataplayerName,
				dataid
			){};
		}
	}
}