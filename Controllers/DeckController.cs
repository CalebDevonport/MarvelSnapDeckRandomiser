using MarvelSnapDeckRandomiser.Models;
using MarvelSnapDeckRandomiser.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MarvelSnapDeckRandomiser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        private const string FilePath = "C:\\Users\\caleb\\AppData\\LocalLow\\Second Dinner\\SNAP\\Standalone\\States\\nvprod\\CollectionState.json";
        private const string UrlPrefix = "https://game-assets.snap.fan/card_variant_images/";
        private const string UrlPostfix = ".webp";

        private readonly ILogger<DeckController> _logger;
        private readonly IUrlService _urlService;

        public DeckController(ILogger<DeckController> logger, IUrlService urlService)
        {
            _logger = logger;
            _urlService = urlService;
        }

        [HttpGet]
        public DisplayCard[] Get()
        {
            var cards = GetCards();
            var cardUrlDict = _urlService.GetCardUrlDict();

            var cardNumList = GenerateRandomArray(cards.Count - 1);
            var returnList = cardNumList.Select(cnl => {
                var cardName = cards[cnl];
                return new DisplayCard
                {

                    CardName = cardName,
                    PicUrl =  $"{UrlPrefix}{cardUrlDict[cardName]}{UrlPostfix}",
                };
            }).ToArray();
            return returnList;
            //var cardName = cards[rndInt].CardDefId;
            //var cardUrl = cardUrlDict[cardName];
            //return new Deck
            //{
            //    Name = cardName,
            //    Energy = 1,
            //    Power = 0,
            //    PicUrl = $"{UrlPrefix}{cardUrl}{UrlPostfix}",
            //};
        }

        private List<string> GetCards()
        {
            Collection collection = null;
            using (StreamReader r = new StreamReader(FilePath))
            {
                string json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<Collection>(json);
            }
            return collection.ServerState.Cards.ToList().Select(c => c.CardDefId).Distinct().OrderBy(x => x).ToList();
        }

        private List<int> GenerateRandomArray(int numOfCards)
        {
            Random random = new Random();
            var randomList = new List<int>();

            while(randomList.Count < 12)
            {
                var randomInt = random.Next(numOfCards);
                if (!randomList.Contains(randomInt))
                {
                    randomList.Add(randomInt);
                }
            }
            return randomList.OrderBy(x => x).ToList();
        }
    }
}
