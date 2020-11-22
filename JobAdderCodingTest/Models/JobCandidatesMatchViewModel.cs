using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAdderCodingTest.Models
{
	public class JobCandidatesMatchViewModel
	{
		public int JobId { get; set; }
		public string Name { get; set; }
		public string Company { get; set; }
		public string Skills { get; set; }
		public IEnumerable<CandidateViewModel> Candidates { get; set; }
	}
}
