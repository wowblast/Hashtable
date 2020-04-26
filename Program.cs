using System;
using System.Diagnostics;

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

           // SearchByCI(17);


            Console.ReadLine();

           

        }

        public static void RunSystem()
        {
            bool isON = true;
            while (isON)
            {
                Console.WriteLine("---SISTEMA MEDICO---");
                Console.WriteLine("Ingrese la opción que desea");
                Console.WriteLine("1.- Añadir paciente");
                Console.WriteLine("2.- Buscar paciente");
                Console.WriteLine("3.- Eliminar paciente");
                Console.WriteLine("4.- Imprimir ");
                Console.WriteLine("5.- Salir");
                int opcion = int.Parse(Console.ReadLine());
                switch(opcion)
                {
                    case 1:
                        Console.WriteLine("Ingresar Nombre Completo ");
                        string nuevoNombre = Console.ReadLine();
                        Console.WriteLine("Ingresar CI ");
                        int nuevoCi = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese Tipo   ");
                        Console.WriteLine("1.- Ambulatorio ");
                        Console.WriteLine("2.- Internado ");
                        int numtipo = int.Parse(Console.ReadLine());
                        string tipo = "";
                        if(numtipo == 1)
                        {
                            tipo = "Ambulatorio";
                        }
                        else
                        {
                            tipo = "Internado";
                        }                         
                        Console.WriteLine("Ingresar Fecha ");
                        string fecha = Console.ReadLine();


                        InsertarPacientePorCI(nuevoNombre, nuevoCi, tipo, fecha);
                        InsertarPacientePorNombre(nuevoNombre, nuevoCi, tipo, fecha);
                        break;
                    case 2:
                        Console.WriteLine("Seleccione el metodo de busqueda");
                        Console.WriteLine("1.- Buscar por CI");
                        Console.WriteLine("2.- Buscar por Nombre completo");
                        int tipoBusqueda = int.Parse(Console.ReadLine());
                        int newCI;
                        Stopwatch sw = new Stopwatch();
                        switch (tipoBusqueda)
                        {
                            case 1:
                                Console.WriteLine("Ingrese CI a buscar");
                                 newCI = int.Parse(Console.ReadLine());
                                sw.Start();
                                BuscarPorCI(newCI);
                                sw.Stop();
                                Console.WriteLine(" tomó {0:N0}", sw.ElapsedTicks);
                                sw.Reset(); break;
                            case 2:
                                Console.WriteLine("Ingrese Nombre completo a buscar");
                                 string nombreCompleto =Console.ReadLine();
                                sw.Start();
                                BuscarporNombreCompleto(nombreCompleto);
                                sw.Stop();
                                Console.WriteLine(" tomó {0:N0}", sw.ElapsedTicks);
                                sw.Reset(); break;
                                break;
                            default:
                                break;
                        }

                        break;
                    case 3:
                        Console.WriteLine("Ingresar Nombre Completo ");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingresar CI ");
                        int ci = int.Parse(Console.ReadLine());
                        /// borrar en ambas tablas
                        /// 
                        ///
                        break;
                    case 4:
                        /// PONER imprimir 
                        Console.WriteLine("Lista con clave CI");
                        ///metodo
                        Console.WriteLine("Lista con clave NOmbre completo");
                        //metodo

                        break;
                    
                    default:
                        isON = false;
                        break;
                }


            }

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
        public static int FuncionCI(int ci)
        {
            return ci % cantidad;
        }
        public static int FuncionName(string name)
        {
            return name.Length % cantidad;
        }
        public static void BusquedaSecuencial(string key,Patient p)
        {
            Patient keyPatien = getPatient(p, 0);

            int actualInd = 0;
            int tamaño = getLength(p);
            bool IsPatient = false;
            while (actualInd < tamaño && !IsPatient)
            {
                Patient newPatient = getPatient(p,actualInd);
                if (newPatient.NombreCompleto  == key)
                {
                    Console.WriteLine("\t Paciente encontrado en  {0} : [{1}, {2}, {3}, {4}]",actualInd, newPatient.NombreCompleto, newPatient.CI,
                           newPatient.TipoPaciente, newPatient.FechaIngreso);
                    IsPatient = true;
                }
                actualInd++;
            }
            if(!IsPatient )
            {
                Console.WriteLine("no se encontro el paciente");
            }
        }
        public static void BuscarporNombreCompleto(string name)
        {
            int indice = FuncionName(name);
            BusquedaSecuencial(name, tablaNombre[indice]);

        }
        public static void BuscarPorCI(int ci)
        {
           int indice = FuncionCI(ci);                     
           BusquedaBinaria(ci, 0, getLength(tablaCI[indice]) -1, tablaCI[indice]);            

        }
       
        public static void BusquedaBinaria( int target, int izq, int der,Patient patient)
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
                    BusquedaBinaria( target, medio + 1, der,patient);
                }
                else if (CImedio > target)
                {
                    BusquedaBinaria( target, izq, medio - 1,patient);
                }
            }
            else
            {
                Patient CIizq = getPatient(patient, izq);
                Patient CIder = getPatient(patient, der);
                if (CIizq.CI == target)
                {
                    Console.WriteLine("numero encontrado {0} en pos {1}",CIizq, izq);
                    Console.WriteLine("\t Paciente encontrado en  {0} : [{1}, {2}, {3}, {4}]", izq, CIizq.NombreCompleto, CIizq.CI,
                           CIizq.TipoPaciente, CIizq.FechaIngreso);
                }
                else if (CIder.CI== target)
                {
                    Console.WriteLine("numero encontrado {0} en pos {1}", CIder, der);
                    Console.WriteLine("\t Paciente encontrado en  {0} : [{1}, {2}, {3}, {4}]", der, CIder.NombreCompleto, CIder.CI,
                           CIder.TipoPaciente, CIder.FechaIngreso);

                }
                else
                {
                    Console.WriteLine("Paciente no encontrado");

                }
            }



        }

        public static Patient getPatient (Patient Newpatient, int ind)
        {
            int actualInd = 0;
            Patient patient = Newpatient;
            if (patient == null)
            {
                return null;
            }
            else
            {
                while (actualInd < ind)
                {                   
                    patient = patient.Next;
                    actualInd++;
                    
                }
                return patient;
            }
        }

        public static int getLength(Patient patient)
        {
            int lenght = 0;
            while (patient != null)
            {
                patient = patient.Next;
                lenght++;
            }
            return lenght;
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
