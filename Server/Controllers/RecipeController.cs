using AiChef.Server.Data;
using AIChef.Client.Shared;
using AIChef.Server.Services;
using AIChef.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIChef.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IOpenAIAPI _openAIService;

        public RecipeController(IOpenAIAPI openAIService)
        {
            _openAIService = openAIService;

        }

        [HttpPost, Route("GetRecipeIdeas")]
        public async Task<ActionResult<List<Idea>>> GetRecipeIdeas(RecipeParms recipeParms)
        {
            string mealtime = recipeParms.MealTime;
            List<string?> ingredients = recipeParms.Ingredients
                                                  .Where(x => string.IsNullOrEmpty(x.Description))
                                                  .Select(x => x.Description)
                                                  .ToList();

            if (string.IsNullOrEmpty(mealtime))
            {
                mealtime = "Breakfast";
            }

            //calls to openAI to get recipe ideas
            //var ideas = await _openAIService.CreateRecipeIdeas(mealtime, ingredients);
            //return ideas;

            //call to sample data
            return SampleData.RecipeIdeas;
        }

        [HttpPost, Route("GetRecipe")]
        public async Task<ActionResult<Recipe?>> GetRecipe(RecipeParms recipeParms)
        {
            //call to sample data
            return SampleData.Recipe;

            //Call to OpenAI
            //List<string> ingredients = recipeParms.Ingredients
            //                                      .Where(x => string.IsNullOrEmpty(x.Description))
            //                                      .Select(x => x.Description)
            //                                      .ToList();

            //string? title = recipeParms.SelectedIdea;
           
            //if (string.IsNullOrEmpty(title))
            //{
            //    return BadRequest();
            //}

            //var recipe = await _openAIService.CreateRecipe(title, ingredients);
            //return recipe;
        }

        [HttpGet, Route("GetRecipeImage")]
        public async Task<RecipeImage> GetRecipeImage(string title)
        {
            //call to sample data
            return SampleData.RecipeImage;

            //Call to OpenAi
            //var recipeImage = await _openAIService.CreateRecipeImage(title);

            //return recipeImage ?? SampleData.RecipeImage;
        }

    }
}