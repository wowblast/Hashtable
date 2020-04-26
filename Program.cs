using System;
using System.Diagnostics;

namespace HashTableProject
{
    class Program
	{
        private static Patient[] tablaCI;
        private static Patient[] tablaNombre;
        private static int cantidad = 23;
        private static string delName;
        private static int delCI;

		static void Main(string[] args)
		{
            tablaCI = new Patient[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                tablaCI[i] = null;
            }
            tablaNombre = new Patient[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                tablaNombre[i] = null;
            }


            for (int ind = 1; ind < 50; ind++)
            {
                InsertarPacientePorCI("test " + ind, 100 * ind, "Internado", "Martes 4/4/2020");
                InsertarPacientePorNombre("test " + ind, 100 * ind, "Internado", "Martes 4/4/2020");
            }

            RunSystem();
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
                                sw.Reset();
                                sw.Start();
                                BuscarPorCI(newCI);
                                sw.Stop();
                                Console.WriteLine(" tomó {0:N0}", sw.ElapsedTicks);
                                sw.Reset();
                               
                                break;
                            case 2:
                                Console.WriteLine("Ingrese Nombre completo a buscar");
                                 string nombreCompleto =Console.ReadLine();
                                sw.Start();
                                BuscarporNombreCompleto(nombreCompleto);
                                sw.Stop();
                                Console.WriteLine(" tomó {0:N0}", sw.ElapsedTicks);
                                sw.Reset();
                                sw.Start();
                                BuscarporNombreCompleto(nombreCompleto);
                                sw.Stop();
                                Console.WriteLine(" tomó {0:N0}", sw.ElapsedTicks);
                                sw.Reset();
                               
                                break;
                            default:
                                break;
                        }

                        break;
                    case 3:
                        Console.WriteLine("Método de eliminación");
                        Console.WriteLine("1.- Eliminar por CI");
                        Console.WriteLine("2.- Eliminar por Nombre completo");
                        int tipoEliminación = int.Parse(Console.ReadLine());
                        switch (tipoEliminación)
                        {
                            case 1:                                
                                Console.WriteLine("Ingresar CI ");
                                int ci = int.Parse(Console.ReadLine());
                                BuscarPorCI(ci);
                                EliminarPacientePorCI(delCI);
                                EliminarPacientePorNombre(delName);
                                break;
                            case 2:
                                Console.WriteLine("Ingresar Nombre Completo ");
                                string nombre = Console.ReadLine();
                                BuscarporNombreCompleto(nombre);
                                EliminarPacientePorCI(delCI);
                                EliminarPacientePorNombre(delName);
                                break;
                        }             
                        break;
                    case 4:
                        /// PONER imprimir 
                        Console.WriteLine("Lista con clave CI");
                        ///metodo
                        MostrarPorCI();
                        Console.WriteLine("Lista con clave NOmbre completo");
                        //metodo
                        MostrarPorNombre();
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
                Patient cola = getLastPatient(tablaCI[hash]);

                quickSort(tablaCI[hash], cola);
                return;
            }
            else
            {
                tablaCI[hash] = pat;
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
                current = tablaCI[n];
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
        public static void BusquedaSecuencial(string key,Patient p,int indice)
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
                    Console.WriteLine("\t Paciente encontrado en  posicion de lista  {5} ,posicion de lista enlazada {0} : [{1}, {2}, {3}, {4}]", actualInd, newPatient.NombreCompleto, newPatient.CI,
                                                      newPatient.TipoPaciente, newPatient.FechaIngreso, indice);

                    delCI = newPatient.CI;
                    delName = newPatient.NombreCompleto;
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
            if (tablaNombre[indice] == null)
            {
                Console.WriteLine("Paciente no encontrado");
            }
            else
            {
                BusquedaSecuencial(name, tablaNombre[indice],indice);
            }

        }
        public static void BuscarPorCI(int ci)
        {
           int indice = FuncionCI(ci);
           
            if (tablaCI[indice] == null)
            {
                Console.WriteLine("Paciente no encontrado");
                delCI = 0;
                delName = "";
            }
            else
            {
                BusquedaBinaria(ci, 0, getLength(tablaCI[indice]) - 1, tablaCI[indice],indice);
            }

        }
       
        public static void BusquedaBinaria( int target, int izq, int der,Patient patient,int indice)
        {
            int medio;

            medio = (int)Math.Floor(((izq + der) * 1.0 / 2.0));
            if (der - izq > 1)
            {
                Patient CImedio = getPatient(patient, medio);
                if (CImedio.CI == target)
                {
                    Console.WriteLine("\t Paciente encontrado en  posicion de lista  {5} ,posicion de lista enlazada {0} : [{1}, {2}, {3}, {4}]", medio, CImedio.NombreCompleto, CImedio.CI,
                                                   CImedio.TipoPaciente, CImedio.FechaIngreso,indice);
                }
                else if (CImedio.CI < target)
                {
                    BusquedaBinaria( target, medio + 1, der,patient,indice);
                }
                else if (CImedio.CI > target)
                {
                    BusquedaBinaria( target, izq, medio - 1,patient,indice);
                }
            }
            else
            {
                Patient CIizq = getPatient(patient, izq);
                Patient CIder = getPatient(patient, der);
                if (CIizq.CI == target)
                {
                    Console.WriteLine("\t Paciente encontrado en  posicion de lista  {5} ,posicion de lista enlazada {0} : [{1}, {2}, {3}, {4}]", izq, CIizq.NombreCompleto, CIizq.CI,
                                                  CIizq.TipoPaciente, CIizq.FechaIngreso, indice);
                    delCI = CIizq.CI;
                    delName = CIizq.NombreCompleto;
                }
                else if (CIder.CI== target)
                {
                    Console.WriteLine("\t Paciente encontrado en  posicion de lista  {5} ,posicion de lista enlazada {0} : [{1}, {2}, {3}, {4}]", der, CIder.NombreCompleto, CIder.CI,
                                                  CIder.TipoPaciente, CIder.FechaIngreso, indice);
                    delCI = CIder.CI;
                    delName = CIder.NombreCompleto;
                }
                else
                {
                    Console.WriteLine("Paciente no encontrado");
                    delCI = 0;
                    delName = "";
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
                return;
            }
        }
        public static void MostrarPorNombre()
        {
            Patient current = null;
            for (int n = 0; n < cantidad; n++)
            {
                current = tablaNombre[n];
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
        public static void EliminarPacientePorCI(int ci)
        {
            int hash = ci % cantidad;
            while (tablaCI[hash] != null && tablaCI[hash].CI % cantidad != ci % cantidad)
            {
                hash = (hash + 1) % cantidad;
            }
            Patient current = tablaCI[hash];
            while (current != null)
            {
                if (current.CI == ci)
                {
                    tablaCI[hash] = current.Next;
                    Console.WriteLine("Paciente {0}, CI: {1} Eliminado.", current.NombreCompleto, current.CI);
                    break;
                }
                if (current.Next != null)
                {
                    if (current.Next.CI == ci)
                    {
                        Console.WriteLine("Paciente {0}, CI: {1} Eliminado.", current.Next.NombreCompleto, current.Next.CI);
                        Patient next = current.Next.Next;
                        current.Next = next;
                        break;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
        }
        public static void EliminarPacientePorNombre(string nombre)
        {
            int hash = nombre.Length % cantidad;
            while (tablaNombre[hash] != null && tablaNombre[hash].NombreCompleto.Length % cantidad != nombre.Length % cantidad)
            {
                hash = (hash + 1) % cantidad;
            }
            Patient current = tablaNombre[hash];

            while (current != null)
            {
                if (current.NombreCompleto == nombre)
                {
                    tablaNombre[hash] = current.Next;
                    Console.WriteLine("Paciente {0}, CI: {1} Eliminado.", current.NombreCompleto, current.CI);
                    break;
                }
                if (current.Next != null)
                {
                    if (current.Next.NombreCompleto == nombre)
                    {
                        Console.WriteLine("Paciente {0}, CI: {1} Eliminado.", current.Next.NombreCompleto, current.Next.CI);
                        Patient next = current.Next.Next;
                        current.Next = next;
                        break;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
        }
        public static Patient Partition(Patient left, Patient right) 
        {

            if (left == right || left == null || right == null) 
            {
                return left;
            }
            Patient i = left;
            Patient j = left;
            string nombrePiv = right.NombreCompleto;
            int piv = right.CI;
            string tipoPiv = right.TipoPaciente;
            string fechaPiv = right.FechaIngreso;
            while (left != right && left != null)          
            {
                if (left.CI < piv)
                {
                    i = j;
                    string tmpNombre = j.NombreCompleto;
                    int tmpCI = j.CI;
                    string tmpTipo = j.TipoPaciente;
                    string tmpFecha = j.FechaIngreso;
                    j.NombreCompleto = left.NombreCompleto;
                    j.CI = left.CI;
                    j.TipoPaciente = left.TipoPaciente;
                    j.FechaIngreso = left.FechaIngreso;
                    left.NombreCompleto = tmpNombre;
                    left.CI = tmpCI;
                    left.TipoPaciente = tmpTipo;
                    left.FechaIngreso = tmpFecha;
                    j = j.Next;
                }
                left = left.Next;
            }
            if (left != null)                                
            {
                string tmpNombre = j.NombreCompleto;
                int tmpCI = j.CI;
                string tmpTipo = j.TipoPaciente;
                string tmpFecha = j.FechaIngreso;
                j.NombreCompleto = nombrePiv;
                j.CI = piv;
                j.TipoPaciente = tipoPiv;
                j.FechaIngreso = fechaPiv;
                right.NombreCompleto = tmpNombre;
                right.CI = tmpCI;
                right.TipoPaciente = tmpTipo;
                right.FechaIngreso = tmpFecha;
            }
            return i;
        }

        public static void quickSort(Patient first, Patient last)
        {
            if (first == last)
            {
                return;
            }

            Patient pivotNode = Partition(first, last);
            quickSort(first, pivotNode);
            Patient current = pivotNode;

            if (pivotNode != null && pivotNode == first)
            {
                quickSort(pivotNode.Next, last);
            }
            else if (pivotNode != null && pivotNode.Next != null)
            {
                quickSort(pivotNode.Next.Next, last);
            }
        }
        public static Patient getLastPatient(Patient p)
        {
            Patient temp = p;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }
    }
}
