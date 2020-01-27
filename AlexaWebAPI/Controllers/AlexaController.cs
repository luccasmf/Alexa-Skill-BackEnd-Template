using AlexaWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlexaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlexaController : ControllerBase
    {
        [HttpPost("myskill")]
        public AlexaResponse MyCompanySkill(AlexaRequest request)
        {
            AlexaResponse response = null;

            switch (request.Request.Intent.Name)
            {
                case "HelloIntent":
                    response = HelloIntentHandler();
                    break;
                case "FavoriteBandIntent":
                    response = FavoriteBandIntentHandler();
                    break;
                case "EndIntent":
                case "AMAZON.CancelIntent":
                case "AMAZON.StopIntent":
                    response = EndIntentHandler();
                    break;
            }

            return response;
        }

        private AlexaResponse FavoriteBandIntentHandler()
        {
            var favoriteBand = "Linkin Park.";

            var response = new AlexaResponse("Sua banda favorita é " + favoriteBand);
            response.Response.ShouldEndSession = false;
            return response;
        }

        private AlexaResponse HelloIntentHandler()
        {
            var response = new AlexaResponse("Olar.");
            response.Response.Reprompt.OutputSpeech.Text =
                "You can tell me to say hello, what is my favorite band, or cancel to exit.";
            response.Response.ShouldEndSession = false;
            return response;
        }

        private AlexaResponse EndIntentHandler()
        {
            var response = new AlexaResponse("Espero ter ajudado, até logo.");
            response.Response.ShouldEndSession = true;
            return response;
        }
    }
}