using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Metodo para calcular el numero de letras 
            //Console.Write("Introduce un número: ");
            //int numero = int.Parse(Console.ReadLine());
            //IEnumerable<int> digitos = SepararDigitos(numero);
            //Numeros(digitos);
            //FIN 
            A a = new A();
            Console.WriteLine(a.MetodoA());
            Console.WriteLine(a.MetodoB());

            B b = new B();
            Console.WriteLine(b.MetodoA());
            //Console.WriteLine(b.MetodoB());

            //Productos();
            Console.ReadLine();
        }
        
        //Metodo Para encontrar los numero comunes
        public static void Comun()
        {
            string[] list1 = { "A", "B", "C", "D", "E", "F" };
            string[] list2 = { "B", "E", "G", "H", "I", "J" };
            List<string> list3 = new List<string>();


            for (int i = 0; i < list1.Length; i++)
            {
                for (int j = 0; j < list2.Length; j++)
                {
                    if (list1[i] == list2[j])
                    {
                        list3.Add(list1[i]);
                    }

                }
            }
            Console.WriteLine("Coincidencias");

            for (int i = 0; i < list3.Count; i++)
            {
                Console.WriteLine(list3[i]);
            }
        }

        //Metodo para ceparar una cifera entera por cada digito que lo conforma
        public static IEnumerable<int> SepararDigitos(int numero)
        {
            List<int> digitos = new List<int>();
            while (numero > 0)
            {
                digitos.Add(numero % 10);
                numero = numero / 10;
            }
            digitos.Reverse();
            return digitos;
        }
        //Metodo para calcular Reel numero de letras que la conforma 
        public static void Numeros(IEnumerable<int> numero)
        {
            List<Tuple<int, int>> numeros = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(4, 0),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(3, 2),
                new Tuple<int, int>(4, 3),
                new Tuple<int, int>(6, 4),
                new Tuple<int, int>(5, 5),
                new Tuple<int, int>(4, 6),
                new Tuple<int, int>(5, 7),
                new Tuple<int, int>(4, 8),
                new Tuple<int, int>(5, 9),
            };

            int totalLetras = 0;
            foreach (int digito in numero)
            {
                foreach (var tupla in numeros)
                {
                    if (tupla.Item2 == digito)
                    {
                        totalLetras += tupla.Item1;
                        
                    }
                }
            }
            Console.WriteLine($"Total de letras: {totalLetras}");
        }

        //Metodo del palindromo
        public static void Palindromo()
        {
            Console.Write("Introduce una palabra o frase: ");
            string frase = Console.ReadLine();

            // Eliminar espacios
            frase = frase.Replace(" ", string.Empty);

            // Convertir a minúsculas
            frase = frase.ToLower();

            // Invertir la frase
            char[] fraseInvertida = frase.ToCharArray();
            Array.Reverse(fraseInvertida);

            // Comparar la frase con su versión invertida
            if (frase == new string(fraseInvertida))
            {
                Console.WriteLine("La frase es un palíndromo.");
            }
            else
            {
                Console.WriteLine("La frase no es un palíndromo.");
            }
        }
        //Metodo para recorrer del 1 al 100 para obtener los nbuemros pares y divisibles 
        public static void RecorridoNumeros()
        {
            List<int> pares = new List<int>();
            List<int> divisiblesPorTres = new List<int>();

            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                {
                    pares.Add(i);
                }

                if (i % 3 == 0)
                {
                    divisiblesPorTres.Add(i);
                }
            }

            Console.WriteLine("Los números pares son: " + string.Join(", ", pares));
            Console.WriteLine("Los números divisibles entre 3 son: " + string.Join(", ", divisiblesPorTres));
        }
        //Metodo para ingresar productos y obtener el de mayor y menor precio
        public static void Productos()
        {
            string agregar = null;
            List<decimal> precios = new List<decimal>();

            do
            {
                Console.Write("Introduce el precio del producto");
                decimal precio = decimal.Parse(Console.ReadLine());
                precios.Add(precio);
                Console.WriteLine("Desea agregar otro producto si/no");
                agregar = Console.ReadLine();
            } while (agregar == "si");

            decimal maxPrecio = precios[0];
            decimal minPrecio = precios[0];
            int maxIndex = 0;
            int minIndex = 0;

            
            for (int i = 1; i < precios.Count; i++)
            {
                if (precios[i] > maxPrecio)
                {
                    maxPrecio = precios[i];
                    maxIndex = i;
                }

                if (precios[i] < minPrecio)
                {
                    minPrecio = precios[i];
                    minIndex = i;
                }
            }

            Console.WriteLine("El producto de mayor precio es el " + (maxIndex + 1) + " $" + maxPrecio);
            Console.WriteLine("El producto de menor precio es el " + (minIndex + 1) + " $" + minPrecio);
        }
    }

    // Definir la interfaz IA
    public interface IA
    {
        string MetodoA();
        string MetodoB();
    }

    // Definir la clase B que implementa la interfaz IA
    public class B : IA
    {
        public virtual string MetodoA()
        {
            return "Hola clase: B método: A";
        }

        public string MetodoB()
        {
            return "Hola clase: B método: B";
        }
    }

    // Definir la clase A que hereda de la clase B
    public class A : B
    {
        public override string MetodoA()
        {
            return "Hola clase: A método: A - Termine mi prueba";
        }
    }

}
