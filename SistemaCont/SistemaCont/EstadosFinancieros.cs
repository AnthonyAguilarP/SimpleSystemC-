using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCont
{
    internal class EstadosFinancieros : Cuenta
    {
        public void add(Cuenta[] b)
        {
            a = b;
        }
        public Double sum(Cuenta[] cc)
        {
            Double suma = 0.0;
            foreach(Cuenta c in cc)
            {
                suma = suma + c.SALDO;
            }
            return suma;
        }
        public Cuenta[] cuentas(String b)
        {
            int i = 0,k=0; 
            
            while(k!=(a.Length-1))
            {
                if (a[k].TIPO ==b)i++;
                k++;
            }
            Cuenta[] d = new Cuenta[i];
            k = 0;
            int j = 0;
            while (k != (a.Length - 1))
            {
                if (a[k].TIPO == b)
                {
                    d[j] = a[k];
                    j++;
                }
                k++;
            }
            return d;
        }
    }
}
