using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ArrayTransforms.Controllers
{
    
    [ApiController]
    public class ActvitiesController : ControllerBase
    {
        private readonly IEnumerable<Activity> _activities;
        private readonly IWebHostEnvironment _hostingEnvironment;

        /// <summary>
        /// Inject the activites config item and hosting environment 
        /// </summary>
        /// <param name="activitiesOptions">Activites options</param>
        /// <param name="hostingEnvironment">To get the current environment name</param>
        public ActvitiesController(IOptions<List<Activity>> activitiesOptions, IWebHostEnvironment hostingEnvironment)
        {
            _activities = activitiesOptions.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("api/Activities")]
        public dynamic GetAcitivities()
        {
            return new             {
                _hostingEnvironment.EnvironmentName,
                Activities = _activities
            };
        }
    }
}
