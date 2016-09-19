﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PolarisLib.packet.Packets
{
	public class PacketDamage : Packet
	{
		public uint playerID; //0x8-0xB
		public byte[] unk1; //0xC-0x12, 8
		public uint targetID; //0x14-0x17
		public byte[] unk2; //0x18-0x1D, 6
		public ushort instanceID; //0x1E-1F
		public uint sourceID; //0x20-0x23
		public byte[] unk3; //0x24-0x2B, 8
		public uint atkID; //0x2C-0x2F
		public int value; //0x30-0x33
		public byte[] unk4; //0x34-0x43, 16
		public byte flags; //0x44
		public byte[] unk5; //0x45-0x50, 11

		public PacketDamage(byte[] pkt) : base(pkt)
		{
			ParseData(data);
		}

		protected override void ParseData(byte[] data)
		{
			BinaryReader b = new BinaryReader(new MemoryStream(data));
			playerID = b.ReadUInt32();
			unk1 = b.ReadBytes(0x8);
			targetID = b.ReadUInt32();
			unk2 = b.ReadBytes(0x6);
			instanceID = b.ReadUInt16();
			sourceID = b.ReadUInt32();
			unk3 = b.ReadBytes(0x8);
			atkID = b.ReadUInt32();
			value = b.ReadInt32();
			unk4 = b.ReadBytes(0x10);
			flags = b.ReadByte();
			unk5 = b.ReadBytes(0x11);
		}
	}
}
