using System;
using System.Collections.Generic;

namespace DesignPatternMotard
{
	
	public class MainApp
	{
		
		public static void Main()
		{
            String answer = "1";
            while (answer == "1")
            {
                
                RoadbookBuilder builder;

                // Creation d'un roadbook avec fabrication d'itineraire
                // Director : Roadbook
                Roadbook roadbook = new Roadbook();

                Console.WriteLine("Veuillez choisir une catégorie parmis la liste suivante et valider avec la touche \"Entrée\"");
                Console.WriteLine(" 1 . Rallye; 2 . Speed; 3 . Serenity   ");
                Console.WriteLine("     ");
                String choice = Console.ReadLine();

                Console.WriteLine("    ");

                // Construit et affiches les itineraires selon la categorie choisie par l'utilisateur

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Roadbook's category : Rallye");
                        builder = new RallyeBuilder();
                        roadbook.Construct(builder);
                        builder.Itinerary.Show();

                        break;
                    case "2":
                        Console.WriteLine("Roadbook's category : Speed");
                        builder = new SpeedBuilder();
                        roadbook.Construct(builder);
                        builder.Itinerary.Show();

                        break;
                    case "3":
                        Console.WriteLine("Roadbook's category : Serenity");
                        builder = new SerenityBuilder();
                        roadbook.Construct(builder);
                        builder.Itinerary.Show();
                        break;
                }
				Console.WriteLine("Voulez vous selectionner un autre roadbook ? saissez votre réponse et valider avec la touche \"Entrée\"");
				Console.WriteLine("     ");
				Console.WriteLine("1. Oui;  2. Non");
                Console.WriteLine("     ");
			    answer = Console.ReadLine();
				
            } if(answer == "2"){
                Console.WriteLine("     ");
                Console.WriteLine(" FIN");
            }

			//Console.WriteLine("Voulez vous selectionner un autre roadbook ? saissez votre réponse et valider avec la touche \"Entrée\"");
			//Console.WriteLine("     ");
			//Console.WriteLine("1. Oui;  2. Non");
			//String answer = Console.ReadLine();
			//if (answer == "1")
			//{

			//}
			Console.ReadKey();
		}
	}

	// Director
    // Classe Roadbook

	class Roadbook
	{
		// Etape de construction
		public void Construct(RoadbookBuilder roadbookBuilder)
		{
            roadbookBuilder.BuildCategory();
			roadbookBuilder.BuildStartPoint();
			roadbookBuilder.BuildEndPoint();
			roadbookBuilder.BuildDistance();
			roadbookBuilder.BuildPeriod();
		}
	}

	/// Constructeur de roadbook
	abstract class RoadbookBuilder
	{
		protected Itinerary itinerary;

		public Itinerary Itinerary
		{
			get { return itinerary; }
		}
        public abstract void BuildCategory();
		public abstract void BuildStartPoint();
		public abstract void BuildEndPoint();
		public abstract void BuildDistance();
		public abstract void BuildPeriod();
	}

	/// Class Rallye 
	
    class RallyeBuilder : RoadbookBuilder
	{
		public RallyeBuilder()
		{
            // type d'itineraire
			itinerary = new Itinerary("racetrak");
		}

        public override void BuildCategory(){

            // mettre le type de route : racetrack
            itinerary["Category"] = "Rallye";
		}
		public override void BuildStartPoint()
		{
			Console.WriteLine("Veuillez saisir un point départ et valider avec la touche \"Entrée\"");
            Console.WriteLine("     ");
			
			itinerary["StartPoint"] = Console.ReadLine();
            Console.WriteLine("     ");
		}

		public override void BuildEndPoint()
		{
			Console.WriteLine("Veuillez saisir un point d'arrivé et valider avec la touche \"Entrée\"");
            Console.WriteLine("     ");
			itinerary["EndPoint"] = Console.ReadLine();
            Console.WriteLine("     ");
		}

		public override void BuildDistance()
		{
			itinerary["Distance"] = "100km";
		}

		public override void BuildPeriod()
		{
			itinerary["Period"] = "1h20";
		}
	}


	
	// classe Speed 
	
    class SpeedBuilder : RoadbookBuilder
	{
		public SpeedBuilder()
		{
			itinerary = new Itinerary("Expressway");
		}

		public override void BuildCategory()
		{

			// mettre le type de route : racetrack
			itinerary["Category"] = "Speed";
		}
		public override void BuildStartPoint()
		{
			Console.WriteLine("Veuillez saisir un point départ et valider avec la touche \"Entrée\"");
			Console.WriteLine("     ");

			itinerary["StartPoint"] = Console.ReadLine();
            Console.WriteLine("     ");
		}

		public override void BuildEndPoint()
		{
			Console.WriteLine("Veuillez saisir un point d'arrivé et valider avec la touche \"Entrée\"");
			Console.WriteLine("     ");
			itinerary["EndPoint"] = Console.ReadLine();
            Console.WriteLine("     ");
		}

		public override void BuildDistance()
		{
			itinerary["Distance"] = "600km";
		}

		public override void BuildPeriod()
		{
			itinerary["Period"] = "8h";
		}
	}


    // Classe Serenity

    class SerenityBuilder : RoadbookBuilder
	{
		public SerenityBuilder()
		{
			itinerary = new Itinerary("Countryside road");
		}

		public override void BuildCategory()
		{

			// mettre le type de route : racetrack
			itinerary["Category"] = "Serenity";
		}
		public override void BuildStartPoint()
		{
			Console.WriteLine("Veuillez saisir un point départ et valider avec la touche \"Entrée\"");
			Console.WriteLine("     ");

			itinerary["StartPoint"] = Console.ReadLine();
            Console.WriteLine("     ");
			
		}

		public override void BuildEndPoint()
		{
			Console.WriteLine("Veuillez saisir un point d'arrivé et valider avec la touche \"Entrée\"");
			Console.WriteLine("     ");
			itinerary["EndPoint"] = Console.ReadLine();
            Console.WriteLine("     ");
		}

		public override void BuildDistance()
		{
			itinerary["Distance"] = "984km";
		}

		public override void BuildPeriod()
		{
            itinerary["Period"] = "13h";
		}
	}

	
	/// Classe produit, itineraire

	class Itinerary
	{
		private string _ItineraryType;
		private Dictionary<string, string> _parts =
		  new Dictionary<string, string>();

		// Constructor
		public Itinerary(string ItineraryType)
		{
			this._ItineraryType = ItineraryType;
		}

		
		public string this[string key]
		{
			get { return _parts[key]; }
			set { _parts[key] = value; }
		}

        public void Show()
		{


			Console.WriteLine("\n---------------------------");
            Console.WriteLine("Caterogy : {0}",_parts["Category"]);
			Console.WriteLine("Itinerary Type: {0}", _ItineraryType);  
			Console.WriteLine(" Start point : {0}", _parts["StartPoint"]);  
			Console.WriteLine(" End point : {0}", _parts["EndPoint"]); 
			Console.WriteLine(" #Distance: {0}", _parts["Distance"]); 
			Console.WriteLine(" #Period : {0}", _parts["Period"]);  
            Console.WriteLine("     ");
            Console.WriteLine("***********");
            Console.WriteLine("     ");


			
            // + Categorie
            // nb itineraire
            // nom du roadbook
		}
	}


}




// Demande de choix pour le type d'itineraire