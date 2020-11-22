using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAdderCodingTest.ServiceClients
{
	public class CandidateMatch
	{
		public Candidate Candidate {get; set;}
		public IEnumerable<string> MatchingSkills { get; set; }
		
	}
}
