using ProyectoAula3EmanuelGallego_SaraPineda;
using ProyectoAula3EmanuelGallego_SaraPineda.Models;

namespace ProyectoAula3EmanuelGallego_SaraPineda_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AgregarClienteTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Epm epm = new Epm();
            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);

            // Act
            epm.AgregarCliente(usuario);

            // Assert
            Assert.IsTrue(epm.DatosDeUsuarios.Contains(usuario), "El elemento no fue agregado a la lista correctamente");

        }

        [TestMethod]
        public void CalcularValorParcialEnergiaTest()
        {
            // Arrange
            double kilovatios_consumidos = 200;
            Factura factura = new Factura();

            double esperado = 170000;

            // Act
            double actual = factura.CalcularValorParcialEnergia(kilovatios_consumidos);

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void CalcularValorIncentivoEnergiaTest()
        {
            // Arrange
            double meta_energia = 180;
            double kilovatios_consumidos = 200;
            Factura factura = new Factura();

            double esperado = -17000;

            // Act
            double actual = factura.CalcularValorIncentivoEnergia(meta_energia, kilovatios_consumidos);

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void CalcularValorAPagarEnergiaTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Factura factura = new Factura(cedula);
            Epm epm = new Epm();

            epm.AgregarCliente(usuario);

            double esperado = 323000;

            // Act
            double actual = factura.CalcularValorAPagarEnergia();

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void CalcularValorParcialAguaTest()
        {
            // Arrange
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Factura factura = new Factura();


            double esperado = 115000;

            // Act
            double actual = factura.CalcularValorParcialAgua(consumoActualAgua, prmedioConsumoAgua);

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void CalcularValorExcesoAguaTest()
        {
            // Arrange
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Factura factura = new Factura();

            double esperado = 0;

            // Act
            double actual = factura.CalcularValorExcesoAgua(consumoActualAgua, prmedioConsumoAgua);

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void CalcularValorAPagarAguaTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Factura factura = new Factura(cedula);
            Epm epm = new Epm();

            epm.AgregarCliente(usuario);


            double esperado = 115000;

            // Act
            double actual = factura.CalcularValorAPagarAgua();

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void CalcularValorTotalAPagarTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Factura factura = new Factura(cedula);
            Epm epm = new Epm();

            epm.AgregarCliente(usuario);

            double esperado = 438000;

            // Act
            double actual = factura.CalcularValorTotalAPagar();

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void CacularPromedioConsumoDeEnergiaTest()
        {
            // Arrange

            // Conjunto de datos 1
            string cedula = "390104795";
            string nombre = "Tara";
            string apellidos = "Thomas Avila";
            int periodoConsumo = 9;
            int estrato = 4;
            int metaAhorroEnergia = 297;
            int consumoActualEnergia = 394;
            int prmedioConsumoAgua = 23;
            int consumoActualAgua = 21;

            // Conjunto de datos 2
            string cedula1 = "394104795";
            string nombre1 = "Tara";
            string apellidos1 = "Thomas Avila";
            int periodoConsumo1 = 8;
            int estrato1 = 3;
            int metaAhorroEnergia1 = 222;
            int consumoActualEnergia1 = 333;
            int prmedioConsumoAgua1 = 11;
            int consumoActualAgua1 = 22;

            // Conjunto de datos 3
            string cedula2 = "393104795";
            string nombre2 = "Tara";
            string apellidos2 = "Thomas Avila";
            int periodoConsumo2 = 7;
            int estrato2 = 2;
            int metaAhorroEnergia2 = 200;
            int consumoActualEnergia2 = 3123;
            int prmedioConsumoAgua2 = 20;
            int consumoActualAgua2 = 18;

            // Conjunto de datos 4
            string cedula3 = "392104795";
            string nombre3 = "Tara";
            string apellidos3 = "Thomas Avila";
            int periodoConsumo3 = 6;
            int estrato3 = 3;
            int metaAhorroEnergia3 = 201;
            int consumoActualEnergia3 = 394;
            int prmedioConsumoAgua3 = 24;
            int consumoActualAgua3 = 11;



            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Usuario usuario1 = new Usuario(cedula1, nombre1, apellidos1, periodoConsumo1, estrato1, metaAhorroEnergia1, consumoActualEnergia1, prmedioConsumoAgua1, consumoActualAgua1);
            Usuario usuario2 = new Usuario(cedula2, nombre2, apellidos2, periodoConsumo2, estrato2, metaAhorroEnergia2, consumoActualEnergia2, prmedioConsumoAgua2, consumoActualAgua2);
            Usuario usuario3 = new Usuario(cedula3, nombre3, apellidos3, periodoConsumo3, estrato3, metaAhorroEnergia3, consumoActualEnergia3, prmedioConsumoAgua3, consumoActualAgua3);

            Epm epm = new Epm();
            epm.AgregarCliente(usuario);
            epm.AgregarCliente(usuario1);
            epm.AgregarCliente(usuario2);
            epm.AgregarCliente(usuario3);


            // Conjunto de datos ((394) + (333) + (3123) + (394))/4 = 1061
            int esperado = 838;

            // Act
            int promedio_calculado = (int)epm.CacularPromedioConsumoDeEnergia();

            // Assert
            Assert.AreEqual(esperado, promedio_calculado);

        }


        [TestMethod]
        public void CalcularTotalDescuentosPorIncentivoDeEnergiaTest()
        {
            // Arrange

            // Conjunto de datos 1
            string cedula = "390104795";
            string nombre = "Tara";
            string apellidos = "Thomas Avila";
            int periodoConsumo = 9;
            int estrato = 4;
            int metaAhorroEnergia = 297;
            int consumoActualEnergia = 270;
            int prmedioConsumoAgua = 23;
            int consumoActualAgua = 21;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);

            Epm epm = new Epm();
            epm.AgregarCliente(usuario);


            // meta ahorro energia = 297 , consumo energia = 270, meta > consumo -> True
            // (meta_energia - kilovatios_consumidos) * Valor_kilovatio -> (297 - 270) * 850 = 22950
            int esperado = 206550;

            // Act
            int ahorro_calculado = (int)epm.CalcularTotalDescuentosPorIncentivoDeEnergia();

            // Assert
            Assert.AreEqual(esperado, ahorro_calculado);

        }


        [TestMethod]
        public void CalcularTotalM3AguaEncimaPromedioTest()
        {
            // Arrange

            // Conjunto de datos 1
            string cedula = "390104795";
            string nombre = "Tara";
            string apellidos = "Thomas Avila";
            int periodoConsumo = 9;
            int estrato = 4;
            int metaAhorroEnergia = 297;
            int consumoActualEnergia = 270;
            int prmedioConsumoAgua = 23;
            int consumoActualAgua = 21;


            // Conjunto de datos 2
            string cedula1 = "394104795";
            string nombre1 = "Tara";
            string apellidos1 = "Thomas Avila";
            int periodoConsumo1 = 8;
            int estrato1 = 3;
            int metaAhorroEnergia1 = 222;
            int consumoActualEnergia1 = 333;
            int prmedioConsumoAgua1 = 11;
            int consumoActualAgua1 = 22;

            // Conjunto de datos 3
            string cedula2 = "393104795";
            string nombre2 = "Tara";
            string apellidos2 = "Thomas Avila";
            int periodoConsumo2 = 7;
            int estrato2 = 2;
            int metaAhorroEnergia2 = 200;
            int consumoActualEnergia2 = 3123;
            int prmedioConsumoAgua2 = 20;
            int consumoActualAgua2 = 28;

            // Conjunto de datos 4
            string cedula3 = "392104795";
            string nombre3 = "Tara";
            string apellidos3 = "Thomas Avila";
            int periodoConsumo3 = 6;
            int estrato3 = 3;
            int metaAhorroEnergia3 = 201;
            int consumoActualEnergia3 = 394;
            int prmedioConsumoAgua3 = 24;
            int consumoActualAgua3 = 30;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Usuario usuario1 = new Usuario(cedula1, nombre1, apellidos1, periodoConsumo1, estrato1, metaAhorroEnergia1, consumoActualEnergia1, prmedioConsumoAgua1, consumoActualAgua1);
            Usuario usuario2 = new Usuario(cedula2, nombre2, apellidos2, periodoConsumo2, estrato2, metaAhorroEnergia2, consumoActualEnergia2, prmedioConsumoAgua2, consumoActualAgua2);
            Usuario usuario3 = new Usuario(cedula3, nombre3, apellidos3, periodoConsumo3, estrato3, metaAhorroEnergia3, consumoActualEnergia3, prmedioConsumoAgua3, consumoActualAgua3);

            Epm epm = new Epm();
            epm.AgregarCliente(usuario);
            epm.AgregarCliente(usuario1);
            epm.AgregarCliente(usuario2);
            epm.AgregarCliente(usuario3);


            // meta ahorro energia = 297 , consumo energia = 270, meta > consumo -> True
            // (meta_energia - kilovatios_consumidos) * Valor_kilovatio -> (297 - 270) * 850 = 22950
            int esperado = 268;

            // Act
            int ahorro_calculado = (int)epm.CalcularTotalM3AguaEncimaPromedio();

            // Assert
            Assert.AreEqual(esperado, ahorro_calculado);

        }

        [TestMethod]
        public void CalcularClientesConConsumoAguaMayorAlPromedio()
        {
            // Arrange

            // Conjunto de datos 1
            string cedula = "390104795";
            string nombre = "Tara";
            string apellidos = "Thomas Avila";
            int periodoConsumo = 9;
            int estrato = 4;
            int metaAhorroEnergia = 297;
            int consumoActualEnergia = 270;
            int prmedioConsumoAgua = 23;
            int consumoActualAgua = 21;


            // Conjunto de datos 2
            string cedula1 = "394104795";
            string nombre1 = "Tara";
            string apellidos1 = "Thomas Avila";
            int periodoConsumo1 = 8;
            int estrato1 = 3;
            int metaAhorroEnergia1 = 222;
            int consumoActualEnergia1 = 333;
            int prmedioConsumoAgua1 = 11;
            int consumoActualAgua1 = 22;

            // Conjunto de datos 3
            string cedula2 = "393104795";
            string nombre2 = "Tara";
            string apellidos2 = "Thomas Avila";
            int periodoConsumo2 = 7;
            int estrato2 = 2;
            int metaAhorroEnergia2 = 200;
            int consumoActualEnergia2 = 3123;
            int prmedioConsumoAgua2 = 20;
            int consumoActualAgua2 = 28;

            // Conjunto de datos 4
            string cedula3 = "392104795";
            string nombre3 = "Tara";
            string apellidos3 = "Thomas Avila";
            int periodoConsumo3 = 6;
            int estrato3 = 3;
            int metaAhorroEnergia3 = 201;
            int consumoActualEnergia3 = 394;
            int prmedioConsumoAgua3 = 24;
            int consumoActualAgua3 = 30;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Usuario usuario1 = new Usuario(cedula1, nombre1, apellidos1, periodoConsumo1, estrato1, metaAhorroEnergia1, consumoActualEnergia1, prmedioConsumoAgua1, consumoActualAgua1);
            Usuario usuario2 = new Usuario(cedula2, nombre2, apellidos2, periodoConsumo2, estrato2, metaAhorroEnergia2, consumoActualEnergia2, prmedioConsumoAgua2, consumoActualAgua2);
            Usuario usuario3 = new Usuario(cedula3, nombre3, apellidos3, periodoConsumo3, estrato3, metaAhorroEnergia3, consumoActualEnergia3, prmedioConsumoAgua3, consumoActualAgua3);

            Epm epm = new Epm();
            epm.AgregarCliente(usuario);
            epm.AgregarCliente(usuario1);
            epm.AgregarCliente(usuario2);
            epm.AgregarCliente(usuario3);


            // meta ahorro energia = 297 , consumo energia = 270, meta > consumo -> True
            // (meta_energia - kilovatios_consumidos) * Valor_kilovatio -> (297 - 270) * 850 = 22950
            int esperado = 15;

            // Act
            int ahorro_calculado = (int)epm.CalcularClientesConConsumoAguaMayorAlPromedio();

            // Assert
            Assert.AreEqual(esperado, ahorro_calculado);

        }

        [TestMethod]
        public void MostrarDatosClienteConMayorDesfaseEnergiaTest() // CORREGIR ESTEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
        {
            // Arrange

            // Conjunto de datos 1
            string cedula = "390104795";
            string nombre = "Tara";
            string apellidos = "Thomas Avila";
            int periodoConsumo = 9;
            int estrato = 4;
            int metaAhorroEnergia = 297;
            int consumoActualEnergia = 270;
            int prmedioConsumoAgua = 23;
            int consumoActualAgua = 21;


            // Conjunto de datos 2
            string cedula1 = "394104795";
            string nombre1 = "Tara";
            string apellidos1 = "Thomas Avila";
            int periodoConsumo1 = 8;
            int estrato1 = 3;
            int metaAhorroEnergia1 = 222;
            int consumoActualEnergia1 = 333;
            int prmedioConsumoAgua1 = 11;
            int consumoActualAgua1 = 22;

            // Conjunto de datos 3
            string cedula2 = "393104795";
            string nombre2 = "Tara";
            string apellidos2 = "Thomas Avila";
            int periodoConsumo2 = 7;
            int estrato2 = 2;
            int metaAhorroEnergia2 = 200;
            int consumoActualEnergia2 = 3123;
            int prmedioConsumoAgua2 = 20;
            int consumoActualAgua2 = 28;

            // Conjunto de datos 4
            string cedula3 = "392104795";
            string nombre3 = "Tara";
            string apellidos3 = "Thomas Avila";
            int periodoConsumo3 = 6;
            int estrato3 = 3;
            int metaAhorroEnergia3 = 201;
            int consumoActualEnergia3 = 394;
            int prmedioConsumoAgua3 = 24;
            int consumoActualAgua3 = 30;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Usuario usuario1 = new Usuario(cedula1, nombre1, apellidos1, periodoConsumo1, estrato1, metaAhorroEnergia1, consumoActualEnergia1, prmedioConsumoAgua1, consumoActualAgua1);
            Usuario usuario2 = new Usuario(cedula2, nombre2, apellidos2, periodoConsumo2, estrato2, metaAhorroEnergia2, consumoActualEnergia2, prmedioConsumoAgua2, consumoActualAgua2);
            Usuario usuario3 = new Usuario(cedula3, nombre3, apellidos3, periodoConsumo3, estrato3, metaAhorroEnergia3, consumoActualEnergia3, prmedioConsumoAgua3, consumoActualAgua3);

            Epm epm = new Epm();
            epm.AgregarCliente(usuario);
            epm.AgregarCliente(usuario1);
            epm.AgregarCliente(usuario2);
            epm.AgregarCliente(usuario3);

            string esperado = "393104795";

            // Act
            string actual = epm.MostrarDatosClienteConMayorDesfaseEnergia();

            // Assert
            Assert.AreEqual(esperado, actual);

        }

        [TestMethod]
        public void MostrarEstratoConMayorAhorroAguaTest()
        {
            // Arrange

            // Conjunto de datos 1
            string cedula = "390104795";
            string nombre = "Tara";
            string apellidos = "Thomas Avila";
            int periodoConsumo = 9;
            int estrato = 4;
            int metaAhorroEnergia = 297;
            int consumoActualEnergia = 270;
            int prmedioConsumoAgua = 23;
            int consumoActualAgua = 21;


            // Conjunto de datos 2
            string cedula1 = "394104795";
            string nombre1 = "Tara";
            string apellidos1 = "Thomas Avila";
            int periodoConsumo1 = 8;
            int estrato1 = 3;
            int metaAhorroEnergia1 = 222;
            int consumoActualEnergia1 = 333;
            int prmedioConsumoAgua1 = 11;
            int consumoActualAgua1 = 22;

            // Conjunto de datos 3
            string cedula2 = "393104795";
            string nombre2 = "Tara";
            string apellidos2 = "Thomas Avila";
            int periodoConsumo2 = 7;
            int estrato2 = 2;
            int metaAhorroEnergia2 = 200;
            int consumoActualEnergia2 = 3123;
            int prmedioConsumoAgua2 = 20;
            int consumoActualAgua2 = 28;

            // Conjunto de datos 4
            string cedula3 = "392104795";
            string nombre3 = "Tara";
            string apellidos3 = "Thomas Avila";
            int periodoConsumo3 = 6;
            int estrato3 = 3;
            int metaAhorroEnergia3 = 201;
            int consumoActualEnergia3 = 394;
            int prmedioConsumoAgua3 = 24;
            int consumoActualAgua3 = 30;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Usuario usuario1 = new Usuario(cedula1, nombre1, apellidos1, periodoConsumo1, estrato1, metaAhorroEnergia1, consumoActualEnergia1, prmedioConsumoAgua1, consumoActualAgua1);
            Usuario usuario2 = new Usuario(cedula2, nombre2, apellidos2, periodoConsumo2, estrato2, metaAhorroEnergia2, consumoActualEnergia2, prmedioConsumoAgua2, consumoActualAgua2);
            Usuario usuario3 = new Usuario(cedula3, nombre3, apellidos3, periodoConsumo3, estrato3, metaAhorroEnergia3, consumoActualEnergia3, prmedioConsumoAgua3, consumoActualAgua3);

            Epm epm = new Epm();
            epm.AgregarCliente(usuario);
            epm.AgregarCliente(usuario1);
            epm.AgregarCliente(usuario2);
            epm.AgregarCliente(usuario3);

            int esperado = 4;

            // Act
            int actual = (int)epm.MostrarEstratoConMayorAhorroAgua();

            // Assert
            Assert.AreEqual(esperado, actual);

        }

        [TestMethod]
        public void MostrarEstratoConMayorConsumoEnergiaTest()
        {
            // Arrange

            // Conjunto de datos 1
            string cedula = "390104795";
            string nombre = "Tara";
            string apellidos = "Thomas Avila";
            int periodoConsumo = 9;
            int estrato = 4;
            int metaAhorroEnergia = 297;
            int consumoActualEnergia = 270;
            int prmedioConsumoAgua = 23;
            int consumoActualAgua = 21;


            // Conjunto de datos 2
            string cedula1 = "394104795";
            string nombre1 = "Tara";
            string apellidos1 = "Thomas Avila";
            int periodoConsumo1 = 8;
            int estrato1 = 3;
            int metaAhorroEnergia1 = 222;
            int consumoActualEnergia1 = 333;
            int prmedioConsumoAgua1 = 11;
            int consumoActualAgua1 = 22;

            // Conjunto de datos 3
            string cedula2 = "393104795";
            string nombre2 = "Tara";
            string apellidos2 = "Thomas Avila";
            int periodoConsumo2 = 7;
            int estrato2 = 2;
            int metaAhorroEnergia2 = 200;
            int consumoActualEnergia2 = 3123;
            int prmedioConsumoAgua2 = 20;
            int consumoActualAgua2 = 28;

            // Conjunto de datos 4
            string cedula3 = "392104795";
            string nombre3 = "Tara";
            string apellidos3 = "Thomas Avila";
            int periodoConsumo3 = 6;
            int estrato3 = 3;
            int metaAhorroEnergia3 = 201;
            int consumoActualEnergia3 = 394;
            int prmedioConsumoAgua3 = 24;
            int consumoActualAgua3 = 30;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Usuario usuario1 = new Usuario(cedula1, nombre1, apellidos1, periodoConsumo1, estrato1, metaAhorroEnergia1, consumoActualEnergia1, prmedioConsumoAgua1, consumoActualAgua1);
            Usuario usuario2 = new Usuario(cedula2, nombre2, apellidos2, periodoConsumo2, estrato2, metaAhorroEnergia2, consumoActualEnergia2, prmedioConsumoAgua2, consumoActualAgua2);
            Usuario usuario3 = new Usuario(cedula3, nombre3, apellidos3, periodoConsumo3, estrato3, metaAhorroEnergia3, consumoActualEnergia3, prmedioConsumoAgua3, consumoActualAgua3);

            Epm epm = new Epm();
            epm.AgregarCliente(usuario);
            epm.AgregarCliente(usuario1);
            epm.AgregarCliente(usuario2);
            epm.AgregarCliente(usuario3);

            int esperado = 2;

            // Act
            int actual = (int)epm.MostrarEstratoConMayorConsumoEnergia();

            // Assert
            Assert.AreEqual(esperado, actual);

        }
        [TestMethod]
        public void MostrarEstratoConMenorConsumoEnergiaTest()
        {
            // Arrange

            // Conjunto de datos 1
            string cedula = "390104795";
            string nombre = "Tara";
            string apellidos = "Thomas Avila";
            int periodoConsumo = 9;
            int estrato = 4;
            int metaAhorroEnergia = 297;
            int consumoActualEnergia = 270;
            int prmedioConsumoAgua = 23;
            int consumoActualAgua = 21;


            // Conjunto de datos 2
            string cedula1 = "394104795";
            string nombre1 = "Tara";
            string apellidos1 = "Thomas Avila";
            int periodoConsumo1 = 8;
            int estrato1 = 3;
            int metaAhorroEnergia1 = 222;
            int consumoActualEnergia1 = 333;
            int prmedioConsumoAgua1 = 11;
            int consumoActualAgua1 = 22;

            // Conjunto de datos 3
            string cedula2 = "393104795";
            string nombre2 = "Tara";
            string apellidos2 = "Thomas Avila";
            int periodoConsumo2 = 7;
            int estrato2 = 2;
            int metaAhorroEnergia2 = 200;
            int consumoActualEnergia2 = 3123;
            int prmedioConsumoAgua2 = 20;
            int consumoActualAgua2 = 28;

            // Conjunto de datos 4
            string cedula3 = "392104795";
            string nombre3 = "Tara";
            string apellidos3 = "Thomas Avila";
            int periodoConsumo3 = 6;
            int estrato3 = 3;
            int metaAhorroEnergia3 = 201;
            int consumoActualEnergia3 = 394;
            int prmedioConsumoAgua3 = 24;
            int consumoActualAgua3 = 30;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Usuario usuario1 = new Usuario(cedula1, nombre1, apellidos1, periodoConsumo1, estrato1, metaAhorroEnergia1, consumoActualEnergia1, prmedioConsumoAgua1, consumoActualAgua1);
            Usuario usuario2 = new Usuario(cedula2, nombre2, apellidos2, periodoConsumo2, estrato2, metaAhorroEnergia2, consumoActualEnergia2, prmedioConsumoAgua2, consumoActualAgua2);
            Usuario usuario3 = new Usuario(cedula3, nombre3, apellidos3, periodoConsumo3, estrato3, metaAhorroEnergia3, consumoActualEnergia3, prmedioConsumoAgua3, consumoActualAgua3);

            Epm epm = new Epm();
            epm.AgregarCliente(usuario);
            epm.AgregarCliente(usuario1);
            epm.AgregarCliente(usuario2);
            epm.AgregarCliente(usuario3);

            int esperado = 4;

            // Act
            int actual = (int)epm.MostrarEstratoConMenorConsumoEnergia();

            // Assert
            Assert.AreEqual(esperado, actual);

        }
        [TestMethod]
        public void CalcularTotalPagadoEmpresaPorConsumoTotalTest()
        {
            // Arrange

            // Conjunto de datos 1
            string cedula = "390104795";
            string nombre = "Tara";
            string apellidos = "Thomas Avila";
            int periodoConsumo = 9;
            int estrato = 4;
            int metaAhorroEnergia = 297;
            int consumoActualEnergia = 270;
            int prmedioConsumoAgua = 23;
            int consumoActualAgua = 21;


            // Conjunto de datos 2
            string cedula1 = "394104795";
            string nombre1 = "Tara";
            string apellidos1 = "Thomas Avila";
            int periodoConsumo1 = 8;
            int estrato1 = 3;
            int metaAhorroEnergia1 = 222;
            int consumoActualEnergia1 = 333;
            int prmedioConsumoAgua1 = 11;
            int consumoActualAgua1 = 22;

            // Conjunto de datos 3
            string cedula2 = "393104795";
            string nombre2 = "Tara";
            string apellidos2 = "Thomas Avila";
            int periodoConsumo2 = 7;
            int estrato2 = 2;
            int metaAhorroEnergia2 = 200;
            int consumoActualEnergia2 = 3123;
            int prmedioConsumoAgua2 = 20;
            int consumoActualAgua2 = 28;

            // Conjunto de datos 4
            string cedula3 = "392104795";
            string nombre3 = "Tara";
            string apellidos3 = "Thomas Avila";
            int periodoConsumo3 = 6;
            int estrato3 = 3;
            int metaAhorroEnergia3 = 201;
            int consumoActualEnergia3 = 394;
            int prmedioConsumoAgua3 = 24;
            int consumoActualAgua3 = 30;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Usuario usuario1 = new Usuario(cedula1, nombre1, apellidos1, periodoConsumo1, estrato1, metaAhorroEnergia1, consumoActualEnergia1, prmedioConsumoAgua1, consumoActualAgua1);
            Usuario usuario2 = new Usuario(cedula2, nombre2, apellidos2, periodoConsumo2, estrato2, metaAhorroEnergia2, consumoActualEnergia2, prmedioConsumoAgua2, consumoActualAgua2);
            Usuario usuario3 = new Usuario(cedula3, nombre3, apellidos3, periodoConsumo3, estrato3, metaAhorroEnergia3, consumoActualEnergia3, prmedioConsumoAgua3, consumoActualAgua3);

            Factura factura = new Factura(cedula);
            Epm epm = new Epm();

            epm.AgregarCliente(usuario);
            epm.AgregarCliente(usuario1);
            epm.AgregarCliente(usuario2);
            epm.AgregarCliente(usuario3);

            int esperado = 4850400;

            // Act
            int actual = (int)factura.CalcularTotalPagadoEmpresaPorConsumoTotal();

            // Assert
            Assert.AreEqual(esperado, actual);

        }

        [TestMethod]
        public void CalcularClienteMayorConsumoAguaTest() //OTRO PARA CAMBIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR
        {
            // Arrange

            // Conjunto de datos 1
            string cedula = "390104795";
            string nombre = "Tara";
            string apellidos = "Thomas Avila";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 297;
            int consumoActualEnergia = 270;
            int prmedioConsumoAgua = 23;
            int consumoActualAgua = 21;


            // Conjunto de datos 2
            string cedula1 = "394104795";
            string nombre1 = "Camila";
            string apellidos1 = "Toro";
            int periodoConsumo1 = 3;
            int estrato1 = 3;
            int metaAhorroEnergia1 = 222;
            int consumoActualEnergia1 = 333;
            int prmedioConsumoAgua1 = 11;
            int consumoActualAgua1 = 22;


            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Usuario usuario1 = new Usuario(cedula1, nombre1, apellidos1, periodoConsumo1, estrato1, metaAhorroEnergia1, consumoActualEnergia1, prmedioConsumoAgua1, consumoActualAgua1);


            Epm epm = new Epm();
            epm.AgregarCliente(usuario);
            epm.AgregarCliente(usuario1);

            string esperado = "Mes: 3, Cliente con mayor consumo: 394104795 ";

            // Act
            string actual = epm.CalcularClienteMayorConsumoAgua();

            // Assert
            Assert.AreEqual(esperado, actual);

        }

        [TestMethod]
        public void verificarExistenciaIdTest()
        {
            // Arrange

            // Conjunto de datos 1
            string cedula = "390104795";
            string nombre = "Tara";
            string apellidos = "Thomas Avila";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 297;
            int consumoActualEnergia = 270;
            int prmedioConsumoAgua = 23;
            int consumoActualAgua = 21;


            // Conjunto de datos 2
            string cedula1 = "394104795";
            string nombre1 = "Camila";
            string apellidos1 = "Toro";
            int periodoConsumo1 = 3;
            int estrato1 = 3;
            int metaAhorroEnergia1 = 222;
            int consumoActualEnergia1 = 333;
            int prmedioConsumoAgua1 = 11;
            int consumoActualAgua1 = 22;

            string cedula2 = "390104795";

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Usuario usuario1 = new Usuario(cedula1, nombre1, apellidos1, periodoConsumo1, estrato1, metaAhorroEnergia1, consumoActualEnergia1, prmedioConsumoAgua1, consumoActualAgua1);

            Verificacion verificacion = new Verificacion();
            Epm epm = new Epm();

            epm.AgregarCliente(usuario);
            epm.AgregarCliente(usuario1);


            bool esperado = true;

            // Act
            bool actual = verificacion.verificarExistenciaId(cedula2);

            // Assert
            Assert.AreEqual(esperado, actual);

        }
        [TestMethod]
        public void modificarNombreTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Modificacion modificacion = new Modificacion();

            Usuario esperado = usuario;

            // Act
            Usuario actual = modificacion.modificarNombre(cedula, "Manuela");

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void modificarApellidoTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Modificacion modificacion = new Modificacion();

            Usuario esperado = usuario;

            // Act
            Usuario actual = modificacion.modificarApellido(cedula, "Soler");

            // Assert
            Assert.AreEqual(esperado, actual);
        }


        [TestMethod]
        public void modificarPeriodoConsumoTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Modificacion modificacion = new Modificacion();

            Usuario esperado = usuario;

            // Act
            Usuario actual = modificacion.modificarPeriodoConsumo(cedula, 12);

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void modificarEstratoTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Modificacion modificacion = new Modificacion();

            Usuario esperado = usuario;

            // Act
            Usuario actual = modificacion.modificarEstrato(cedula, 5);

            // Assert
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void modificarMetaAhorroEnergiaTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Modificacion modificacion = new Modificacion();

            Usuario esperado = usuario;

            // Act
            Usuario actual = modificacion.modificarMetaAhorroEnergia(cedula, 35);

            // Assert
            Assert.AreEqual(esperado, actual);
        }


        [TestMethod]
        public void modificarConsumoEnergiaTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Modificacion modificacion = new Modificacion();

            Usuario esperado = usuario;

            // Act
            Usuario actual = modificacion.modificarConsumoEnergia(cedula, 80);

            // Assert
            Assert.AreEqual(esperado, actual);
        }


        [TestMethod]
        public void modificarPromedioConsumoAguaTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Modificacion modificacion = new Modificacion();

            Usuario esperado = usuario;

            // Act
            Usuario actual = modificacion.modificarPromedioConsumoAgua(cedula, 80);

            // Assert
            Assert.AreEqual(esperado, actual);
        }


        [TestMethod]
        public void modificarConsumoAguaTest()
        {
            // Arrange
            string cedula = "1001003858";
            string nombre = "Sara";
            string apellidos = "Pineda Valencia";
            int periodoConsumo = 3;
            int estrato = 4;
            int metaAhorroEnergia = 260;
            int consumoActualEnergia = 320;
            int prmedioConsumoAgua = 25;
            int consumoActualAgua = 25;

            Usuario usuario = new Usuario(cedula, nombre, apellidos, periodoConsumo, estrato, metaAhorroEnergia, consumoActualEnergia, prmedioConsumoAgua, consumoActualAgua);
            Modificacion modificacion = new Modificacion();

            Usuario esperado = usuario;

            // Act
            Usuario actual = modificacion.modificarConsumoAgua(cedula, 80);

            // Assert
            Assert.AreEqual(esperado, actual);
        }

    }
}