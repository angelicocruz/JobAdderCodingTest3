using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobAdderCodingTest.Models;
using AutoMapper;
using JobAdderCodingTest.ServiceClients;

namespace JobAdderCodingTest.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private IMapper _mapper { get; }
		private IJobAddderApiClient _jobAddderApiClient { get;  }

		public HomeController(IJobAddderApiClient jobAddderApiClient, IMapper mapper, ILogger<HomeController> logger)
		{
			_logger = logger;
			_mapper = mapper;
			_jobAddderApiClient = jobAddderApiClient;
		}

		public async Task<IActionResult> Index()
		{
			var jobs = await _jobAddderApiClient.GetJobs();
			var candidates = await _jobAddderApiClient.GetCandidates();

			jobs.ForEach(j => (j.MatchingCandidates ??= new List<CandidateMatch>()).AddRange(
				candidates.Where(c => j.Skills.Intersect(c.SkillTags).Any()).Select(cm => new CandidateMatch {Candidate=cm, MatchingSkills= j.Skills.Intersect(cm.SkillTags) })
				));

			var model = jobs.Select(j => new JobCandidatesMatchViewModel 
						{
							Company=j.Company, 
							JobId=j.JobId, 
							Name=j.Name, 
							Skills=string.Join(",", j.Skills), 
							Candidates=j.MatchingCandidates.Select(c => new CandidateViewModel 
								{
									CandidateId=c.Candidate.CandidateId, 
									Name=c.Candidate.Name, 
									MatchingSkills=string.Join(",", c.MatchingSkills)
								})
						});

			return View(model);
		}

		//candidates.Select(c => j.Skills.Intersect(c.SkillTags).Any() ? new CandidateMatch {Candidate=c, Score= j.Skills.Intersect(c.SkillTags).Count()} : null)
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
