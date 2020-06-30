using GACore.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GACore.Dtos
{
	[DataContract]
	public class SemVerDto 
	{
		[DataMember]
		public int Major { get; set; } = -1;

		[DataMember]
		public int Minor { get; set; } = -1;

		[DataMember]
		public int Patch { get; set; } = -1;

		[DataMember]
		public string ReleaseFlag { get; set; } = string.Empty;
	}
}
