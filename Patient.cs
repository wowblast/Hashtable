using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableProject
{
    class Patient
    {
        public string NombreCompleto { get; set; }
        public int CI { get; set; }
        public string TipoPaciente { get; set; }
        public string FechaIngreso { get; set; }
        public Patient Next { get; set; }

        public Patient(string nombreCompleto, int ci, string tipoPaciente, string fechaIngreso, Patient next)
        {
            NombreCompleto = nombreCompleto;
            CI = ci;
            TipoPaciente = tipoPaciente;
            FechaIngreso = fechaIngreso;
            if (next != null)
            {
                Next = new Patient(next.NombreCompleto, next.CI, next.TipoPaciente, next.FechaIngreso, next.Next);
            }
            else
            {
                Next = next;
            }
        }
    }
}
