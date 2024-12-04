using Moq;
using gimnasio.Datos;
using gimnasio.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using gimnasio.Controllers;
using System.Data.SqlClient;

namespace gimnasioTests
{
    public class membresiaControllerTests
    {
        [Fact]
        public void agregarmembresiaTest()
        {

            /* rrange */
            /* se crea el objeto simulado moq en la clase administrador */
            var mockmembresiaDatos = new Mock<membresiaDatos>();
            /* se crea la instancia del controlador */
            membresiaController controller = new membresiaController();

            /* usa el modelo */
            var membresia= new membresiaModel
            {
                membresia = "test",
                duracion = 365,
                precio = 350
            };

            /* act */
            /* manda a llamar al metodo eliminar y
             * verifica que el resultado devuelve una vista */
            var resultado = controller.agregar(membresia) as RedirectToActionResult;

            /* assert */
            /* verifica que no este vacio y confirma si devolvio una view correctamente */
            Assert.NotNull(resultado);
            /* resultado esperado seria la vista "Administrar membresia" */
            Assert.Equal("listarMembresias", resultado.ActionName);

        }

        [Fact]
        public void eliminarmembresiaTest()
        {

            /* arrange */
            /* se crea el objeto simulado moq en la clase administrador */
            var membresiaDatos = new membresiaDatos();
            /* se crea la instancia del controlador */
            var controller = new membresiaController();

            var membresia = new membresiaModel
            {
                idMembresia = 7
            };

            /* act */
            /* manda a llamar al metodo validacionAdministrador y
             * verifica que el resultado devuelve una vista */
            var resultado = controller.eliminar(membresia) as RedirectToActionResult;

            /* assert */
            /* verifica que no este vacio y confirma si devolvio una view correctamente */
            Assert.NotNull(resultado);
            /* resultado esperado seria la vista "validacionAdministrador" */
            Assert.Equal("listarMembresias", resultado.ActionName);

        }

        [Fact]
        public void modificarmembresiaTest()
        {

            /* arrange */
            /* se crea el objeto simulado moq en la clase administrador */
            var membresiaDatos = new membresiaDatos();
            /* se crea la instancia del controlador */
            var controller = new membresiaController();

            var membresia = new membresiaModel
            {
                idMembresia = 3009,
                duracion = 365,
                membresia = "anual",
                precio = 360
            };

            /* act */
            /* manda a llamar al metodo validacionAdministrador y
             * verifica que el resultado devuelve una vista */
            var resultado = controller.modificar(membresia) as RedirectToActionResult;

            /* assert */
            /* verifica que no este vacio y confirma si devolvio una view correctamente */
            Assert.NotNull(resultado);
            /* resultado esperado seria la vista "validacionAdministrador" */
            Assert.Equal("listarMembresias", resultado.ActionName);

        }

    }
}
