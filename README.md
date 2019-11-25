# Caracteristicas

- Demo realizada con C# netframework 4.6 en visual studio community 2017
- Base de datos Sql server en azure
- appService MVC 5 en azure 
- Acceso a datos con entity framework 6.0


# Github

- Link del repo: https://github.com/smonrroy/devops.git
- Sincronización automática con repositorio en Azure devops (configurado en pipeline de azuredevops)



# Herramienta de analisis estático

- Se implementó la herramienta Sonarqube
- Se montó un appserver docker con sonarqube sobre linux en azure
- Url Sonarqube : https://sonarqb.azurewebsites.net/
- Usuario:admin
- clave: admin
- Se tuvieron problemas de compatibilidad por el MSBuild - no se logró analizar el código al 100%
- Token usado: 06947220c8e224ef1def377e8cd91d6eabaf11be

# Automatización CI/CD

- se utilizó Azure devops
- Configuración de job en pipeline de azure para ejecutar las tareas de descarga de dependencias, compilación, ejecución de pruebas unitarias y de integración, analisis estatico , y deploy en azure y docker.
- el job se dispara al subir cambios al repositorio y deploya de pasar todas las tareas correctamente.

# Azure
- Cuenta gratuita creada para realizar esta demo
- Usuario: la misma cuenta de github

# Azure devops

- Url: https://dev.azure.com/smonrroyDevOps
- Usuario: la misma cuenta de github

#Docker

- iddocker:smonrroydocker
- clave:dockersmonrroy1