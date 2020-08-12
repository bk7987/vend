FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine

WORKDIR /app
COPY ./src/ReviewService/*.csproj ./src/ReviewService/
RUN dotnet restore ./src/ReviewService/ReviewService.csproj

COPY . .
WORKDIR /app/src/ReviewService

ENTRYPOINT [ "dotnet", "watch", "run" ]