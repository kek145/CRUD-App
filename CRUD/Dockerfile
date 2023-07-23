# Этап 1: Сборка библиотек
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-libraries
WORKDIR /src

# Копируем файлы проектов библиотек и восстанавливаем зависимости
COPY CRUD.DAL/*.csproj CRUD.DAL/
COPY CRUD.BL/*.csproj CRUD.BL/
COPY CRUD.Domain/*.csproj CRUD.Domain/
COPY CRUD.API/*.csproj CRUD.API/
RUN dotnet restore CRUD.DAL/
RUN dotnet restore CRUD.BL/
RUN dotnet restore CRUD.Domain/
RUN dotnet restore CRUD.API/

# Копируем остальные файлы библиотек
COPY CRUD.DAL/. CRUD.DAL/
COPY CRUD.BL/. CRUD.BL/
COPY CRUD.Domain/. CRUD.Domain/

# Этап 2: Сборка приложения API
FROM build-libraries AS build-app
WORKDIR /src/CRUD.API

# Копируем файлы проекта API
COPY CRUD.API/. .

# Собираем приложение API в режиме Release
RUN dotnet build -c Release -o /app/publish

# Этап 3: Создание образа приложения
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build-app /app/publish .

# Экспонируем порт, на котором работает приложение
EXPOSE 80

# Запускаем приложение в режиме Production
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "CRUD.API.dll"]
