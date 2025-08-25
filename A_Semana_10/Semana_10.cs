public class vacunas
{
    public static void run()
    {
        var random = new System.Random();

        // Conjunto de todos los ciudadanos (500)
        var todosCiudadanos = new System.Collections.Generic.HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            todosCiudadanos.Add("Ciudadano " + i);
        }

        // Conjunto Pfizer (75 ciudadanos)
        var vacunadosPfizer = new System.Collections.Generic.HashSet<string>();
        while (vacunadosPfizer.Count < 75)
        {
            vacunadosPfizer.Add("Ciudadano " + random.Next(1, 501));
        }

        // Conjunto AstraZeneca (75 ciudadanos)
        var vacunadosAstra = new System.Collections.Generic.HashSet<string>();
        while (vacunadosAstra.Count < 75)
        {
            vacunadosAstra.Add("Ciudadano " + random.Next(1, 501));
        }

        // Ciudadanos no vacunados = todos - pfizer - astrazeneca
        var noVacunados = new System.Collections.Generic.HashSet<string>(todosCiudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstra);

        // Ciudadanos con ambas dosis = intersección de pfizer y astrazeneca
        var ambasVacunas = new System.Collections.Generic.HashSet<string>(vacunadosPfizer);
        ambasVacunas.IntersectWith(vacunadosAstra);

        // Solo Pfizer = pfizer - astrazeneca
        var soloPfizer = new System.Collections.Generic.HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstra);

        // Solo AstraZeneca = astrazeneca - pfizer
        var soloAstra = new System.Collections.Generic.HashSet<string>(vacunadosAstra);
        soloAstra.ExceptWith(vacunadosPfizer);

        // Resultados
        System.Console.WriteLine("Total ciudadanos: " + todosCiudadanos.Count);
        System.Console.WriteLine("Vacunados solo Pfizer: " + soloPfizer.Count);
        System.Console.WriteLine("Vacunados solo AstraZeneca: " + soloAstra.Count);
        System.Console.WriteLine("Vacunados con ambas vacunas: " + ambasVacunas.Count);
        System.Console.WriteLine("No vacunados: " + noVacunados.Count);

        // Ejemplo de listado
        System.Console.WriteLine("\nLista de no vacunados (primeros 10):");
        int contador = 0;
        foreach (var item in noVacunados)
        {
            if (contador++ >= 10) break;
            System.Console.WriteLine(item);
        }
    }

    public static void Main(string[] args)
    {
        run();
    }
}
