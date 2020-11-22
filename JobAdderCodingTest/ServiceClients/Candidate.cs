using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAdderCodingTest.ServiceClients
{
	public class Candidate
	{
		public int CandidateId { get; set; }
		public string Name { get; set; }
		public List<string> SkillTags { get; set; }
	}
}
