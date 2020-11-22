using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobAdderCodingTest.ServiceClients;

namespace JobAdderCodingTest.Classes
{
	public class JobAdderProfiles: Profile
	{
        public JobAdderProfiles()
        { 
            CreateMap<CandidateResponse, Candidate>()
                    .ForMember(dest => dest.CandidateId, src => src.MapFrom(field => field.candidateId))
                    .ForMember(dest => dest.Name, src => src.MapFrom(field => field.name))
                    .ForMember(dest => dest.SkillTags, src => src.MapFrom(field => ConvertToList(field.skillTags)));
            CreateMap<JobResponse, Job>()
                    .ForMember(dest => dest.JobId, src => src.MapFrom(field => field.jobId))
                    .ForMember(dest => dest.Name, src => src.MapFrom(field => field.name))
                    .ForMember(dest => dest.Company, src => src.MapFrom(field => field.company))
                    .ForMember(dest => dest.Skills, src => src.MapFrom(field => ConvertToList(field.skills)));
        }

        //this has to be a separate named function, 
        //expression tree only supports top-level reflected object properties/methods
        private List<string> ConvertToList(string skillTags)
        {
            return new List<string>(skillTags.Split(','));
        }
    }
}
