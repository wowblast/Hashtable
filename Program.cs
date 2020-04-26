using System;

namespace HashTableProject
{
	class Program
	{
        private static Patient[] tablaCI;
        private static Patient[] colasCI;
        private static Patient[] tablaNombre;
        private static Patient[] colasNombre;
        private static int cantidad = 23;


		static void Main(string[] args)
		{
            /*tablaCI = new Patient[cantidad];
            colasCI = new Patient[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                tablaCI[i] = null;
            }*/
            tablaNombre = new Patient[cantidad];
            colasNombre = new Patient[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                tablaNombre[i] = null;
            }

            InsertarPacientePorNombre("Pepega Pls", 1001, "Internado", "Martes 4/4/2020");
            InsertarPacientePorNombre("Pepega Shower", 2566, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorNombre("Pepega Driving", 4261, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorNombre("Wide Peepo Sad", 3333, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorNombre("Pepe Hands", 2118, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorNombre("Monka Eyes", 1792, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorNombre("Pepe Laugh", 1500, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorNombre("XQC L", 2991, "Internado", "Jueves 2/5/2020");

            MostrarPorNombre();

            Console.ReadLine();
        }

        public static void InsertarPacientePorCI(string nombre, int ci, string tipo, string fecha)
        {
            Patient pat = new Patient(nombre,ci,tipo,fecha, null);
            int hash = ci % cantidad;
            while(tablaCI[hash] != null && tablaCI[hash].CI % cantidad != ci % cantidad)
            {
                hash = (hash + 1) % cantidad;
            }
            if (tablaCI[hash] != null && tablaCI[hash].CI % cantidad == hash)
            {
                pat.Next = tablaCI[hash].Next;
                tablaCI[hash].Next = pat;
                return;
            }
            else
            {
                tablaCI[hash] = pat;
                colasCI[hash] = pat;
                return;
            }
        }
        public static void showPatients(Patient first)
        {
            Patient aux = first;
                
        }
        public static void MostrarPorCI()
        {
            Patient current = null;
            for (int n = 0; n < cantidad; n++)
            {
                current = colasCI[n];
                Console.WriteLine("{0} ", n);
                if (current == null)
                {
                    Console.WriteLine("\t[---, ---, ---, ---]");
                }
                else
                {
                    while (current != null)
                    {
                        Console.WriteLine("\t[{0}, {1}, {2}, {3}]", current.NombreCompleto, current.CI,
                            current.TipoPaciente, current.FechaIngreso);
                        current = current.Next;
                    }
                }              
            }
        }
        public static void InsertarPacientePorNombre(string nombre, int ci, string tipo, string fecha)
        {
            Patient pat = new Patient(nombre, ci, tipo, fecha, null);
            int letras = nombre.Length;
            int hash = letras % cantidad;
            while (tablaNombre[hash] != null && tablaNombre[hash].NombreCompleto.Length % cantidad != nombre.Length % cantidad)
            {
                hash = (hash + 1) % cantidad;
            }
            if (tablaNombre[hash] != null && tablaNombre[hash].NombreCompleto.Length % cantidad == hash)
            {
                pat.Next = tablaNombre[hash].Next;
                tablaNombre[hash].Next = pat;
                return;
            }
            else
            {
                tablaNombre[hash] = pat;
                colasNombre[hash] = pat;
                return;
            }
        }
        public static void MostrarPorNombre()
        {
            Patient current = null;
            for (int n = 0; n < cantidad; n++)
            {
                current = colasNombre[n];
                Console.WriteLine("{0} ", n);
                if (current == null)
                {
                    Console.WriteLine("\t[---, ---, ---, ---]");
                }
                else
                {
                    while (current != null)
                    {
                        Console.WriteLine("\t[{0}, {1}, {2}, {3}]", current.NombreCompleto, current.CI,
                            current.TipoPaciente, current.FechaIngreso);
                        current = current.Next;
                    }
                }
            }
        }
    }
}
