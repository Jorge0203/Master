using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Containers
{
    public class ContainersBL
    {
        public BindingList<Container> ListaContainers { get; set; }

        public ContainersBL()
        {
            ListaContainers = new BindingList<Container>();

            var container1 = new Container();
            container1.Id = 1;
            container1.NumeroSerie = "123QRS";
            container1.MasaBrutaMaxima = 15000; 
            container1.PesoNeto = 20000;
            container1.AvisoAltura = 5;
            container1.VolumenInterno = 4;
            container1.Activo = true;

            var container2 = new Container();
            container2.Id = 2;
            container2.NumeroSerie = "125RJY";
            container2.MasaBrutaMaxima = 16000;
            container2.PesoNeto = 21000;
            container2.AvisoAltura = 5;
            container2.VolumenInterno = 4;
            container2.Activo = true;

            ListaContainers.Add(container1);
            ListaContainers.Add(container2);

        }

        public BindingList<Container> ObtenerContainers()
        {
            return ListaContainers;
        }

        //Instancia

        public Resultado GuardarProducto(Container container)
        {
            var resultado = Validar(container);

            if (resultado.Exitoso == false)
            {
                return resultado; 
            }
            if (container.Id == 0)
            {
                container.Id = ListaContainers.Max(item => item.Id) + 1;
            }
            resultado.Exitoso = true;
            return resultado;
        }
        public void AgregarProducto()
        {
            var nuevoContainer = new Container();
            ListaContainers.Add(nuevoContainer);
        }
        public bool EliminarProducto(int id)
        {
            foreach (var container in ListaContainers)
            {
                if (container.Id == id)
                {
                    ListaContainers.Remove(container);
                    return true;
                }
            }
            return false;
        }
        //Validacion

        private Resultado Validar(Container container)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (container.PesoNeto < 0 )
            {
                resultado.Mensaje = "Ingrese un peso neto mayor que cero";
                resultado.Exitoso = false;

            }
            if (container.VolumenInterno < 0)
            {
                resultado.Mensaje = "El volumen interno debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            if (container.MasaBrutaMaxima < 0)
            {
                resultado.Mensaje = "La masa bruta maxima debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            if (container.AvisoAltura < 0)
            {
                resultado.Mensaje = "La altura maxima debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            return resultado;
        }
    }

    public class Container
    {
        public int Id { get; set; }
        public string NumeroSerie { get; set; }
        public int MasaBrutaMaxima { get; set; }
        public int PesoNeto { get; set; }
        public int AvisoAltura { get; set; }
        public int VolumenInterno { get; set; }
        public bool Activo { get; set; }

    }
    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}

