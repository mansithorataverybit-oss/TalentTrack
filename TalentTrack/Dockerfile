# Stage 1: Base Runtime with Linux Font support for PDF generation
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 10000

# Install fontconfig and standard TrueType fonts for PdfSharp support on Linux
RUN apt-get update && apt-get install -y --no-install-recommends \
    fontconfig \
    fonts-liberation \
    fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

# Stage 2: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["TalentTrack.csproj", "./"]
RUN dotnet restore "./TalentTrack.csproj"

# Copy source code and build
COPY . .
WORKDIR "/src/."
RUN dotnet build "TalentTrack.csproj" -c Release -o /app/build

# Stage 3: Publish
FROM build AS publish
RUN dotnet publish "TalentTrack.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 4: Final Production Image
FROM base AS final
WORKDIR /app

# Ensure directories for uploaded files exist
RUN mkdir -p /app/wwwroot/uploads/resumes \
             /app/wwwroot/uploads/documents \
             /app/wwwroot/uploads/offers

COPY --from=publish /app/publish .

# Environment configuration
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUN_IN_CONTAINER=true

ENTRYPOINT ["dotnet", "TalentTrack.dll"]
