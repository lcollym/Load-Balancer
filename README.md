# Load Balancer - Proyecto de Balanceo de Carga

Este es un proyecto básico de Load Balancer desarrollado en **ASP.NET Core**. Su propósito es distribuir solicitudes HTTP entrantes entre múltiples servidores backend para garantizar escalabilidad y alta disponibilidad.

## Características

- **Balanceo de carga básico**:
  - Algoritmo: Round-robin (distribución equitativa).
- **Verificación de estado**:
  - Detecta si los servidores backend están activos antes de redirigir tráfico.
- **Monitoreo básico**:
  - Registro de estadísticas sobre las solicitudes procesadas.

## Requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/) (opcional, para ejecutar en contenedores)
- Herramienta de pruebas como [Postman](https://www.postman.com/) o `curl`.

## Instalación

1. Clona el repositorio:
   ```bash
   git clone https://github.com/tuusuario/Load-balancer.git
   cd Load-balancer
