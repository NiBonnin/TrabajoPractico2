
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Program
    {
        static Controlador ct = new Controlador();
        static void Main(string[] args)
        {
            char op;
            do
            {
                Console.WriteLine("Bienvenido al banco Keyshon");
                Console.WriteLine("Cliente seleccionado:");
                Console.WriteLine("Nombre: " + ct.GetNombre());
                Console.WriteLine("Tipo documento: " + ct.GetTipoDocumento());
                Console.WriteLine("Numero documento: " + ct.GetNumeroDocumento());
                Console.WriteLine("Sus opciones son:");
                Console.WriteLine("1. Acreditar saldo a un cliente");
                Console.WriteLine("2. Debitar saldo a una cuenta");
                Console.WriteLine("3. Transferencia entre cuenta");
                Console.WriteLine("0. Salir");
                try
                {
                    op = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    Console.WriteLine("Se saldra de la aplicacion");
                    Console.ReadKey();
                    op = '0';
                }
                switch (op)
                {
                    case '1': OpcionAcreditarSaldo(); break;
                    case '2': OpcionDebitarSaldo(); break;
                    case '3': OpcionTransferencia(); break;
                    default: op = '0'; break;
                }
                Console.Clear();
            } while (op != '0');

        }

        static public void OpcionAcreditarSaldo()
        {
            Console.WriteLine("Elija una cuenta");
            Console.WriteLine("1. Cuenta corriente (se acreditan $1406)");
            Console.WriteLine("2. Caja de ahorro (se acreditan $1532)");
            int tipo;
            try
            {
                tipo = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.ReadKey();
                tipo = 0;
            }
            switch (tipo)
            {
                case 1: ct.AcreditarSaldoCC(1406); break;
                case 2: ct.AcreditarSaldoCA(1532); break;
                default: Console.WriteLine("Error"); break;
            }
        }
        static public double OpcionDebitarSaldo()
        {
            Console.WriteLine("Elija una cuenta");
            Console.WriteLine("1. Cuenta corriente (se debitaran $1406)");
            Console.WriteLine("2. Caja de ahorro (se debitaran $1532)");
            int tipo;
            try
            {
                tipo = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.ReadKey();
                tipo = 0;
            }
            switch (tipo)
            {
                case 1:
                    if (!ct.DebitarSaldoCC(1406)) { Console.WriteLine("No hay lo suficiente en la cuenta como para poder debitar"); return 0; }
                    else { Console.WriteLine("Se han debitado $1406 del cliente de la Cuenta Corriente"); return 1406; }

                case 2:
                    if (!ct.DebitarSaldoCA(1532)) { Console.WriteLine("No hay lo suficiente en la cuenta como para poder debitar"); return 0; }
                    else { Console.WriteLine("Se han debitado $1532 del cliente de la Caja de Ahorro"); return 1532; }

                default: Console.WriteLine("Error"); return 0;
            }
        }
        static public void OpcionTransferencia()
        {
            Console.WriteLine("Cuenta a la que depositara el dinero");
            double dinero = OpcionDebitarSaldo();
            if (dinero != 0)
            {
                Console.WriteLine("Elija una cuenta");
                Console.WriteLine("1. Cuenta corriente (se acreditan $1406)");
                Console.WriteLine("2. Caja de ahorro (se acreditan $1532)");
                int tipo = Convert.ToInt32(Console.ReadLine());
                switch (tipo)
                {
                    case 1: ct.AcreditarSaldoCC(dinero); break;
                    case 2: ct.AcreditarSaldoCA(dinero); break;
                    default: Console.WriteLine("Error, se acredita en Cuenta Corriente"); ct.AcreditarSaldoCC(dinero); break;
                }
            }
            else Console.WriteLine("Error");
            
        }





        /*static Cliente c1 = null, c2 = null, c3 = null, c4 = null;
        static void Main(string[] args)
        {
            char op;
            Console.WriteLine("Bienvenido al banco Keyshon");
            Console.WriteLine("Sus opciones son:");
            Console.WriteLine("1. Agregar un nuevo cliente");
            Console.WriteLine("0. Salir");
            try
            {
                op = Convert.ToChar(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine("Se saldra de la aplicacion");
                Console.ReadKey();
                op = '0';
            }
            if ('1' == op)
            {
                opcionCrearCliente();
                do
                {
                    Console.Clear();
                    Console.WriteLine("Banco Keyshon");
                    Console.WriteLine("Sus opciones son:");
                    Console.WriteLine("1. Agregar un nuevo cliente");
                    Console.WriteLine("2. Ver clientes");
                    Console.WriteLine("3. Acreditar saldo a un cliente");
                    Console.WriteLine("4. Debitar saldo a un cliente");
                    Console.WriteLine("5. Transferencia entre clientes");
                    Console.WriteLine("0. Salir");
                    try
                    {
                        op = Convert.ToChar(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: "+ e.Message);
                        Console.WriteLine("Se saldra de la aplicacion");
                        Console.ReadKey();
                        op = '0';
                    }
                    switch (op)
                    {
                        case '1': opcionCrearCliente(); break;
                        case '2': mostrarClientes(); Console.Clear(); break;
                        case '3': opcionAcreditarSaldo(); break;
                        case '4': opcionDebitarSaldo(); break;
                        case '5': opcionTransferencia(); break;
                        default: op ='0'; break;
                    }
                } while (op != '0');
            }
        }





        static public void opcionCrearCliente()
        {
            if (c1 == null) { c1 = crearCliente(); }
                else if (c2 == null) { c2 = crearCliente(); }
                    else if (c3 == null) { c3 = crearCliente(); }
                        else if (c4 == null) { c4 = crearCliente(); }
                            else Console.WriteLine("No se pueden crear mas clientes!");
            Console.ReadKey();
            Console.Clear();
        }

        static public void opcionAcreditarSaldo()
        {
            Console.WriteLine("Para acreditar saldo debe elegir un cliente");
            Cliente cliente = elegirCliente();
            if (cliente != null)
            {
                agregarSaldo(cliente);
            }
            else { Console.WriteLine("Error al elegir cuenta"); }
        }

        static public void opcionDebitarSaldo()
        {
            Console.WriteLine("Para debitar saldo debe elegir un cliente");
            Cliente cliente = elegirCliente();
            if (cliente != null)
            {
                debitarSaldo(cliente);
            }
            else { Console.WriteLine("Error al elegir cuenta"); }
        }

        static public void opcionTransferencia()
        {
            Console.WriteLine("Opcion de transferencia");
            Console.WriteLine("Debe seleccionar dos clientes");
            Console.WriteLine("1er cliente (Aquel quien recibira el dinero)");
            Cliente cliente1 = elegirCliente();
            if (cliente1 != null)
            {
                Console.WriteLine("Seleccione una cuenta del cliente: " + cliente1.Nombre);
                Cuenta cta1 = elegirCuenta(cliente1);
                if (cta1 != null)
                {                   
                    Console.WriteLine("2do cliente (Aquel quien dara el dinero)");
                    Cliente cliente2 = elegirCliente();
                    if (cliente2 != null)
                    {
                        Console.WriteLine("Seleccione una cuenta del cliente: " + cliente2.Nombre);
                        Cuenta cta2 = elegirCuenta(cliente2);
                        if (cta2 != null)
                        {
                            Console.Clear();
                            Console.WriteLine("Opcion de transferencia");
                            Console.WriteLine("El cliente: " + cliente1.Nombre + 
                                " recibira dinero del cliente: " + cliente2.Nombre);
                            Console.ReadKey();
                            Console.Write("Selecciones la cantidad a transferir: $");
                            double saldo = Convert.ToDouble(Console.ReadLine());
                            if (!(cta2.debitarSaldo(saldo))) { Console.WriteLine("No hay lo suficiente en la cuenta como para poder debitar"); }
                            else { cta1.acreditarSaldo(saldo); Console.WriteLine("Se han transferido $"+ saldo + 
                                " del cliente " + cliente2.Nombre + " a el cliente "+ cliente1.Nombre); }
                            Console.ReadKey();
                        }
                        else { Console.WriteLine("Error al elegir la cuenta"); }
                    }
                    else { Console.WriteLine("Error al elegir el cliente"); }
                }
                else { Console.WriteLine("Error al elegir la cuenta"); }
            }
            else { Console.WriteLine("Error al elegir el cliente"); }
        }

        static public Cliente crearCliente()
        {
            Console.Clear();
            Console.WriteLine("Para agregar un nuevo cliente debe ingresar los siguientes datos");
            Console.WriteLine("Nombre, tipo de documento (dni, cuit, cuil, le, lc) y numero de documento");
            Console.Write("Nombre: ");
            String nombre = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Tipo de documento: (Opciones)");
            Console.WriteLine("1. DNI");
            Console.WriteLine("2. CUIT");
            Console.WriteLine("3. CUIL");
            Console.WriteLine("4. LE");
            Console.WriteLine("5. LC");
            Console.Write("Tipo: ");
            int tipo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Numero de documento: ");
            String numero = Convert.ToString(Console.ReadLine());
            Cliente c = new Cliente((Cliente.TipoDocumento)tipo, numero, nombre);
            Console.WriteLine("Su cliente se ha creado con exito");
            return c;
        }

        static public Boolean mostrarClientes()
        {
            int i = 0;
            if (c1 != null) { Console.WriteLine("Numero cliente 1"); mostrarCliente(c1); } else { i++; }
            if (c2 != null) { Console.WriteLine("Numero cliente 2"); mostrarCliente(c2); } else { i++; }
            if (c3 != null) { Console.WriteLine("Numero cliente 3"); mostrarCliente(c3); } else { i++; }
            if (c4 != null) { Console.WriteLine("Numero cliente 4"); mostrarCliente(c4); } else { i++; }
            if (i == 4)
            {
                Console.WriteLine("No hay clientes!");
                Console.ReadKey();
                Console.Clear();
                return false;
            }
            else
            {
                Console.ReadKey();
                return true;
            }
        }

        static public void mostrarCliente(Cliente c)
        {
            Console.WriteLine();
            Console.WriteLine("Nombre de cliente: "+ c.Nombre);
            Console.WriteLine("Numero de documento: ("+c.TipoDeDocumento+") "+ c.Documento);
            Cuenta ctaCorriente = c.cuentas.CuentaCorriente;
            Cuenta cjaAhorro = c.cuentas.CajaAhorro;
            Console.WriteLine("Cuenta corriente");
            Console.WriteLine("Saldo: $"+ctaCorriente.Saldo + ". Acuerdo: $"+ ctaCorriente.Acuerdo);
            Console.WriteLine("Caja de ahorro");
            Console.WriteLine("Saldo: $" + cjaAhorro.Saldo + ". Acuerdo: $" + cjaAhorro.Acuerdo);
            Console.WriteLine();
        }

        static public Cliente elegirCliente()
        {
            if (mostrarClientes())
            {
                Console.WriteLine("Eliga un cliente");
                char op;
                try
                {
                    op = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    op = '0';
                }
                switch (op)
                {
                    case '1': return c1;
                    case '2': return c2;
                    case '3': return c3;
                    case '4': return c4;
                    default: Console.WriteLine("Opcion erronea"); return null;
                }
            }
            else { Console.WriteLine("No hay clientes"); return null; }
        }

        static public Cuenta elegirCuenta(Cliente c)
        {
            Console.WriteLine("Elija una cuenta");
            Console.WriteLine("1. Cuenta corriente");
            Console.WriteLine("2. Caja de ahorro");
            int tipo = Convert.ToInt32(Console.ReadLine());
            switch (tipo)
            {
                case 1: return c.cuentas.CuentaCorriente;
                case 2: return c.cuentas.CajaAhorro;
                default: return null;
            }
        }

        static public void agregarSaldo(Cliente cliente)
        {
            Console.Clear();
            Console.WriteLine("Opcion de acreditar saldo a cliente: " + cliente.Nombre);
            Cuenta cta = elegirCuenta(cliente);
            if (cta != null)
            {
                Console.Write("Saldo que desea acreditar: $");
                double saldo = Convert.ToDouble(Console.ReadLine());
                cta.acreditarSaldo(saldo);
            }
            else { Console.WriteLine("Error al seleccionar el tipo"); Console.ReadKey(); }

        }

        static public void debitarSaldo(Cliente cliente)
        {
            Console.Clear();
            Console.WriteLine("Opcion de debitar saldo a cliente: " + cliente.Nombre);
            Cuenta cta = elegirCuenta(cliente);
            if (cta != null)
            {
                Console.Write("Saldo que desea debitar: $");
                double saldo = Convert.ToDouble(Console.ReadLine());
                if (!(cta.debitarSaldo(saldo))) { Console.WriteLine("No hay lo suficiente en la cuenta como para poder debitar"); }
                else { Console.WriteLine("Se han debitado $" + saldo + " del cliente" + cliente.Nombre); }
            }
            else { Console.WriteLine("Error al seleccionar el tipo"); }
        }*/

    }
}
