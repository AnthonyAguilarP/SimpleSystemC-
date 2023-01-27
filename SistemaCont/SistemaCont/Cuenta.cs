using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCont
{
    public class Cuenta
    {
        public Cuenta[] a;
        public Cuenta(String cuenta,String tipo,Double saldo)
        {
            this.cuenta = cuenta;
            this.tipo = tipo;
            this.saldo = saldo;
        }
        public Cuenta()
        {

        }
        private String cuenta, tipo;
        private Double saldo;

        public String CUENTA
        {
            get
            {
                return cuenta;
            }
            set
            {
                cuenta = value;
            }
        }
        public String TIPO
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }
        public Double SALDO
        {
            get
            {
                return saldo;
            }
            set
            {
                saldo = value;
            }
        }
    }
}
