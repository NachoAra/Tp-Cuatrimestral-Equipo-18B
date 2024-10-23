using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        private AccesoDatos accesoDatos;
        public ClienteNegocio()
        {
            accesoDatos = new AccesoDatos();
        }
        public bool ExisteDNI(string NroCliente)
        {
            try
            {
                accesoDatos.setearConsulta("SELECT NroCliente FROM Clientes WHERE NroCliente = @nroCliente");
                accesoDatos.setearParametro("@nroCliente", NroCliente);
                accesoDatos.ejecutarConsulta();

                if (accesoDatos.Lector.Read())
                    return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
            return false;
        }

        public Cliente GetCliente(string NroCliente)
        {
            Cliente cliente = new Cliente();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM Clientes WHERE NroCliente = @nroCliente");
                accesoDatos.setearParametro("@nroCliente", NroCliente);
                accesoDatos.ejecutarConsulta();

                if (accesoDatos.Lector.Read())
                {
                    cliente.NroCliente = NroCliente;
                    
                }

                return cliente;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public bool RegistrarCliente(Cliente cliente)
        {
            bool response = false;

            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                accesoDatos.setearConsulta("INSERT INTO Clientes (NroCliente)VALUES(@nroCliente)");
                
                if (accesoDatos.EjecutarAccion())
                    response = true; ;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
            return response;
        }
    }
}

