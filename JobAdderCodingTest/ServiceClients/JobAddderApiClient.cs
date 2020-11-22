using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace JobAdderCodingTest.ServiceClients
{
	public class JobAddderApiClient : IJobAddderApiClient
	{
		private readonly string _baseAddress;
		private readonly HttpClient _client;
		private readonly IMapper _mapper;

		public JobAddderApiClient(IConfiguration configuration, HttpClient client, IMapper mapper)
		{
			_client = client;
			_mapper = mapper;
			_baseAddress = configuration.GetSection("JobAdderApi").GetValue<string>("BaseUrl");
		}

		public async Task<List<Candidate>> GetCandidates()
		{
			var apiCallTask = _client.GetStreamAsync(new Uri($"{_baseAddress}/candidates")).ConfigureAwait(false);
			var candidateResponse = await JsonSerializer.DeserializeAsync<List<CandidateResponse>>(await apiCallTask);
			return candidateResponse.Select(x => _mapper.Map<Candidate>(x)).ToList();
		}

		public async Task<List<Job>> GetJobs()
		{
			var apiCallTask = _client.GetStreamAsync(new Uri($"{_baseAddress}/jobs")).ConfigureAwait(false);
			var jobResponse = await JsonSerializer.DeserializeAsync<List<JobResponse>>(await apiCallTask);
			return jobResponse.Select(x => _mapper.Map<Job>(x)).ToList();
		}
	}
}
