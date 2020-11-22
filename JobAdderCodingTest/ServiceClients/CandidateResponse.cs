using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAdderCodingTest.ServiceClients
{
	public class CandidateResponse
	{
		public int candidateId {get; set;}
		public string name { get; set; }
		public string skillTags { get; set; }
	}
}
