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

	public struct MessageBoard_id3_MessageBoard__char_46_AddDeathMessageInternal_8b0fef53_8cf8_4bfd_b3ff_1294f6e09f55 : IEntityCommand
	{
		public uint target;
		public uint source;
		public uint messageSet;
		public uint message;

		public MessageTarget Routing => MessageTarget.All;
		public uint GetComponentType() => Definition.InternalMessageBoard_id3_MessageBoard__char_46_AddDeathMessageInternal_8b0fef53_8cf8_4bfd_b3ff_1294f6e09f55;

		public MessageBoard_id3_MessageBoard__char_46_AddDeathMessageInternal_8b0fef53_8cf8_4bfd_b3ff_1294f6e09f55
		(
			uint datatarget,
			uint datasource,
			uint datamessageSet,
			uint datamessage
		)
		{
			target = datatarget;
			source = datasource;
			messageSet = datamessageSet;
			message = datamessage;
		}

		public static void Serialize(MessageBoard_id3_MessageBoard__char_46_AddDeathMessageInternal_8b0fef53_8cf8_4bfd_b3ff_1294f6e09f55 commandData, IOutProtocolBitStream bitStream)
		{
			bitStream.WriteUIntegerRange(commandData.target, 32, 0);
			bitStream.WriteUIntegerRange(commandData.source, 32, 0);
			bitStream.WriteUIntegerRange(commandData.messageSet, 32, 0);
			bitStream.WriteUIntegerRange(commandData.message, 32, 0);
		}

		public static MessageBoard_id3_MessageBoard__char_46_AddDeathMessageInternal_8b0fef53_8cf8_4bfd_b3ff_1294f6e09f55 Deserialize(IInProtocolBitStream bitStream)
		{
			var datatarget = bitStream.ReadUIntegerRange(32, 0);
			var datasource = bitStream.ReadUIntegerRange(32, 0);
			var datamessageSet = bitStream.ReadUIntegerRange(32, 0);
			var datamessage = bitStream.ReadUIntegerRange(32, 0);

			return new MessageBoard_id3_MessageBoard__char_46_AddDeathMessageInternal_8b0fef53_8cf8_4bfd_b3ff_1294f6e09f55
			(
				datatarget,
				datasource,
				datamessageSet,
				datamessage
			){};
		}
	}
}
