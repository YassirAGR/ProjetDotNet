using System.Collections.ObjectModel;
using MAUI.Reader.Model;

namespace MAUI.Reader.Service
{
    public class LibraryService
    {
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouter et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        public ObservableCollection<Book> Book { get; set; } = new ObservableCollection<Book>() {
            new Book () { Name = "Aventures au-delà des montagnes", Author = "Alexandre Dumas", Description = "Une quête épique à travers des terrains inexplorés.", Cover = "aventures_au_dela_des_montagnes.png", Content = "Dans une époque lointaine, un jeune aventurier armé de courage et d'une carte mystérieuse part à la découverte des secrets cachés derrière les montagnes inexplorées. Sur son chemin, il rencontre des créatures fantastiques, des amis inattendus et des défis qui mettent à l'épreuve son ingéniosité et sa bravoure. Chaque chapitre le rapproche de la légendaire cité perdue, révélant des mystères anciens et des vérités oubliées.", Price = 15 },
            new Book () { Name = "Les mystères de l'océan", Author = "Jules Verne", Description = "Exploration sous-marine pleine de découvertes et de dangers.", Cover = "les_mysteres_de_locean.png", Content = "À bord du sous-marin Nautilus, le capitaine Nemo emmène l'équipage dans les profondeurs insondables de l'océan, où ils découvrent des merveilles et des horreurs au-delà de l'imagination humaine. Des batailles avec des monstres des abysses, la découverte de trésors engloutis et la rencontre avec des civilisations perdues sous les vagues composent cette épopée sous-marine sans pareil.", Price = 12 },
            new Book () { Name = "L'île mystérieuse", Author = "H.G. Wells", Description = "Survie et science-fiction se rencontrent sur une île isolée.", Cover = "lile_mysterieuse.png", Content = "Des naufragés échouent sur une île apparemment déserte, dotée de phénomènes naturels inexplicables et de technologies avancées cachées. Alors qu'ils luttent pour survivre, ils découvrent que l'île cache un secret révolutionnaire qui pourrait changer le cours de l'humanité. Leur quête de survie se transforme en une aventure scientifique épique qui défie les lois de la nature.", Price = 14 },
            new Book () { Name = "Voyage au centre de la Terre", Author = "Jules Verne", Description = "Un voyage extraordinaire vers un monde inconnu sous nos pieds.", Cover = "voyage_au_centre_de_la_terre.png", Content = "Un scientifique audacieux, son neveu courageux et leur guide rusé descendent dans le cratère d'un volcan éteint pour entreprendre le plus grand voyage de l'histoire. À travers des cavernes remplies de créatures préhistoriques et des paysages fantastiques, ils cherchent à atteindre le centre de la Terre. Ce qu'ils trouvent défie leur imagination et les confronte à des merveilles et des dangers au-delà de toute conception.", Price = 16 },
            new Book () { Name = "Les guerriers de l'ombre", Author = "Robert Louis Stevenson", Description = "Une lutte entre le bien et le mal dans un royaume ancien.", Cover = "les_guerriers_de_lombre.png", Content = "Dans un ancien royaume déchiré par la guerre, un groupe de guerriers courageux se lève pour combattre les forces des ténèbres. Armés de pouvoirs mystiques et de leur bravoure, ils affrontent des ennemis redoutables et traversent des terres maudites pour restaurer la paix. Leur voyage est semé d'épreuves qui testent leur force, leur amitié et leur cœur.", Price = 13 },
            new Book () { Name = "Les portes du temps", Author = "Philip K. Dick", Description = "Voyage temporel et paradoxes dans une aventure qui défie la réalité.", Cover = "les_portes_du_temps.png", Content = "Un inventeur génial crée une machine à voyager dans le temps, ouvrant les portes à des aventures à travers les âges. Lui et ses compagnons se retrouvent pris dans des paradoxes temporels, confrontés à des dilemmes moraux et à des ennemis qui existent au-delà du temps. Leur périple révèle les mystères de l'univers et la nature fragile de la réalité elle-même.", Price = 17 },
            new Book () { Name = "Le dernier des Mohicans", Author = "James Fenimore Cooper", Description = "Un récit historique et dramatique dans l'Amérique du 18ème siècle.", Cover = "le_dernier_des_mohicans.png", Content = "Dans les forêts sauvages de l'Amérique du Nord, au milieu des conflits entre colons britanniques et français, un homme blanc élevé par les Mohicans lutte pour protéger les siens et honorer son héritage. Son voyage épique est marqué par l'amour, la trahison et des batailles acharnées, reflétant les tumultes d'une ère où de nouvelles nations étaient en gestation.", Price = 11 },
            new Book () { Name = "La cité perdue", Author = "Arthur Conan Doyle", Description = "Une expédition à la recherche d'une civilisation oubliée.", Cover = "la_cite_perdue.png", Content = "Un groupe d'explorateurs intrépides part à la découverte d'une cité perdue dans la jungle profonde, guidés par d'anciens manuscrits et des récits légendaires. Leur quête les mène à des découvertes incroyables et des dangers mortels, alors qu'ils dévoilent les secrets d'une civilisation disparue et les trésors cachés qu'elle a laissés derrière.", Price = 18 },
            new Book () { Name = "Les archives de l'espace", Author = "Isaac Asimov", Description = "Conflits et découvertes dans l'immensité de l'univers.", Cover = "les_archives_de_lespace.png", Content = "Dans le futur, l'humanité s'est étendue à travers les étoiles, mais avec la colonisation vient le conflit. Un groupe de scientifiques et de soldats embarque dans une mission pour explorer les archives d'une civilisation extraterrestre ancienne, découvrant des technologies qui pourraient mettre fin aux guerres ou les enflammer à une échelle jamais vue.", Price = 19 },
            new Book () { Name = "Le fantôme de l'opéra", Author = "Gaston Leroux", Description = "Amour, mystère et terreur dans l'enceinte d'un opéra parisien.", Cover = "le_fantome_de_lopera.png", Content = "Sous les dorures et les velours de l'Opéra de Paris se cache une figure énigmatique : le Fantôme. Amoureux d'une jeune soprano, il hante les coulisses, orchestrant un drame de passion, de jalousie et de musique sublime. Son histoire tragique se déroule dans l'ombre et la lumière, entre terreur et beauté, dans les entrailles de ce monument de l'art.", Price = 20 }
        };


        // C'est aussi ici que vous ajouterez les requête réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
        // Faite bien attention a ce que votre requête réseau ne bloque pas l'interface 
        public LibraryService()
        {
           
            WPF.Reader.OpenApi.Library libraryApi = new WPF.Reader.OpenApi.Library(new HttpClient());
                                    
        }
    }
}
