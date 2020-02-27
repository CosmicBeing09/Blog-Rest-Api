using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Blog_Rest_Api.Custom_Attribute;
using Blog_Rest_Api.DTOModels;
using Blog_Rest_Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Rest_Api.Controllers{

    [Route("/v1/[controller]")]
    
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public class StoriesController : BaseController
    {
        private readonly IStoriesService storiesService;

        public StoriesController(IStoriesService storiesService)
        {
            this.storiesService = storiesService;
        }

        [HttpPost("story")]
        [ValidateModel]
        // [Consumes("application/json", new string[]{"application/xml"})]
        public async Task<IActionResult> CreateStory([FromBody]StoryDTO storyDTO){
            return Ok(await storiesService.CreateStoryAsync(storyDTO));
        }

        [HttpGet("stories")]
        [AllowAnonymous]
        [ValidateModel]
        // [Consumes("application/json", new string[]{"application/xml"})]
        public async Task<IActionResult> GetStories(){
            return Ok(await storiesService.GetStoryAsync());
        }

        [HttpGet("story/{storyId}")]
        [AllowAnonymous]
        [ValidateModel]
        // [Consumes("application/json", new string[]{"application/xml"})]
        public async Task<IActionResult> GetStory([Required]Guid storyId){
            return Ok(await storiesService.GetStoryAsync(storyId)); 
        }

        [HttpPut("story")]
        [ValidateModel]
        public async Task<IActionResult> UpdateStory([FromBody]StoryDTO storyDTO){
            return Ok(await storiesService.ReplaceStoryAsync(storyDTO));
        }

        [HttpDelete("story/{storyId}")]
        [ValidateModel]
        // [Consumes("application/json", new string[]{"application/xml"})]
        public async Task<IActionResult> RemoveStory([Required]Guid storyId){
            return Ok(await storiesService.RemoveStoryAsync(storyId)); 
        }
        
    }
}