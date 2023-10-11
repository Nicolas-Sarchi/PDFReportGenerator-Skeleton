# PDFReportGenerator-Skeleton
# Uso
* Para comenzar a usar el generador correctamente haga la actualización de la base de datos usando el comando: `dotnet ef database update --project ./Persistence/ --startup-project ./API/
`
### Generador de Reportes PDF (PdfGenerator.cs)
A continuación se muestra el método que genera los reportes pdf
```
public byte[] GenerateReport(FacturaDto factura)
        {
            string currentDirectory = Directory.GetCurrentDirectory();


            string templateFolderPath = Path.Combine(currentDirectory, "Generator", "Template");

            var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(templateFolderPath)
                .Build();

            string htmlContent = engine.CompileRenderAsync("FacturaTemplate.cshtml", factura).Result;
            string fileName = "ejemplo.pdf";
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\Downloads\" + fileName;
            Console.WriteLine(filePath);
            using (FileStream stream = new (filePath, FileMode.Create))
            {
                ConverterProperties converterProperties = new ();
                HtmlConverter.ConvertToPdf(htmlContent, stream, converterProperties);
                byte[] byteArray = File.ReadAllBytes(filePath);

                return byteArray;
            }
        }
 ```
### Plantilla Razor (factura.cshtml)
Este es un ejemplo de plantilla de Razor para mostrar los datos en el pdf, en este caso se muestra la implementación de fuentes de Google Fonts y estilos de Bootstrap: 

 ```
@model Api.Dtos.FacturaDto

<!DOCTYPE html>
<html>
<head>
    <title>Factura</title>
  <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
<style>
    *{
        font-family: 'Poppins', sans-serif;
    }
    table {
            width: 100%;
            border-collapse: collapse;
        }
        th, td {
            border: 1px solid #ccc;
            padding: 8px;
            text-align: left;
        }
        th {
            background-color: #f2f2f2;
            }
</style>
</head>
<body>
    <h1 class="fw-bolder text-center">Resumen de Compra</h1>
    <div class="container">
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Factura # @Model.Id </h5>
                <h6 class="card-subtitle mb-2 text-muted">@Model.Fecha</h6>
                <p class="card-text">
                    <strong class="fw-bold">Cliente:</strong> @Model.Cliente.Nombre @Model.Cliente.Apellido <br>
                    <strong>Email:</strong> @Model.Cliente.Email <br>
                    <strong>Teléfono:</strong> @Model.Cliente.Telefono
                </p>
            </div>
        </div>
        <table class="table  mt-3">
            <thead>
                <tr>
                    <th>Producto</th>
                    <th>Categoría</th>
                    <th>Precio</th>
                    <th>Cantidad</th>
                    <th>Subtotal</th>
                </tr>
            </thead>
            <tbody>
                @foreach (var item in Model.DetallesFactura)
                {
                    <tr>
                        <td>@item.Producto.Nombre</td>
                        <td>@item.Producto.Categoria.Nombre</td>
                        <td>$@item.Producto.Precio</td>
                        <td>@item.Cantidad</td>
                        <td>$@item.Precio</td>
                    </tr>
                }
            </tbody>
        </table>
        <div class="mt-5">
            Total: $ @Model.Total
        </div>
    </div>

</body>
</html>
 ```

### Importante ⚠️ 

Se debe incluir esta etiqueta en el `API.csproj` para que RazorLight pueda renderizar la plantilla correctamente.
 ```
<PreserveCompilationContext>true</PreserveCompilationContext>
 ```
