using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAdderCodingTest.ServiceClients
{
	public interface IJobAddderApiClient
	{
		Task<List<Candidate>> GetCandidates();
		Task<List<Job>> GetJobs();
	}
}
