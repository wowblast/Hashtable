using System;

namespace HashTableProject
{
	class Program
	{
        private static Patient[] tablaCI;
        private static Patient[] colasCI;
        private static Patient[] tablaNombre;
        private static int cantidad = 23;


		static void Main(string[] args)
		{
            tablaCI = new Patient[cantidad];
            colasCI = new Patient[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                tablaCI[i] = null;
            }

            InsertarPacientePorCI("Pepega Pls", 1001, "Internado", "Martes 4/4/2020");
            InsertarPacientePorCI("Pepega Shower", 2566, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorCI("Pepega Driving", 4261, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorCI("Wide Peepo Sad", 3333, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorCI("Wide Peepo Happy", 2118, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorCI("Monka Eyes", 1792, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorCI("Pepe Laugh", 1500, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorCI("Feels Dank Man", 2991, "Internado", "Jueves 2/5/2020");

            MostrarPorCI();

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
        public int FuncionCI(int ci)
        {
            return ci % cantidad;
        }
        public int FuncionName(string name)
        {
            return name.Length % cantidad;
        }
        public void SearchByCI(int ci)
        {
            int i = 0; //Contador de intentos
            int pLlave = ci;
            int indice = 0;
            bool encontrado = false;

            //calculamos el indice
            indice = FuncionCI(pLlave);
            int primerIndice = indice;
            if (tablaCI[indice] == null)
            {
                Console.WriteLine("no se encontro el valor de clave {0}", pLlave);
            }
            else
            {

                BinarySearch(pLlave, 0, getLength(tablaCI[indice]) - 1, tablaCI[indice]); 
            }

        }
       
        public void BinarySearch( int target, int izq, int der,Patient patient)
        {
            int medio;

            medio = (int)Math.Floor(((izq + der) * 1.0 / 2.0));
            if (der - izq > 1)
            {
                int CImedio = getPatient(patient, medio).CI;
                if (CImedio == target)
                {
                    Console.WriteLine("numero encontrado {0} en pos {1}", CImedio, medio);

                }
                else if (CImedio < target)
                {
                    BinarySearch( target, medio + 1, der,patient);
                }
                else if (CImedio > target)
                {
                    BinarySearch( target, izq, medio - 1,patient);
                }
            }
            else
            {
                int CIizq = getPatient(patient, izq).CI;
                int CIder = getPatient(patient, der).CI;
                if (CIizq == target)
                {
                    Console.WriteLine("numero encontrado {0} en pos {1}",CIizq, izq);

                }
                else if (CIder== target)
                {
                    Console.WriteLine("numero encontrado {0} en pos {1}", CIder, der);

                }
                else
                {
                    Console.WriteLine("numero no encontrado");

                }
            }



        }

        public Patient getPatient (Patient patient, int ind)
        {
            int actualInd = 0;
            if (patient == null)
            {
                return null;
            }
            else
            {
                while (actualInd!=ind)
                {                   
                    patient = patient.Next;
                    actualInd++;
                }
                return patient;
            }
        }

        public int getLength(Patient patient)
        {
            int lenght = 0;
            while (patient != null)
            {
                patient = patient.Next;
                lenght++;
            }
            return lenght;
        }

    }
}
