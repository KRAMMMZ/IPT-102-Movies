using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BSIT3L_Movies.Models;
using System.Collections.Generic;

namespace BSIT3L_Movies.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly List<MovieViewModel> _movies;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _movies = new List<MovieViewModel>
        {
            new MovieViewModel { Id = 1, Name = "Titanic", Rating = "5", ReleaseYear = 1997, Genre = "Romance/Drama", logo="~/IMAGES/titanic.jfif", link ="https://myflixerz.to/watch-movie/titanic-19586.5297602"  ,details ="It stars Kate Winslet and Leonardo DiCaprio. The two play characters who are of different social classes. They fall in love after meeting aboard the ship, but it was not good for a rich girl to fall in love with a poor boy in 1912."},
            new MovieViewModel { Id = 2, Name = "Inception", Rating = "5", ReleaseYear = 2010, Genre = "Science Fiction/Thriller",  logo="~/IMAGES/inception.jfif", link ="https://myflixerz.to/watch-movie/inception-19764.5297266",details="A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster."  },
            new MovieViewModel { Id = 3, Name = "The Shawshank Redemption", Rating = "5", ReleaseYear = 1994, Genre = "Drama",  logo="~/IMAGES/shawshank.jfif",link ="https://myflixerz.to/watch-movie/the-shawshank-redemption-19679.5349142" ,details="Andy Dufresne (Tim Robbins) is convicted for the murder of his wife and her lover and sent to prison. It's 1949, and Andy doesn't have the stuff for prison life. Andy befriends \"Red\" Redding (Morgan Freeman) and uses his past as a banker to get a job in the prison library." },
            new MovieViewModel { Id = 4, Name = "How To Train Your Dragon 1", Rating = "5", ReleaseYear = 2010, Genre = "Fantasy" ,  logo="~/IMAGES/HTYD1.jpg",link ="https://myflixerz.to/watch-movie/how-to-train-your-dragon-19703.5349049" ,details="A hapless young Viking who aspires to hunt dragons becomes the unlikely friend of a young dragon himself, and learns there may be more to the creatures than he assumed."},
            new MovieViewModel { Id = 5, Name = "How To Train Your Dragon 2", Rating = "5", ReleaseYear = 2014, Genre = "Fantasy" ,logo="~/IMAGES/HTYD2.jpg",link ="https://myflixerz.to/watch-movie/how-to-train-your-dragon-2-19749.5297359" ,details="When Hiccup and Toothless discover an ice cave that is home to hundreds of new wild dragons and the mysterious Dragon Rider, the two friends find themselves at the center of a battle to protect the peace." },
            new MovieViewModel { Id = 6, Name = "How To Train Your Dragon 3", Rating = "5", ReleaseYear = 2019, Genre = "Fantasy", logo="~/IMAGES/HTYD3.jpg", link ="https://myflixerz.to/watch-movie/how-to-train-your-dragon-homecoming-58767.5404669",details="The film follows Hiccup as he seeks a dragon utopia known as the \"Hidden World\" while coming to terms with Toothless' new bond with a female Fury, as they deal with the threat of a ruthless dragon hunter named Grimmel the Grisly."  },
            new MovieViewModel { Id = 7, Name = "Kung Fu Panda 1", Rating = "5", ReleaseYear = 2008, Genre = "Martial Arts" , logo="~/IMAGES/KUNGFU1.jpg", link ="https://myflixerz.to/watch-movie/kung-fu-panda-19331.5298022" ,details ="This movie follows the story of Po (voice of Jack Black), a Panda who works in his father's noodle shop, but dreams of becoming a Kung Fu champion. When Po learns that the village is hosting a tournament to nominate a Dragon Warrior, he makes his way to the Jade Palace to watch the festivities" },
            new MovieViewModel { Id = 8, Name = "Kung Fu Panda 2", Rating = "5", ReleaseYear = 2011, Genre = "Martial Arts"  , logo="~/IMAGES/KUNGFU2.jpg",link ="https://myflixerz.to/watch-movie/kung-fu-panda-2-19107.5298442" ,details ="In the film, Po and his allies (Tigress, Monkey, Viper, Crane, and Mantis) travel to Gongmen City to stop the evil peacock Lord Shen from conquering China, while also rediscovering Po's forgotten past. The film was released in theaters on May 26."},
            new MovieViewModel { Id = 9, Name = "Kung Fu Panda 3", Rating = "5", ReleaseYear = 2016, Genre = "Martial Arts" , logo="~/IMAGES/KUNGFU3.jpg", link = "https://myflixerz.to/watch-movie/kung-fu-panda-3-18639.5299324",details ="In the film, Po is reunited with his birth father and discovers the existence of a secret Panda Village, but must soon learn to master chi and prepare the pandas to fight against Kai, a spirit warrior intent on destroying Oogway's legacy" },
            new MovieViewModel { Id = 10, Name = "I am Legend", Rating = "5", ReleaseYear = 2008, Genre = "Post-Apocalyptic", logo="~/IMAGES/legend.jpg", link = "https://myflixerz.to/watch-movie/i-am-legend-18463.5349973",details ="Robert Neville (Will Smith), a brilliant scientist, is a survivor of a man-made plague that transforms humans into bloodthirsty mutants. He wanders alone through New York City, calling out for other possible survivors, and works on finding a cure for the plague using his own immune blood." },
            new MovieViewModel { Id = 11, Name = "The Avengers", Rating = "5", ReleaseYear = 2012, Genre = "Science-Fiction" , logo="~/IMAGES/avengers1.jpg", link= "https://myflixerz.to/watch-movie/the-avengers-19782.5297293",details ="THE AVENGERS, when the powerful villain Loki (Tom Hiddleston) appears on Earth in search of the Tesseract, a mysterious artifact that holds limitless energy, Nick Fury (Samuel L. Jackson), the head of the secret organization S.H.I.E.L.D., realizes it's going to take some equally powerful heroes to save the planet"},
            new MovieViewModel { Id = 12, Name = "Avengers : Age Of Ultron", Rating = "5", ReleaseYear = 2015, Genre = "Science-Fiction" , logo="~/IMAGES/avengersUltron.jpg",link ="https://myflixerz.to/watch-movie/avengers-age-of-ultron-19729.5349028" ,details="In AVENGERS: AGE OF ULTRON, genius inventor Tony Stark, aka Iron Man (Robert Downey Jr.), inadvertently creates a form of artificial intelligence that comes to the conclusion that the world's problems are all self-inflicted." },
            new MovieViewModel { Id = 13, Name = "Avengers : Infinity War", Rating = "5", ReleaseYear = 2018, Genre = "Science-Fiction", logo="~/IMAGES/avengers3.jpg", link = "https://myflixerz.to/watch-movie/avengers-infinity-war-19851.5297131",details = "In the film, the Avengers and the Guardians of the Galaxy attempt to prevent Thanos from collecting the six all-powerful Infinity Stones as part of his quest to kill half of all life in the universe." },
            new MovieViewModel { Id = 14, Name = " Avengers : Endgame", Rating = "5", ReleaseYear = 2019, Genre = "Science-Fiction" , logo="~/IMAGES/avengers4.jpeg", link = "https://myflixerz.to/watch-movie/avengers-endgame-19722.5376856",details ="AVENGERS: ENDGAME is set after Thanos' catastrophic use of the Infinity Stones randomly wiped out half of Earth's population in Avengers: Infinity War. Those left behind are desperate to do something -- anything -- to bring back their lost loved ones."},
            new MovieViewModel { Id = 15, Name = "Spider Man : No Way Home", Rating = "5", ReleaseYear = 2021, Genre = "Science-Fiction" , logo="~/IMAGES/spder.jfif", link ="https://myflixerz.to/watch-movie/spider-man-no-way-home-71326.5601538",details ="Peter Parker's secret identity is revealed to the entire world. Desperate for help, Peter turns to Doctor Strange to make the world forget that he is Spider-Man. The spell goes horribly wrong and shatters the multiverse, bringing in monstrous villains that could destroy the world." },

        };
    }

    public IActionResult Index()
    {
        return View(_movies);
    }

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

