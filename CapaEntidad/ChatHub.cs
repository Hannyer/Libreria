using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ChatHub : Hub
    {
        public void EnviarMensaje(string usuario, string mensaje)
        {
            // enviar el mensaje a todos los clientes conectados
            Clients.All.broadcastMessage(usuario, mensaje);
        }

        public void Conectar(string nombre)
        {
            // agregar el usuario a la lista de conectados
            Clients.All.conectar(nombre);
        }

        public void Desconectar(string nombre)
        {
            // eliminar el usuario de la lista de conectados
            Clients.All.desconectar(nombre);
        }
    }
}
