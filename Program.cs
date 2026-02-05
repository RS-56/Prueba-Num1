using System;

namespace U7P1
{
    class Program
    {
        //Estructura simple para guardar una calificación
        struct Calificacion
        {
            public int Valor;
        }

        //Arreglo de calificaciones
        static Calificacion[] cali = new Calificacion[20];

        //Arreglo HASH (30 espacios)
        static Calificacion[] hash = new Calificacion[30];

        //Metodo mitad al cuadrado
        public static int CuadradoM(int valor, int tamaño)
        {
            long cuadrado = (long)valor * valor;
            string cad = cuadrado.ToString();
            int len = cad.Length;

            int inicio = len / 2 - 1;
            if (inicio < 0) inicio = 0;

            int cantidad = (len >= 2) ? 2 : 1;

            string mitad = cad.Substring(inicio, cantidad);
            int numeroMitad = int.Parse(mitad);

            return numeroMitad % tamaño;
        }

        //Procedimiento direcciones
        public static void Direcciones()
        {
            int D;

            for (int i = 0; i < cali.Length; i++)
            {
                int valor = cali[i].Valor;

                D = CuadradoM(valor, hash.Length);

                //sondeo lineal
                while (hash[D].Valor != 0)
                {
                    D = (D + 1) % hash.Length;
                }

                hash[D].Valor = valor;
            }
        }

        //Procedimiento busqueda
        public static void Busqueda()
        {
            Console.Write("\nDe la calificación a buscar: ");
            int key = int.Parse(Console.ReadLine());

            int D = CuadradoM(key, hash.Length);
            int inicio = D;

            if (hash[D].Valor == key)
            {
                Console.WriteLine($"\nLa calificación {key} se encuentra en la posición {D}");
                return;
            }

            D = (D + 1) % hash.Length;

            while (D != inicio && hash[D].Valor != 0 && hash[D].Valor != key)
            {
                D = (D + 1) % hash.Length;
            }

            if (hash[D].Valor == key)
            {
                Console.WriteLine($"\nLa calificación {key} se encuentra en la posición {D}");
            }
            else
            {
                Console.WriteLine($"\nLa calificación {key} NO se encuentra en el arreglo HASH.");
            }
        }

        //Main
        static void Main(string[] args)
        {
            string linea = new string('=', 60);

            Console.Clear();
            Console.WriteLine(linea);
            Console.WriteLine("\t  Metodo de HASH por mitad al cuadrado");
            Console.WriteLine(linea);

            Console.WriteLine("\nCaptura de las 20 calificaciones\n");

            //Captura de las calificaciones
            for (int i = 0; i < cali.Length; i++)
            {
                Console.Write($"Ingrese la calificación {i + 1}: ");
                cali[i].Valor = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(linea);
            Console.WriteLine("\nCalificaciones capturadas correctamente.");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

            //Llamada al metodo direcciones
            Direcciones();

            Console.Clear();
            Console.WriteLine(linea);
            Console.WriteLine("\tTabla final hash (Original y ordenada)");
            Console.WriteLine(linea);
            Console.WriteLine("\t        Pos | Captura | HASH");
            Console.WriteLine(linea);

            //Mostrar la tabla
            for (int i = 0; i < hash.Length; i++)
            {
                string original = (i < cali.Length) ? cali[i].Valor.ToString() : "Vacio";
                string almacenado = (hash[i].Valor == 0) ? "Vacío" : hash[i].Valor.ToString();

                Console.WriteLine($"\t        {i,3} | {original,7} | {almacenado}");
            }

            Console.WriteLine(linea);

            //Pregunta al usuario si quiere buscar mas
            string opcion;
            do
            {
                Busqueda();

                Console.Write("\n¿Desea buscar otra calificación? (S/N): ");
                opcion = Console.ReadLine().ToUpper();

            } while (opcion == "S");

            Console.WriteLine("\nGracias por usar el programa :DD");
            Console.ReadKey();
        }
    }
}
