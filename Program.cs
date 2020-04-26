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
            tablaCI = new Patient[cantidad];
            colasCI = new Patient[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                tablaCI[i] = null;
            }
            tablaNombre = new Patient[cantidad];
            colasNombre = new Patient[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                tablaNombre[i] = null;
            }

            InsertarPacientePorCI("Pepega Pls", 3333, "Internado", "Martes 4/4/2020");
            InsertarPacientePorCI("Pepega Shower", 2566, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorCI("Pepega Driving", 4261, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorCI("Wide Peepo Sad", 21, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorCI("Pepe Hands", 2118, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorCI("Monka Eyes", 1792, "Internado", "Miercoles 30/12/2020");
            InsertarPacientePorCI("Pepe Laugh", 1500, "Internado", "Jueves 2/5/2020");
            InsertarPacientePorCI("XQC L", 2991, "Internado", "Jueves 2/5/2020");



            MostrarPorCI();

            //EliminarPacientePorNombre("Pepega Pls");
            //MostrarPorNombre();


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
                Patient cola = getLastPatient(tablaCI[hash]);
                Console.WriteLine("elemento ultimo {0}, {1}", cola.CI, cola.NombreCompleto);

                quickSort(tablaCI[hash], cola);
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
            bool removido = false;
            while (current != null)
            {
                if (current.CI == ci)
                {
                    tablaCI[hash] = current.Next;
                    Console.WriteLine("Paciente {0}, CI: {1} Eliminado.", current.NombreCompleto, current.CI);
                    removido = true;
                    break;
                }
                if (current.Next != null)
                {
                    if (current.Next.CI == ci)
                    {
                        Console.WriteLine("Paciente {0}, CI: {1} Eliminado.", current.Next.NombreCompleto, current.Next.CI);
                        Patient next = current.Next.Next;
                        current.Next = next;
                        removido = true;
                        break;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            if (!removido)
            {
                Console.WriteLine("Paciente no encontrado.");
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
            bool removido = false;
            while (current != null)
            {
                if (current.NombreCompleto == nombre)
                {
                    tablaNombre[hash] = current.Next;
                    Console.WriteLine("Paciente {0}, CI: {1} Eliminado.", current.NombreCompleto, current.CI);
                    removido = true;
                    break;
                }
                if (current.Next != null)
                {
                    if (current.Next.NombreCompleto == nombre)
                    {
                        Console.WriteLine("Paciente {0}, CI: {1} Eliminado.", current.Next.NombreCompleto, current.Next.CI);
                        Patient next = current.Next.Next;
                        current.Next = next;
                        removido = true;
                        break;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            if (!removido)
            {
                Console.WriteLine("Paciente no encontrado.");
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
