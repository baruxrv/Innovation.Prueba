# Innovation.Prueba

**Especificaciones Tecnicas del Proyecto

-Proyecto realizado en ASP.NET Core Framework netcoreapp2.2

-- IDE Visual Studio Code

-- La Soluciones esta constituida de 4 Proyectos

- Innovation.DGT.DBContext
- Innivation.DGT.Domain
- Innovation.DGT.Entities
- Innovation.DGT.WebApi

--Package Nugets Utilizados:


<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="6.0.0" />
<PackageReference Include="Microsoft.AspNetCore.App" />
<PackageReference Include="Microsoft.AspNetCore.Razor.Design" Version="2.2.0" PrivateAssets="All" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="2.2.1" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="2.2.1" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="4.0.1" />


**Especificaciones de Prueba

- Compilar y ejecutar el proyecto Innovation.DGT.WebApi
- Para poder probar la api el proyecto consta de swagger --> https://localhost:5001/swagger/index.html


--Cumplimiento de Requerimientos segun documentacion:

Se pide diseñar un modelo de datos (diagrama de clases para .NET(C#)) que
cumpla y tenga en cuenta las siguientes operaciones:

->El modelo de datos se encuentra en el proyecto Innovation.DGT.DBContext; He implementado EF Core para la creacion de Modelo de Datos y la Creacion de la DB con EF Migration

 Añadir un nuevo conductor al sistema. (DNI, nombre y apellidos,
puntos) No puede haber dos conductores con el mismo DNI.

--> Innovation.DGT.WebApi : POST https://localhost:5001/api/Driver



 Añadir un nuevo vehículo al sistema. (Matrícula, marca, modelo y DNI
conductor habitual) Si el vehículo ya existe devolver un ERROR. Si DNI
del conductor no existe devolver un ERROR. Puede haber más de un
conductor habitual y el conductor en sí no puede ser habitual de más
de 10 vehículos.


--> Innovation.DGT.WebApi : POST https://localhost:5001/api/Vehicle


 Añadir infracciones al sistema (identificador, descripción, puntos a
descontar)

--> Innovation.DGT.WebApi : POST https://localhost:5001/api/Infringement


 Registrar una infracción por vehículo. Se asignará al conductor
habitual y se descontarán puntos automáticamente. (Hora, fecha,
conductor, vehículo)

--> Innovation.DGT.WebApi : POST https://localhost:5001/api/Infringement/vehicle

 Consultar historial de infracciones de un conductor.

--> Innovation.DGT.WebApi : GET https://localhost:5001/api/Infringement/driver/{driverId}

 Consultar los 5 tipos de infracción más habituales.

--> Innovation.DGT.WebApi : GET https://localhost:5001/api/Infringement/TopPopular/{top}

 Consultar el top N de conductores.

--> Innovation.DGT.WebApi : GET https://localhost:5001/api/driver/top/{top}



*Especificaciones de Base de Datos

--La DB por defecto esta creada en sqlite3. Para esto se necesita tener previamente instalado sqlite3 en nuestro sistema operativo
--Dentro del Proyecto se encuentra creada una DB "Dgt.db" con datos de prueba.
--Se puede hacer uso de EF migration para la creacion de una nueva DB en el motor DB que se dece, para esto se debe de configurar las opciones del DBContext.












