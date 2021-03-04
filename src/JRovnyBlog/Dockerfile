# https://github.com/NuGet/Announcements/issues/49
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim-amd64 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./JRovnyBlog.csproj", "src/"]
RUN dotnet restore "src/JRovnyBlog.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "JRovnyBlog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JRovnyBlog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5001
ENTRYPOINT ["dotnet", "JRovnyBlog.dll"]
